using Docker.Abstractions.Services;

namespace Docker.GUI;

public partial class MainForm : Form
{
    public MainForm()
    {
        Program.GetService<IContainerService>();
        containerPageUC = new ContainerPage(Program.GetService<IContainerService>());
        imagePageUC = new ImagePage(Program.GetService<IImageService>());
        InitializeComponent();
    }
}