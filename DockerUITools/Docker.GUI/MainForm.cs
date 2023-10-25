using Docker.Services;

namespace Docker.GUI;

public partial class MainForm : Form
{
    public MainForm()
    {
        containerPage1 = new ContainerPage(new ContainerService());
        imagePage1 = new ImagePage(new ImageService());
        InitializeComponent();
    }
}