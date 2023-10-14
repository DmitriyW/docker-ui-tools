using Docker.Models;
using Docker.Services;

namespace Docker.GUI
{
    public partial class Form1 : Form
    {
        private IEnumerable<Container> _containers = new List<Container>();
        private string filter = string.Empty;
        private readonly ContainerServices containersService;

        public Form1()
        {
            InitializeComponent();
            this.containerList.MouseClick += ContainerList_MouseClick;
            this.searchContainer.TextChanged += SearchContainer_TextChanged;
            this.checkAll.Click += CheckAll_Click;
            this.containerList.ItemChecked += ContainerList_ItemChecked;

            containersService = new ContainerServices();
            RefreshContainers();
        }

        private void CheckAll_Click(object? sender, EventArgs e)
        {
            ChangeCheckboxStateForContainers(this.checkAll.Checked);
        }

        private void ContainerList_ItemChecked(object? sender, ItemCheckedEventArgs e)
        {
            if (this.containerList.CheckedItems.Count == this.containerList.Items.Count)
            {
                this.checkAll.Checked = true;
            }
            else
            {
                this.checkAll.Checked = false;
            }
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
            switch (this.navigation.SelectedTab.Name)
            {
                case "containerPage":
                    RefreshContainers();
                    break;
                default:
                    break;
            }
        }

        private void RefreshContainers(bool getFreshData = true)
        {
            string txt = string.Empty;
            var list = new List<ListViewItem>();
            if (getFreshData)
            {
                _containers = containersService.GetContainers();
            }

            _containers = _containers.OrderByDescending(x => x.State);

            containerList.Items.Clear();

            foreach (var item in filter.Length > 0 ? _containers.Where(c => c.Names.IndexOf(this.searchContainer.Text) == 0) : _containers)
            {
                var lvi = new ListViewItem();
                lvi.SubItems.Add(item.Names);
                lvi.SubItems.Add(item.Image);
                lvi.SubItems.Add(item.State.ToString());
                lvi.SubItems.Add(item.Ports);
                lvi.SubItems.Add(item.Status);
                lvi.ImageIndex = GetContainerImage(item.State.Trim().ToLower());
                lvi.ForeColor = item.State.Trim().ToLower() == "exited" ? SystemColors.GrayText : SystemColors.WindowText;
                list.Add(lvi);
            }

            this.containerList.Items.AddRange(list.ToArray());
        }

        private int GetContainerImage(string state)
        {
            switch (state)
            {
                case "exited":
                    return 0;
                case "running":
                    return 1;
                case "paused":
                    return 2;
                default:
                    return 0;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            startContainer();

            RefreshContainers();
        }

        private void startContainer()
        {
            foreach (int index in GetSelectedIndexes())
            {
                if (_containers.ToList()[index].State == "paused")
                {
                    containersService.UnpauseContainer(_containers.ToList()[index].ID);
                }
                else if (_containers.ToList()[index].State != "running")
                {
                    containersService.StartContainer(_containers.ToList()[index].ID);
                }
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            foreach (int index in GetSelectedIndexes())
            {
                containersService.StopContainer(_containers.ToList()[index].ID);
            }

            RefreshContainers();
        }

        private void pause_Click(object sender, EventArgs e)
        {
            foreach (int index in GetSelectedIndexes())
            {
                containersService.PauseContainer(_containers.ToList()[index].ID);
            }

            RefreshContainers();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            foreach (int index in GetSelectedIndexes())
            {
                containersService.DeleteContainer(_containers.ToList()[index].ID);
            }

            RefreshContainers();
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
            var indexes = new List<int>();
            foreach (ListViewItem selectedContainer in this.containerList.CheckedItems)
            {
                indexes.Add(selectedContainer.Index);
            }
            return indexes;
        }

        private void startContainerMenu_Click(object sender, EventArgs e)
        {
            var focusedItem = this.containerList.FocusedItem;
            var index = focusedItem.Index;
            if (_containers.ToList()[index].State == "paused")
            {
                containersService.UnpauseContainer(_containers.ToList()[index].ID);
            }
            else if (_containers.ToList()[index].State != "running")
            {
                containersService.StartContainer(_containers.ToList()[index].ID);
            }

            RefreshContainers();
        }

        private void restartContainerMenu_Click(object sender, EventArgs e)
        {
            var focusedItem = this.containerList.FocusedItem;
            var index = focusedItem.Index;

            containersService.RestartContainer(_containers.ToList()[index].ID);

            RefreshContainers();
        }

        private void stopContainerMenu_Click(object sender, EventArgs e)
        {
            var focusedItem = this.containerList.FocusedItem;
            var index = focusedItem.Index;

            containersService.StopContainer(_containers.ToList()[index].ID);

            RefreshContainers();
        }

        private void pauseContainerMenu_Click(object sender, EventArgs e)
        {
            var focusedItem = this.containerList.FocusedItem;
            var index = focusedItem.Index;

            containersService.PauseContainer(_containers.ToList()[index].ID);

            RefreshContainers();
        }

        private void deleteContainerMenu_Click(object sender, EventArgs e)
        {
            var focusedItem = this.containerList.FocusedItem;
            var index = focusedItem.Index;

            containersService.DeleteContainer(_containers.ToList()[index].ID);

            RefreshContainers();
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
            RefreshContainers(false);
        }
    }
}