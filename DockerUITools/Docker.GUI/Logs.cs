using Docker.Services;

namespace Docker.GUI
{
    public partial class Logs : Form
    {
        private readonly ContainerServices containersService;
        private readonly string containerId;

        public Logs(string containerId, string name)
        {
            InitializeComponent();
            this.Text = name;

            containersService = new ContainerServices();
            this.containerId = containerId;
            ShowLogs();
        }

        private async Task ShowLogs()
        {
            var logs = new Action<string>(x =>
            {
                this.logTextBox.Text = x;
            });
            await containersService.GetContainerLogsAsync(new Progress<string>(logs), this.containerId);
        }

        private void refreshLogs_Click(object sender, EventArgs e)
        {
            ShowLogs();
        }
    }
}
