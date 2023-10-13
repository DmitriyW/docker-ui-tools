using Docker.Services;
using System.Windows.Forms;

namespace Docker.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            var containersService = new ContainerServices();
            var containers = containersService.GetContainers();
            string txt = string.Empty;

            var list = new List<ListViewItem>();

            containerList.Items.Clear();

            foreach (var item in containers.OrderByDescending(x => x.State))
            {
                var lvi = new ListViewItem();
                lvi.SubItems.Add(item.Names);
                lvi.SubItems.Add(item.Image);
                lvi.SubItems.Add(item.State.ToString());
                lvi.SubItems.Add(item.Ports);
                lvi.ImageIndex = item.State.Trim().ToLower() == "running" ? 1 : 0;
                lvi.ForeColor = item.State.Trim().ToLower() == "running" ? SystemColors.WindowText : SystemColors.GrayText;
                list.Add(lvi);
            }

            this.containerList.Items.AddRange(list.ToArray());
        }

        private void containerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}