using Docker.Abstractions.Services;

namespace Docker.GUI.Pages;

public partial class MainForm : Form
{
    private ContainerPage containerPageUC;
    private ImagePage imagePageUC;
    private VolumePage volumePageUC;

    public MainForm()
    {
        InitControls();
        InitializeComponent();
        AddControls();
    }

    private void InitControls()
    {
        containerPageUC = new ContainerPage(Program.GetService<IContainerService>());
        ConfigContainerPage();
        imagePageUC = new ImagePage(Program.GetService<IImageService>());
        ConfigImagePageUC();
        volumePageUC = new VolumePage(Program.GetService<IVolumeService>());
        ConfigVolumePageUC();
    }

    private void ConfigContainerPage()
    {
        // 
        // containerPageUC
        // 
        containerPageUC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        containerPageUC.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
        containerPageUC.Location = new Point(8, 8);
        containerPageUC.Margin = new Padding(5);
        containerPageUC.Name = "containerPage1";
        containerPageUC.Size = new Size(1569, 687);
        containerPageUC.TabIndex = 0;
    }

    private void ConfigImagePageUC()
    {
        // 
        // imagePageUC
        // 
        imagePageUC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        imagePageUC.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
        imagePageUC.Location = new Point(8, 8);
        imagePageUC.Margin = new Padding(5);
        imagePageUC.Name = "imagePage1";
        imagePageUC.Size = new Size(1577, 683);
        imagePageUC.TabIndex = 0;
    }

    private void ConfigVolumePageUC()
    {
        // 
        // volumePageUC
        // 
        volumePageUC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        volumePageUC.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
        volumePageUC.Location = new Point(8, 8);
        volumePageUC.Margin = new Padding(5);
        volumePageUC.Name = "volumePage1";
        volumePageUC.Size = new Size(1573, 679);
        volumePageUC.TabIndex = 0;
    }

    private void AddControls()
    {
        containerTab.Controls.Add(containerPageUC);
        imageTab.Controls.Add(imagePageUC);
        volumeTab.Controls.Add(volumePageUC);
    }
}