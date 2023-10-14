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
            refresh = new Button();
            containerList = new ListView();
            icon = new ColumnHeader();
            containerName = new ColumnHeader();
            image = new ColumnHeader();
            status = new ColumnHeader();
            ports = new ColumnHeader();
            lastStarted = new ColumnHeader();
            containerStates = new ImageList(components);
            containerContextMenu = new ContextMenuStrip(components);
            startContainerMenu = new ToolStripMenuItem();
            stopContainerMenu = new ToolStripMenuItem();
            pauseContainerMenu = new ToolStripMenuItem();
            deleteContainerMenu = new ToolStripMenuItem();
            restartContainerMenu = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            copyIdContainerMenu = new ToolStripMenuItem();
            navigation = new TabControl();
            containerPage = new TabPage();
            checkAll = new CheckBox();
            searchContainer = new TextBox();
            delete = new Button();
            pause = new Button();
            start = new Button();
            stop = new Button();
            navigationImgs = new ImageList(components);
            containerContextMenu.SuspendLayout();
            navigation.SuspendLayout();
            containerPage.SuspendLayout();
            SuspendLayout();
            // 
            // refresh
            // 
            refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refresh.Location = new Point(1161, 6);
            refresh.Name = "refresh";
            refresh.Size = new Size(105, 42);
            refresh.TabIndex = 0;
            refresh.Text = "Refresh";
            refresh.UseVisualStyleBackColor = true;
            refresh.Click += refresh_Click;
            // 
            // containerList
            // 
            containerList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            containerList.BackColor = SystemColors.GradientInactiveCaption;
            containerList.CheckBoxes = true;
            containerList.Columns.AddRange(new ColumnHeader[] { icon, containerName, image, status, ports, lastStarted });
            containerList.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            containerList.ForeColor = SystemColors.WindowText;
            containerList.FullRowSelect = true;
            containerList.GridLines = true;
            containerList.Location = new Point(6, 58);
            containerList.Name = "containerList";
            containerList.Size = new Size(1260, 421);
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
            containerContextMenu.Items.AddRange(new ToolStripItem[] { startContainerMenu, stopContainerMenu, pauseContainerMenu, deleteContainerMenu, restartContainerMenu, toolStripSeparator1, copyIdContainerMenu });
            containerContextMenu.Name = "ContainerContextMenu";
            containerContextMenu.Size = new Size(196, 154);
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
            // navigation
            // 
            navigation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            navigation.Controls.Add(containerPage);
            navigation.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            navigation.ImageList = navigationImgs;
            navigation.Location = new Point(12, 12);
            navigation.Multiline = true;
            navigation.Name = "navigation";
            navigation.SelectedIndex = 0;
            navigation.Size = new Size(1280, 529);
            navigation.TabIndex = 3;
            // 
            // containerPage
            // 
            containerPage.Controls.Add(checkAll);
            containerPage.Controls.Add(searchContainer);
            containerPage.Controls.Add(refresh);
            containerPage.Controls.Add(containerList);
            containerPage.Controls.Add(delete);
            containerPage.Controls.Add(pause);
            containerPage.Controls.Add(start);
            containerPage.Controls.Add(stop);
            containerPage.Location = new Point(4, 40);
            containerPage.Name = "containerPage";
            containerPage.Padding = new Padding(3);
            containerPage.Size = new Size(1272, 485);
            containerPage.TabIndex = 0;
            containerPage.Text = "Containers";
            containerPage.UseVisualStyleBackColor = true;
            // 
            // checkAll
            // 
            checkAll.AutoSize = true;
            checkAll.Location = new Point(12, 25);
            checkAll.Name = "checkAll";
            checkAll.Size = new Size(18, 17);
            checkAll.TabIndex = 9;
            checkAll.UseVisualStyleBackColor = true;
            // 
            // searchContainer
            // 
            searchContainer.Location = new Point(68, 14);
            searchContainer.Name = "searchContainer";
            searchContainer.Size = new Size(231, 38);
            searchContainer.TabIndex = 8;
            // 
            // delete
            // 
            delete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            delete.BackColor = Color.LightSalmon;
            delete.Location = new Point(563, 6);
            delete.Name = "delete";
            delete.Size = new Size(109, 46);
            delete.TabIndex = 7;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = false;
            delete.Click += delete_Click;
            // 
            // pause
            // 
            pause.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pause.BackColor = SystemColors.GradientActiveCaption;
            pause.Location = new Point(853, 6);
            pause.Name = "pause";
            pause.Size = new Size(87, 46);
            pause.TabIndex = 6;
            pause.Text = "Pause";
            pause.UseVisualStyleBackColor = false;
            pause.Click += pause_Click;
            // 
            // start
            // 
            start.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            start.BackColor = SystemColors.GradientActiveCaption;
            start.Location = new Point(760, 6);
            start.Name = "start";
            start.Size = new Size(87, 46);
            start.TabIndex = 4;
            start.Text = "Start";
            start.UseVisualStyleBackColor = false;
            start.Click += start_Click;
            // 
            // stop
            // 
            stop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stop.BackColor = SystemColors.GradientActiveCaption;
            stop.Location = new Point(946, 6);
            stop.Name = "stop";
            stop.Size = new Size(87, 46);
            stop.TabIndex = 5;
            stop.Text = "Stop";
            stop.UseVisualStyleBackColor = false;
            stop.Click += stop_Click;
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
            ClientSize = new Size(1304, 553);
            Controls.Add(navigation);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Docker Tools";
            containerContextMenu.ResumeLayout(false);
            navigation.ResumeLayout(false);
            containerPage.ResumeLayout(false);
            containerPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button refresh;
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
        private Button delete;
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
    }
}