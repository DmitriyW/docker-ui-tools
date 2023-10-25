namespace Docker.GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            icon = new ColumnHeader();
            containerName = new ColumnHeader();
            image = new ColumnHeader();
            status = new ColumnHeader();
            ports = new ColumnHeader();
            lastStarted = new ColumnHeader();
            message = new ColumnHeader();
            containerStates = new ImageList(components);
            containerContextMenu = new ContextMenuStrip(components);
            startContainerMenu = new ToolStripMenuItem();
            stopContainerMenu = new ToolStripMenuItem();
            pauseContainerMenu = new ToolStripMenuItem();
            deleteContainerMenu = new ToolStripMenuItem();
            restartContainerMenu = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            copyIdContainerMenu = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            viewLogs = new ToolStripMenuItem();
            navigation = new TabControl();
            containerPage = new TabPage();
            imagePage = new TabPage();
            navigationImgs = new ImageList(components);
            containerContextMenu.SuspendLayout();
            navigation.SuspendLayout();
            containerPage.SuspendLayout();
            imagePage.SuspendLayout();
            SuspendLayout();
            // 
            // icon
            // 
            icon.Text = "";
            // 
            // containerName
            // 
            containerName.Text = "Name";
            containerName.Width = 230;
            // 
            // image
            // 
            image.Text = "Image";
            image.Width = 320;
            // 
            // status
            // 
            status.Text = "Status";
            status.Width = 120;
            // 
            // ports
            // 
            ports.Text = "Ports";
            ports.Width = 300;
            // 
            // lastStarted
            // 
            lastStarted.Text = "LastStarted";
            lastStarted.Width = 200;
            // 
            // message
            // 
            message.Text = "Message";
            message.Width = 300;
            // 
            // containerStates
            // 
            containerStates.ColorDepth = ColorDepth.Depth32Bit;
            containerStates.ImageStream = (ImageListStreamer)resources.GetObject("containerStates.ImageStream");
            containerStates.TransparentColor = Color.Transparent;
            containerStates.Images.SetKeyName(0, "2312798.png");
            containerStates.Images.SetKeyName(1, "2312889.png");
            containerStates.Images.SetKeyName(2, "oie_transparent.png");
            // 
            // containerContextMenu
            // 
            containerContextMenu.ImageScalingSize = new Size(20, 20);
            containerContextMenu.Items.AddRange(new ToolStripItem[] { startContainerMenu, stopContainerMenu, pauseContainerMenu, deleteContainerMenu, restartContainerMenu, toolStripSeparator1, copyIdContainerMenu, toolStripSeparator2, viewLogs });
            containerContextMenu.Name = "ContainerContextMenu";
            containerContextMenu.Size = new Size(196, 184);
            // 
            // startContainerMenu
            // 
            startContainerMenu.Name = "startContainerMenu";
            startContainerMenu.Size = new Size(195, 24);
            startContainerMenu.Text = "Start";
            // 
            // stopContainerMenu
            // 
            stopContainerMenu.Name = "stopContainerMenu";
            stopContainerMenu.Size = new Size(195, 24);
            stopContainerMenu.Text = "Stop";
            // 
            // pauseContainerMenu
            // 
            pauseContainerMenu.Name = "pauseContainerMenu";
            pauseContainerMenu.Size = new Size(195, 24);
            pauseContainerMenu.Text = "Pause";
            // 
            // deleteContainerMenu
            // 
            deleteContainerMenu.Name = "deleteContainerMenu";
            deleteContainerMenu.Size = new Size(195, 24);
            deleteContainerMenu.Text = "Delete";
            // 
            // restartContainerMenu
            // 
            restartContainerMenu.Name = "restartContainerMenu";
            restartContainerMenu.Size = new Size(195, 24);
            restartContainerMenu.Text = "Restart";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(192, 6);
            // 
            // copyIdContainerMenu
            // 
            copyIdContainerMenu.Name = "copyIdContainerMenu";
            copyIdContainerMenu.Size = new Size(195, 24);
            copyIdContainerMenu.Text = "Copy container Id";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(192, 6);
            // 
            // viewLogs
            // 
            viewLogs.Name = "viewLogs";
            viewLogs.Size = new Size(195, 24);
            viewLogs.Text = "View Logs";
            // 
            // navigation
            // 
            navigation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            navigation.Controls.Add(containerPage);
            navigation.Controls.Add(imagePage);
            navigation.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            navigation.ImageList = navigationImgs;
            navigation.Location = new Point(12, 12);
            navigation.Multiline = true;
            navigation.Name = "navigation";
            navigation.SelectedIndex = 0;
            navigation.Size = new Size(1593, 744);
            navigation.TabIndex = 3;
            // 
            // containerPage
            // 
            containerPage.Controls.Add(containerPageUC);
            containerPage.Location = new Point(4, 40);
            containerPage.Name = "containerPage";
            containerPage.Padding = new Padding(3);
            containerPage.Size = new Size(1585, 700);
            containerPage.TabIndex = 0;
            containerPage.Text = "Containers";
            containerPage.UseVisualStyleBackColor = true;
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
            // 
            // imagePage
            // 
            imagePage.Controls.Add(imagePageUC);
            imagePage.Location = new Point(4, 40);
            imagePage.Name = "imagePage";
            imagePage.Padding = new Padding(3);
            imagePage.Size = new Size(1593, 699);
            imagePage.TabIndex = 1;
            imagePage.Text = "Images";
            imagePage.UseVisualStyleBackColor = true;
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
            // 
            // navigationImgs
            // 
            navigationImgs.ColorDepth = ColorDepth.Depth32Bit;
            navigationImgs.ImageStream = (ImageListStreamer)resources.GetObject("navigationImgs.ImageStream");
            navigationImgs.TransparentColor = Color.Transparent;
            navigationImgs.Images.SetKeyName(0, "8754c45c0adf4780dabf04f1bd6684af.jpg");
            navigationImgs.Images.SetKeyName(1, "860068.png");
            navigationImgs.Images.SetKeyName(2, "860142.png");
            navigationImgs.Images.SetKeyName(3, "255-2553250_icon-docker-notext-color-docker-icon-png-transparent.png");
            navigationImgs.Images.SetKeyName(4, "831845.png");
            navigationImgs.Images.SetKeyName(5, "878943_media_512x512.png");
            navigationImgs.Images.SetKeyName(6, "4844483.png");
            navigationImgs.Images.SetKeyName(7, "docker_icon_132435.png");
            navigationImgs.Images.SetKeyName(8, "docker_icon_138669.png");
            navigationImgs.Images.SetKeyName(9, "image_processing20210616-28547-1u2ox9e.png");
            navigationImgs.Images.SetKeyName(10, "png-transparent-docker-computer-icons-logo-others-miscellaneous-text-logo.png");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1617, 768);
            Controls.Add(navigation);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Docker Tools";
            containerContextMenu.ResumeLayout(false);
            navigation.ResumeLayout(false);
            containerPage.ResumeLayout(false);
            imagePage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ColumnHeader containerName;
        private ColumnHeader image;
        private ColumnHeader status;
        private ColumnHeader ports;
        private ColumnHeader icon;
        private ImageList containerStates;
        private TabControl navigation;
        private TabPage containerPage;
        private ImageList navigationImgs;
        private ContextMenuStrip containerContextMenu;
        private ToolStripMenuItem startContainerMenu;
        private ToolStripMenuItem stopContainerMenu;
        private ToolStripMenuItem pauseContainerMenu;
        private ToolStripMenuItem deleteContainerMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem copyIdContainerMenu;
        private ToolStripMenuItem restartContainerMenu;
        private ColumnHeader lastStarted;
        private TabPage imagePage;
        private ImagePage imagePageUC;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem viewLogs;
        private ColumnHeader message;
        private ContainerPage containerPageUC;
    }
}