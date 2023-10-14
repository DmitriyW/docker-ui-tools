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
            containerStates = new ImageList(components);
            navigation = new TabControl();
            containerPage = new TabPage();
            imagePage = new TabPage();
            volumePage = new TabPage();
            navigationImgs = new ImageList(components);
            start = new Button();
            stop = new Button();
            pause = new Button();
            delete = new Button();
            navigation.SuspendLayout();
            containerPage.SuspendLayout();
            SuspendLayout();
            // 
            // refresh
            // 
            refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refresh.Location = new Point(1078, 12);
            refresh.Name = "refresh";
            refresh.Size = new Size(105, 42);
            refresh.TabIndex = 0;
            refresh.Text = "Refresh";
            refresh.UseVisualStyleBackColor = true;
            refresh.Click += button1_Click;
            // 
            // containerList
            // 
            containerList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            containerList.BackColor = SystemColors.GradientInactiveCaption;
            containerList.CheckBoxes = true;
            containerList.Columns.AddRange(new ColumnHeader[] { icon, containerName, image, status, ports });
            containerList.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            containerList.ForeColor = SystemColors.WindowText;
            containerList.FullRowSelect = true;
            containerList.GridLines = true;
            containerList.Location = new Point(6, 6);
            containerList.Name = "containerList";
            containerList.Size = new Size(1152, 412);
            containerList.SmallImageList = containerStates;
            containerList.TabIndex = 2;
            containerList.UseCompatibleStateImageBehavior = false;
            containerList.View = View.Details;
            containerList.SelectedIndexChanged += containerList_SelectedIndexChanged;
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
            // containerStates
            // 
            containerStates.ColorDepth = ColorDepth.Depth32Bit;
            containerStates.ImageStream = (ImageListStreamer)resources.GetObject("containerStates.ImageStream");
            containerStates.TransparentColor = Color.Transparent;
            containerStates.Images.SetKeyName(0, "2312798.png");
            containerStates.Images.SetKeyName(1, "2312889.png");
            containerStates.Images.SetKeyName(2, "oie_transparent.png");
            // 
            // navigation
            // 
            navigation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            navigation.Controls.Add(containerPage);
            navigation.Controls.Add(imagePage);
            navigation.Controls.Add(volumePage);
            navigation.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            navigation.ImageList = navigationImgs;
            navigation.Location = new Point(12, 60);
            navigation.Multiline = true;
            navigation.Name = "navigation";
            navigation.SelectedIndex = 0;
            navigation.Size = new Size(1172, 468);
            navigation.TabIndex = 3;
            // 
            // containerPage
            // 
            containerPage.Controls.Add(containerList);
            containerPage.Location = new Point(4, 40);
            containerPage.Name = "containerPage";
            containerPage.Padding = new Padding(3);
            containerPage.Size = new Size(1164, 424);
            containerPage.TabIndex = 0;
            containerPage.Text = "Containers";
            containerPage.UseVisualStyleBackColor = true;
            // 
            // imagePage
            // 
            imagePage.Location = new Point(4, 40);
            imagePage.Name = "imagePage";
            imagePage.Padding = new Padding(3);
            imagePage.Size = new Size(1164, 424);
            imagePage.TabIndex = 1;
            imagePage.Text = "Images";
            imagePage.UseVisualStyleBackColor = true;
            // 
            // volumePage
            // 
            volumePage.Location = new Point(4, 40);
            volumePage.Name = "volumePage";
            volumePage.Padding = new Padding(3);
            volumePage.Size = new Size(1164, 424);
            volumePage.TabIndex = 2;
            volumePage.Text = "Volumes";
            volumePage.UseVisualStyleBackColor = true;
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
            // start
            // 
            start.Location = new Point(598, 12);
            start.Name = "start";
            start.Size = new Size(70, 42);
            start.TabIndex = 4;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // stop
            // 
            stop.Location = new Point(750, 12);
            stop.Name = "stop";
            stop.Size = new Size(70, 42);
            stop.TabIndex = 5;
            stop.Text = "Stop";
            stop.UseVisualStyleBackColor = true;
            stop.Click += stop_Click;
            // 
            // pause
            // 
            pause.Location = new Point(674, 12);
            pause.Name = "pause";
            pause.Size = new Size(70, 42);
            pause.TabIndex = 6;
            pause.Text = "Pause";
            pause.UseVisualStyleBackColor = true;
            pause.Click += pause_Click;
            // 
            // delete
            // 
            delete.Location = new Point(876, 12);
            delete.Name = "delete";
            delete.Size = new Size(70, 42);
            delete.TabIndex = 7;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 540);
            Controls.Add(delete);
            Controls.Add(pause);
            Controls.Add(stop);
            Controls.Add(start);
            Controls.Add(navigation);
            Controls.Add(refresh);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Docker Tools";
            navigation.ResumeLayout(false);
            containerPage.ResumeLayout(false);
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
        private TabPage imagePage;
        private ImageList navigationImgs;
        private TabPage volumePage;
        private Button start;
        private Button stop;
        private Button pause;
        private Button delete;
    }
}