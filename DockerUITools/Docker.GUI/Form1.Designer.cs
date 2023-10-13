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
            button1 = new Button();
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
            navigationImgs = new ImageList(components);
            volumePage = new TabPage();
            navigation.SuspendLayout();
            containerPage.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(1078, 12);
            button1.Name = "button1";
            button1.Size = new Size(105, 42);
            button1.TabIndex = 0;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // containerList
            // 
            containerList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            containerList.BackColor = SystemColors.GradientInactiveCaption;
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
            icon.Width = 40;
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
            containerPage.ImageIndex = 1;
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
            imagePage.ImageIndex = 5;
            imagePage.Location = new Point(4, 29);
            imagePage.Name = "imagePage";
            imagePage.Padding = new Padding(3);
            imagePage.Size = new Size(437, 211);
            imagePage.TabIndex = 1;
            imagePage.Text = "Images";
            imagePage.UseVisualStyleBackColor = true;
            // 
            // navigationImgs
            // 
            navigationImgs.ColorDepth = ColorDepth.Depth8Bit;
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
            // volumePage
            // 
            volumePage.ImageIndex = 4;
            volumePage.Location = new Point(4, 29);
            volumePage.Name = "volumePage";
            volumePage.Padding = new Padding(3);
            volumePage.Size = new Size(437, 211);
            volumePage.TabIndex = 2;
            volumePage.Text = "Volumes";
            volumePage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 540);
            Controls.Add(navigation);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Docker Tools";
            navigation.ResumeLayout(false);
            containerPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
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
    }
}