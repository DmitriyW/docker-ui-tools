using Docker.Models;
using Docker.Services;

namespace Docker.GUI
{
    public partial class Form1 : Form
    {
        private IList<Container> _containers = new List<Container>();
        private string filter = string.Empty;
        private string currentGroup = "All";
        private readonly ContainerServices containersService;
        private IList<string> _selectedContainers = new List<string>();

        public Form1()
        {
            InitializeComponent();
            this.containerList.MouseClick += ContainerList_MouseClick;
            this.searchContainer.TextChanged += SearchContainer_TextChanged;
            this.checkAll.Click += CheckAll_Click;
            this.containerList.ItemChecked += ContainerList_ItemChecked;
            this.containerGroups.NodeMouseClick += ContainerGroups_NodeMouseClick;

            containersService = new ContainerServices();
            this.refreshContainerList.Enabled = false;
            RefreshContainersAsync();
            actionBtnState();
            this.selectedGroupLabel.Text = "All";
        }

        private void ContainerGroups_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            var selectedNode = e.Node;
            if (selectedNode != null)
            {
                this.selectedGroupLabel.Text = selectedNode.Text;
                currentGroup = selectedNode.Text == "Individual containers" ? 
                    null : selectedNode.Text;
                RefreshContainersAsync(false);
            }
        }

        private void viewGroups()
        {
            var groups = GetGroups();
            this.containerGroups.Nodes.Clear();
            this.containerGroups.Nodes.Add("All");
            foreach (var group in groups)
            {
                this.containerGroups.Nodes[0].Nodes.Add(group == null ? "Individual containers" : group);
            }
            this.containerGroups.ExpandAll();
        }

        private IEnumerable<string> GetGroups()
            => _containers.Select(c => c.ComposeProject).Distinct();

        private IEnumerable<Container> FilteredList()
        {
            var list = filter.Length > 0 ? _containers.Where(c => c.Names.IndexOf(this.searchContainer.Text) == 0) : _containers;
            if (currentGroup != "All")
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
                if (_containers.ToList()[index].State == "paused")
                {
                    this.start.Enabled = true;
                    this.stop.Enabled = true;
                }
                if (_containers.ToList()[index].State == "running")
                {
                    this.stop.Enabled = true;
                    this.pause.Enabled = true;
                }
                if (_containers.ToList()[index].State == "exited")
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
                lvi.ImageIndex = GetContainerImage(item.State.Trim().ToLower());
                lvi.ForeColor = item.State.Trim().ToLower() == "running" || item.State.Trim().ToLower() == "paused" ? SystemColors.WindowText : SystemColors.GrayText;
                list.Add(lvi);
            }

            this.containerList.Items.AddRange(list.ToArray());
        }

        private int GetContainerImage(string state)
        {
            switch (state)
            {
                case "running":
                    return 1;
                case "paused":
                    return 2;
                case "exited":
                default:
                    return 0;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            startContainerAsync();
        }

        private async Task startContainerAsync()
        {
            var startResult = new Action<string>(x =>
            {
                RefreshContainersAsync();
            });

            foreach (int index in GetSelectedIndexes())
            {
                if (_containers.ToList()[index].State == "paused")
                {
                    await containersService.UnpauseContainerAsync(new Progress<string>(startResult), _containers.ToList()[index].ID);
                }
                else if (_containers.ToList()[index].State != "running")
                {
                    await containersService.StartContainerAsync(new Progress<string>(startResult), _containers.ToList()[index].ID);
                }
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            StopContainers();
        }

        private async Task StopContainers()
        {
            var stopResult = new Action<string>(x =>
            {
                RefreshContainersAsync();
            });
            foreach (int index in GetSelectedIndexes())
            {
                await containersService.StopContainerAsync(new Progress<string>(stopResult), _containers.ToList()[index].ID);
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            PauseContainers();
        }

        private async Task PauseContainers()
        {
            var pauseResult = new Action<string>(x =>
            {
                RefreshContainersAsync();
            });
            foreach (int index in GetSelectedIndexes())
            {
                await containersService.PauseContainerAsync(new Progress<string>(pauseResult), _containers.ToList()[index].ID);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DeleteContainers();
        }

        private async Task DeleteContainers()
        {
            var deleteResult = new Action<string>(x =>
            {
                RefreshContainersAsync();
            });
            foreach (int index in GetSelectedIndexes())
            {
                await containersService.DeleteContainerAsync(new Progress<string>(deleteResult), _containers.ToList()[index].ID);
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

            var startResult = new Action<string>(x =>
            {
                RefreshContainersAsync();
            });

            if (_containers.ToList()[index].State == "paused")
            {
                containersService.UnpauseContainerAsync(new Progress<string>(startResult), _containers.ToList()[index].ID);
            }
            else if (_containers.ToList()[index].State != "running")
            {
                containersService.StartContainerAsync(new Progress<string>(startResult), _containers.ToList()[index].ID);
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
            var restartResult = new Action<string>(x =>
            {
                RefreshContainersAsync();
            });

            containersService.RestartContainerAsync(new Progress<string>(restartResult), _containers.ToList()[index].ID);
        }

        private void stopContainerMenu_Click(object sender, EventArgs e)
        {
            var focusedItem = this.containerList.FocusedItem;
            var index = focusedItem.Index;

            StopContainer(index);
        }

        private async Task StopContainer(int index)
        {
            var stopResult = new Action<string>(x =>
            {
                RefreshContainersAsync();
            });
            await containersService.StopContainerAsync(new Progress<string>(stopResult), _containers.ToList()[index].ID);
        }

        private void pauseContainerMenu_Click(object sender, EventArgs e)
        {
            var focusedItem = this.containerList.FocusedItem;
            var index = focusedItem.Index;
            PauseContainer(index);
        }

        private async Task PauseContainer(int index)
        {
            var pauseResult = new Action<string>(x =>
            {
                RefreshContainersAsync();
            });
            await containersService.PauseContainerAsync(new Progress<string>(pauseResult), _containers.ToList()[index].ID);
        }

        private void deleteContainerMenu_Click(object sender, EventArgs e)
        {
            var focusedItem = this.containerList.FocusedItem;
            var index = focusedItem.Index;
            DeleteContainer(index);
        }

        private async Task DeleteContainer(int index)
        {
            var deleteResult = new Action<string>(x =>
            {
                RefreshContainersAsync();
            });
            await containersService.DeleteContainerAsync(new Progress<string>(deleteResult), _containers.ToList()[index].ID);
        }

        private void copyIdContainerMenu_Click(object sender, EventArgs e)
        {
            var focusedItem = this.containerList.FocusedItem;
            var index = focusedItem.Index;

            Clipboard.SetText(_containers.ToList()[index].ID);
        }

        private void SearchContainer_TextChanged(object? sender, EventArgs e)
        {
            filter = this.searchContainer.Text;
            RefreshContainersAsync(false);
        }
    }
}