namespace Docker.GUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            refreshContainerList = new Button();
            containerList = new ListView();
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
            splitContainer1 = new SplitContainer();
            selectedGroupLabel = new Label();
            containerGroups = new TreeView();
            searchContainer = new TextBox();
            checkAll = new CheckBox();
            stop = new Button();
            start = new Button();
            pause = new Button();
            deleteContainer = new Button();
            imagePage = new TabPage();
            imagePage1 = new ImagePage();
            navigationImgs = new ImageList(components);
            containerContextMenu.SuspendLayout();
            navigation.SuspendLayout();
            containerPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            imagePage.SuspendLayout();
            SuspendLayout();
            // 
            // refreshContainerList
            // 
            refreshContainerList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshContainerList.Location = new Point(1161, 3);
            refreshContainerList.Name = "refreshContainerList";
            refreshContainerList.Size = new Size(105, 42);
            refreshContainerList.TabIndex = 0;
            refreshContainerList.Text = "Refresh";
            refreshContainerList.UseVisualStyleBackColor = true;
            refreshContainerList.Click += refresh_Click;
            // 
            // containerList
            // 
            containerList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            containerList.BackColor = SystemColors.GradientInactiveCaption;
            containerList.CheckBoxes = true;
            containerList.Columns.AddRange(new ColumnHeader[] { icon, containerName, image, status, ports, lastStarted, message });
            containerList.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            containerList.ForeColor = SystemColors.WindowText;
            containerList.FullRowSelect = true;
            containerList.GridLines = true;
            containerList.Location = new Point(3, 55);
            containerList.Name = "containerList";
            containerList.Size = new Size(1263, 629);
            containerList.SmallImageList = containerStates;
            containerList.TabIndex = 2;
            containerList.UseCompatibleStateImageBehavior = false;
            containerList.View = View.Details;
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
            startContainerMenu.Click += startContainerMenu_Click;
            // 
            // stopContainerMenu
            // 
            stopContainerMenu.Name = "stopContainerMenu";
            stopContainerMenu.Size = new Size(195, 24);
            stopContainerMenu.Text = "Stop";
            stopContainerMenu.Click += stopContainerMenu_Click;
            // 
            // pauseContainerMenu
            // 
            pauseContainerMenu.Name = "pauseContainerMenu";
            pauseContainerMenu.Size = new Size(195, 24);
            pauseContainerMenu.Text = "Pause";
            pauseContainerMenu.Click += pauseContainerMenu_Click;
            // 
            // deleteContainerMenu
            // 
            deleteContainerMenu.Name = "deleteContainerMenu";
            deleteContainerMenu.Size = new Size(195, 24);
            deleteContainerMenu.Text = "Delete";
            deleteContainerMenu.Click += deleteContainerMenu_Click;
            // 
            // restartContainerMenu
            // 
            restartContainerMenu.Name = "restartContainerMenu";
            restartContainerMenu.Size = new Size(195, 24);
            restartContainerMenu.Text = "Restart";
            restartContainerMenu.Click += restartContainerMenu_Click;
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
            copyIdContainerMenu.Click += copyIdContainerMenu_Click;
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
            viewLogs.Click += viewLogs_Click;
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
            navigation.Size = new Size(1601, 743);
            navigation.TabIndex = 3;
            // 
            // containerPage
            // 
            containerPage.Controls.Add(splitContainer1);
            containerPage.Location = new Point(4, 40);
            containerPage.Name = "containerPage";
            containerPage.Padding = new Padding(3);
            containerPage.Size = new Size(1593, 699);
            containerPage.TabIndex = 0;
            containerPage.Text = "Containers";
            containerPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(6, 6);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(selectedGroupLabel);
            splitContainer1.Panel1.Controls.Add(containerGroups);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(searchContainer);
            splitContainer1.Panel2.Controls.Add(checkAll);
            splitContainer1.Panel2.Controls.Add(stop);
            splitContainer1.Panel2.Controls.Add(start);
            splitContainer1.Panel2.Controls.Add(refreshContainerList);
            splitContainer1.Panel2.Controls.Add(pause);
            splitContainer1.Panel2.Controls.Add(containerList);
            splitContainer1.Panel2.Controls.Add(deleteContainer);
            splitContainer1.Size = new Size(1581, 687);
            splitContainer1.SplitterDistance = 308;
            splitContainer1.TabIndex = 11;
            // 
            // selectedGroupLabel
            // 
            selectedGroupLabel.AutoSize = true;
            selectedGroupLabel.Location = new Point(3, 14);
            selectedGroupLabel.Name = "selectedGroupLabel";
            selectedGroupLabel.Size = new Size(174, 31);
            selectedGroupLabel.TabIndex = 11;
            selectedGroupLabel.Text = "Selected Group";
            // 
            // containerGroups
            // 
            containerGroups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            containerGroups.BackColor = SystemColors.GradientInactiveCaption;
            containerGroups.Location = new Point(3, 55);
            containerGroups.Name = "containerGroups";
            containerGroups.Size = new Size(302, 629);
            containerGroups.TabIndex = 10;
            // 
            // searchContainer
            // 
            searchContainer.Location = new Point(65, 11);
            searchContainer.Name = "searchContainer";
            searchContainer.Size = new Size(231, 38);
            searchContainer.TabIndex = 8;
            // 
            // checkAll
            // 
            checkAll.AutoSize = true;
            checkAll.Location = new Point(9, 22);
            checkAll.Name = "checkAll";
            checkAll.Size = new Size(18, 17);
            checkAll.TabIndex = 9;
            checkAll.UseVisualStyleBackColor = true;
            // 
            // stop
            // 
            stop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stop.BackColor = SystemColors.GradientActiveCaption;
            stop.Location = new Point(946, 3);
            stop.Name = "stop";
            stop.Size = new Size(87, 46);
            stop.TabIndex = 5;
            stop.Text = "Stop";
            stop.UseVisualStyleBackColor = false;
            stop.Click += stop_Click;
            // 
            // start
            // 
            start.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            start.BackColor = SystemColors.GradientActiveCaption;
            start.Location = new Point(760, 3);
            start.Name = "start";
            start.Size = new Size(87, 46);
            start.TabIndex = 4;
            start.Text = "Start";
            start.UseVisualStyleBackColor = false;
            start.Click += start_Click;
            // 
            // pause
            // 
            pause.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pause.BackColor = SystemColors.GradientActiveCaption;
            pause.Location = new Point(853, 3);
            pause.Name = "pause";
            pause.Size = new Size(87, 46);
            pause.TabIndex = 6;
            pause.Text = "Pause";
            pause.UseVisualStyleBackColor = false;
            pause.Click += pause_Click;
            // 
            // deleteContainer
            // 
            deleteContainer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteContainer.BackColor = Color.LightSalmon;
            deleteContainer.Location = new Point(563, 3);
            deleteContainer.Name = "deleteContainer";
            deleteContainer.Size = new Size(109, 46);
            deleteContainer.TabIndex = 7;
            deleteContainer.Text = "Delete";
            deleteContainer.UseVisualStyleBackColor = false;
            deleteContainer.Click += delete_Click;
            // 
            // imagePage
            // 
            imagePage.Controls.Add(imagePage1);
            imagePage.Location = new Point(4, 40);
            imagePage.Name = "imagePage";
            imagePage.Padding = new Padding(3);
            imagePage.Size = new Size(1593, 699);
            imagePage.TabIndex = 1;
            imagePage.Text = "Images";
            imagePage.UseVisualStyleBackColor = true;
            // 
            // imagePage1
            // 
            imagePage1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            imagePage1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            imagePage1.Location = new Point(8, 8);
            imagePage1.Margin = new Padding(5);
            imagePage1.Name = "imagePage1";
            imagePage1.Size = new Size(1577, 683);
            imagePage1.TabIndex = 0;
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
            ClientSize = new Size(1625, 767);
            Controls.Add(navigation);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Docker Tools";
            containerContextMenu.ResumeLayout(false);
            navigation.ResumeLayout(false);
            containerPage.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            imagePage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button refreshContainerList;
        private ListView containerList;
        private ColumnHeader containerName;
        private ColumnHeader image;
        private ColumnHeader status;
        private ColumnHeader ports;
        private ColumnHeader icon;
        private ImageList containerStates;
        private TabControl navigation;
        private TabPage containerPage;
        private ImageList navigationImgs;
        private Button start;
        private Button stop;
        private Button pause;
        private Button deleteContainer;
        private ContextMenuStrip containerContextMenu;
        private ToolStripMenuItem startContainerMenu;
        private ToolStripMenuItem stopContainerMenu;
        private ToolStripMenuItem pauseContainerMenu;
        private ToolStripMenuItem deleteContainerMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem copyIdContainerMenu;
        private TextBox searchContainer;
        private ToolStripMenuItem restartContainerMenu;
        private ColumnHeader lastStarted;
        private CheckBox checkAll;
        private TabPage imagePage;
        private ImagePage imagePage1;
        private TreeView containerGroups;
        private SplitContainer splitContainer1;
        private Label selectedGroupLabel;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem viewLogs;
        private ColumnHeader message;
    }
}