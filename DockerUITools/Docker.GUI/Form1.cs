using Docker.Models;
using Docker.Services;
using System;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Docker.GUI
{
    public partial class Form1 : Form
    {
        private IEnumerable<Container> _containers = new List<Container>();
        private readonly ContainerServices containersService;

        public Form1()
        {
            InitializeComponent();
            this.containerList.MouseClick += ContainerList_MouseClick;
            containersService = new ContainerServices();
            RefreshContainers();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void RefreshContainers()
        {
            _containers = containersService.GetContainers();
            string txt = string.Empty;

            var list = new List<ListViewItem>();
            _containers = _containers.OrderByDescending(x => x.State);

            containerList.Items.Clear();

            foreach (var item in _containers)
            {
                var lvi = new ListViewItem();
                lvi.SubItems.Add(item.Names);
                lvi.SubItems.Add(item.Image);
                lvi.SubItems.Add(item.State.ToString());
                lvi.SubItems.Add(item.Ports);
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

        private void containerList_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}