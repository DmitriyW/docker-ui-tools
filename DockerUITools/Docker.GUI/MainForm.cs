using Docker.Abstractions.Services;

namespace Docker.GUI;

public partial class MainForm : Form
{
    public MainForm()
    {
        Program.GetService<IContainerService>();
        containerPage1 = new ContainerPage(Program.GetService<IContainerService>());
        imagePage1 = new ImagePage(Program.GetService<IImageService>());
        InitializeComponent();
    }
}