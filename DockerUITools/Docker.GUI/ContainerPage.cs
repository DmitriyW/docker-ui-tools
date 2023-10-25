using Docker.Abstractions.Services;
using Docker.Models;
using containers = Docker.Constants.Containers;

namespace Docker.GUI;

public partial class ContainerPage : UserControl
{
    private IList<Container> _containers = new List<Container>();
    private string filter = string.Empty;
    private string currentGroup = containers.ALL;
    private readonly IContainerService containersService;
    private IList<string> _selectedContainers = new List<string>();
    private IDictionary<string, string> _messages = new Dictionary<string, string>();

    public ContainerPage(IContainerService containerService)
    {
        this.containersService = containerService;
        InitializeComponent();
        AddEvents();

        this.refreshContainerList.Enabled = false;
        RefreshContainersAsync();
        actionBtnState();
        this.selectedGroupLabel.Text = containers.ALL;
    }

    private void AddEvents()
    {
        this.containerList.MouseClick += ContainerList_MouseClick;
        this.searchContainer.TextChanged += SearchContainer_TextChanged;
        this.checkAll.Click += CheckAll_Click;
        this.containerList.ItemChecked += ContainerList_ItemChecked;
        this.containerGroups.NodeMouseClick += ContainerGroups_NodeMouseClick;
        this.containerList.MouseDoubleClick += ContainerList_MouseDoubleClick;
        this.startContainerMenu.Click += startContainerMenu_Click;
        this.stopContainerMenu.Click += stopContainerMenu_Click;
        this.pauseContainerMenu.Click += pauseContainerMenu_Click;
        this.deleteContainerMenu.Click += deleteContainerMenu_Click;
        this.restartContainerMenu.Click += restartContainerMenu_Click;
        this.copyIdContainerMenu.Click += copyIdContainerMenu_Click;
        this.viewLogs.Click += viewLogs_Click;

        this.deleteContainer.Click += delete_Click;
        this.start.Click += start_Click;
        this.stop.Click += stop_Click;
        this.pause.Click += pause_Click;
        this.refreshContainerList.Click += refresh_Click;
    }

    private void ContainerGroups_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
    {
        var selectedNode = e.Node;
        if (selectedNode != null)
        {
            this.selectedGroupLabel.Text = selectedNode.Text;
            currentGroup = selectedNode.Text == containers.IndividualContainers ?
                null : selectedNode.Text;
            RefreshContainersAsync(false);
        }
    }

    private void viewGroups()
    {
        var groups = GetGroups();
        this.containerGroups.Nodes.Clear();
        this.containerGroups.Nodes.Add(containers.ALL);
        foreach (var group in groups)
        {
            this.containerGroups.Nodes[0].Nodes.Add(group == null ? containers.IndividualContainers : group);
        }
        this.containerGroups.ExpandAll();
    }

    private IEnumerable<string> GetGroups()
        => _containers.Select(c => c.ComposeProject).Distinct();

    private IEnumerable<Container> FilteredList()
    {
        var list = filter.Length > 0 ? _containers.Where(c => c.Names.IndexOf(this.searchContainer.Text) == 0) : _containers;
        if (currentGroup != containers.ALL)
        {
            list = list.Where(c => c.ComposeProject == currentGroup);
        }
        return list;
    }

    private void disableActionBtnState()
    {
        this.deleteContainer.Enabled = false;
        this.start.Enabled = false;
        this.stop.Enabled = false;
        this.pause.Enabled = false;
    }

    private void actionBtnState()
    {
        foreach (int index in GetSelectedIndexes())
        {
            this.deleteContainer.Enabled = true;
            if (FilteredList().ToList()[index].State == containers.Paused)
            {
                this.start.Enabled = true;
                this.stop.Enabled = true;
            }
            if (FilteredList().ToList()[index].State == containers.Running)
            {
                this.stop.Enabled = true;
                this.pause.Enabled = true;
            }
            if (FilteredList().ToList()[index].State == containers.Exited)
            {
                this.start.Enabled = true;
            }
        }
    }

    private void CheckAll_Click(object? sender, EventArgs e)
    {
        ChangeCheckboxStateForContainers(this.checkAll.Checked);
    }

    private void ContainerList_ItemChecked(object? sender, ItemCheckedEventArgs e)
    {
        disableActionBtnState();
        if (this.containerList.CheckedItems.Count == this.containerList.Items.Count)
        {
            this.checkAll.Checked = true;
        }
        else
        {
            this.checkAll.Checked = false;
        }
        actionBtnState();
    }

    private void ChangeCheckboxStateForContainers(bool state)
    {
        foreach (ListViewItem item in this.containerList.Items)
        {
            item.Checked = state;
        }
    }

    private void refresh_Click(object sender, EventArgs e)
    {
        this.refreshContainerList.Enabled = false;
        RefreshContainersAsync();
    }

    private async Task RefreshContainersAsync(bool getFreshData = true)
    {
        if (getFreshData)
        {
            var getContainers = new Action<IEnumerable<Container>>(x =>
            {
                _containers = x.ToList();
                ViewContainers();
                this.refreshContainerList.Enabled = true;
            });
            await containersService.GetContainersAsync(new Progress<IEnumerable<Container>>(getContainers));
            viewGroups();
        }
        else
        {
            ViewContainers();
            this.refreshContainerList.Enabled = true;
        }
    }

    private void ViewContainers()
    {
        var list = new List<ListViewItem>();
        containerList.Items.Clear();

        foreach (var item in FilteredList())
        {
            var lvi = new ListViewItem();
            lvi.Checked = _selectedContainers.Contains(item.ID);
            lvi.SubItems.Add(item.Names);
            lvi.SubItems.Add(item.Image);
            lvi.SubItems.Add(item.State);
            lvi.SubItems.Add(item.Ports);
            lvi.SubItems.Add(item.Status);
            lvi.SubItems.Add(this._messages.ContainsKey(item.ID) ? this._messages[item.ID] : string.Empty);
            lvi.ImageIndex = GetContainerImage(item.State.Trim().ToLower());
            lvi.ForeColor = item.State.Trim().ToLower() == containers.Running || 
                item.State.Trim().ToLower() == containers.Paused ? 
                SystemColors.WindowText : SystemColors.GrayText;
            list.Add(lvi);
        }

        this.containerList.Items.AddRange(list.ToArray());
    }

    private int GetContainerImage(string state)
    {
        switch (state)
        {
            case containers.Running:
                return 1;
            case containers.Paused:
                return 2;
            case containers.Exited:
            default:
                return 0;
        }
    }

    private void start_Click(object sender, EventArgs e)
    {
        startContainerAsync();
    }

    private void UpdateResultMessages(CommandResult result)
    {
        if (this._messages.ContainsKey(result.ElementId))
        {
            this._messages[result.ElementId] = result.Message;
        }
        else
        {
            this._messages.Add(result.ElementId, result.Message);
        }
    }

    private async Task startContainerAsync()
    {
        var startResult = new Action<CommandResult>(x =>
        {
            UpdateResultMessages(x);
            RefreshContainersAsync();
        });

        foreach (int index in GetSelectedIndexes())
        {
            if (FilteredList().ToList()[index].State == containers.Paused)
            {
                await containersService.UnPauseContainerAsync(new Progress<CommandResult>(startResult), FilteredList().ToList()[index].ID);
            }
            else if (FilteredList().ToList()[index].State != containers.Running)
            {
                await containersService.StartContainerAsync(new Progress<CommandResult>(startResult), FilteredList().ToList()[index].ID);
            }
        }
    }

    private void stop_Click(object sender, EventArgs e)
    {
        StopContainers();
    }

    private async Task StopContainers()
    {
        var stopResult = new Action<CommandResult>(x =>
        {
            UpdateResultMessages(x);
            RefreshContainersAsync();
        });
        foreach (int index in GetSelectedIndexes())
        {
            if (FilteredList().ToList()[index].State != containers.Exited)
                await containersService.StopContainerAsync(new Progress<CommandResult>(stopResult), FilteredList().ToList()[index].ID);
        }
    }

    private void pause_Click(object sender, EventArgs e)
    {
        PauseContainers();
    }

    private async Task PauseContainers()
    {
        var pauseResult = new Action<CommandResult>(x =>
        {
            UpdateResultMessages(x);
            RefreshContainersAsync();
        });
        foreach (int index in GetSelectedIndexes())
        {
            await containersService.PauseContainerAsync(new Progress<CommandResult>(pauseResult), FilteredList().ToList()[index].ID);
        }
    }

    private void delete_Click(object sender, EventArgs e)
    {
        DeleteContainers();
    }

    private async Task DeleteContainers()
    {
        var deleteResult = new Action<CommandResult>(x =>
        {
            UpdateResultMessages(x);
            RefreshContainersAsync();
        });
        foreach (int index in GetSelectedIndexes())
        {
            await containersService.DeleteContainerAsync(new Progress<CommandResult>(deleteResult), FilteredList().ToList()[index].ID);
        }
    }

    private void ContainerList_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var focusedItem = this.containerList.FocusedItem;
            if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
            {
                this.containerContextMenu.Show(Cursor.Position);
            }
        }
    }

    private void ContainerList_MouseDoubleClick(object? sender, MouseEventArgs e)
    {
        var focusedItem = this.containerList.FocusedItem;
        if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
        {
            var index = focusedItem.Index;
            var logWindow = new Logs(FilteredList().ToList()[index].ID, FilteredList().ToList()[index].Names);
            logWindow.Show();
        }
    }

    private IEnumerable<int> GetSelectedIndexes()
    {
        _selectedContainers.Clear();

        var indexes = new List<int>();
        foreach (ListViewItem selectedContainer in this.containerList.CheckedItems)
        {
            indexes.Add(selectedContainer.Index);
            _selectedContainers.Add(_containers[selectedContainer.Index].ID);
        }

        return indexes;
    }

    private void startContainerMenu_Click(object sender, EventArgs e)
    {
        var focusedItem = this.containerList.FocusedItem;
        var index = focusedItem.Index;

        var startResult = new Action<CommandResult>(x =>
        {
            UpdateResultMessages(x);
            RefreshContainersAsync();
        });

        if (FilteredList().ToList()[index].State == containers.Paused)
        {
            containersService.UnPauseContainerAsync(new Progress<CommandResult>(startResult), FilteredList().ToList()[index].ID);
        }
        else if (FilteredList().ToList()[index].State != containers.Running)
        {
            containersService.StartContainerAsync(new Progress<CommandResult>(startResult), FilteredList().ToList()[index].ID);
        }
    }

    private void restartContainerMenu_Click(object sender, EventArgs e)
    {
        var focusedItem = this.containerList.FocusedItem;
        var index = focusedItem.Index;

        restartContainerAsync(index);
    }

    private async Task restartContainerAsync(int index)
    {
        var restartResult = new Action<CommandResult>(x =>
        {
            UpdateResultMessages(x);
            RefreshContainersAsync();
        });

        await containersService.RestartContainerAsync(new Progress<CommandResult>(restartResult), FilteredList().ToList()[index].ID);
    }

    private void stopContainerMenu_Click(object sender, EventArgs e)
    {
        var focusedItem = this.containerList.FocusedItem;
        var index = focusedItem.Index;

        StopContainer(index);
    }

    private async Task StopContainer(int index)
    {
        var stopResult = new Action<CommandResult>(x =>
        {
            UpdateResultMessages(x);
            RefreshContainersAsync();
        });
        await containersService.StopContainerAsync(new Progress<CommandResult>(stopResult), FilteredList().ToList()[index].ID);
    }

    private void pauseContainerMenu_Click(object sender, EventArgs e)
    {
        var focusedItem = this.containerList.FocusedItem;
        var index = focusedItem.Index;
        PauseContainer(index);
    }

    private async Task PauseContainer(int index)
    {
        var pauseResult = new Action<CommandResult>(x =>
        {
            UpdateResultMessages(x);
            RefreshContainersAsync();
        });
        await containersService.PauseContainerAsync(new Progress<CommandResult>(pauseResult), FilteredList().ToList()[index].ID);
    }

    private void deleteContainerMenu_Click(object sender, EventArgs e)
    {
        var focusedItem = this.containerList.FocusedItem;
        var index = focusedItem.Index;
        DeleteContainer(index);
    }

    private async Task DeleteContainer(int index)
    {
        var deleteResult = new Action<CommandResult>(x =>
        {
            UpdateResultMessages(x);
            RefreshContainersAsync();
        });
        await containersService.DeleteContainerAsync(new Progress<CommandResult>(deleteResult), FilteredList().ToList()[index].ID);
    }

    private void copyIdContainerMenu_Click(object sender, EventArgs e)
    {
        var focusedItem = this.containerList.FocusedItem;
        var index = focusedItem.Index;

        Clipboard.SetText(FilteredList().ToList()[index].ID);
    }

    private void SearchContainer_TextChanged(object? sender, EventArgs e)
    {
        filter = this.searchContainer.Text;
        RefreshContainersAsync(false);
    }

    private void viewLogs_Click(object sender, EventArgs e)
    {
        var focusedItem = this.containerList.FocusedItem;
        if (focusedItem != null)
        {
            var index = focusedItem.Index;
            var logWindow = new Logs(FilteredList().ToList()[index].ID, FilteredList().ToList()[index].Names);
            logWindow.Show();
        }
    }
}
