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
            var containersService = new ContainerServices();
            var containers = containersService.GetContainers();
            string txt = string.Empty;

            var list = new List<ListViewItem>();

            containerList.Items.Clear();

            foreach (var item in containers)
            {
                var lvi = new ListViewItem(item.Names);
                lvi.SubItems.Add(item.Image);
                lvi.SubItems.Add(item.State);
                lvi.SubItems.Add(item.Ports);
                list.Add(lvi);
            }

            containerList.Items.AddRange(list.ToArray());
        }
    }
}