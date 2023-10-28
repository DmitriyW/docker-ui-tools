namespace Docker.GUI.Pages
{
    partial class ContainerPage
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerPage));
            selectedGroupLabel = new Label();
            containerGroups = new TreeView();
            searchContainer = new TextBox();
            checkAll = new CheckBox();
            stop = new Button();
            start = new Button();
            refreshContainerList = new Button();
            pause = new Button();
            containerList = new ListView();
            icon = new ColumnHeader();
            containerName = new ColumnHeader();
            image = new ColumnHeader();
            status = new ColumnHeader();
            ports = new ColumnHeader();
            lastStarted = new ColumnHeader();
            message = new ColumnHeader();
            containerStates = new ImageList(components);
            deleteContainer = new Button();
            splitContainer1 = new SplitContainer();
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
            imageList1 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            containerContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // selectedGroupLabel
            // 
            selectedGroupLabel.AutoSize = true;
            selectedGroupLabel.Location = new Point(5, 10);
            selectedGroupLabel.Margin = new Padding(5, 0, 5, 0);
            selectedGroupLabel.Name = "selectedGroupLabel";
            selectedGroupLabel.Size = new Size(177, 31);
            selectedGroupLabel.TabIndex = 11;
            selectedGroupLabel.Text = "Selected Group";
            // 
            // containerGroups
            // 
            containerGroups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            containerGroups.BackColor = SystemColors.GradientInactiveCaption;
            containerGroups.Location = new Point(5, 62);
            containerGroups.Margin = new Padding(5);
            containerGroups.Name = "containerGroups";
            containerGroups.Size = new Size(296, 609);
            containerGroups.TabIndex = 10;
            // 
            // searchContainer
            // 
            searchContainer.Location = new Point(68, 10);
            searchContainer.Margin = new Padding(5);
            searchContainer.Name = "searchContainer";
            searchContainer.Size = new Size(292, 38);
            searchContainer.TabIndex = 8;
            // 
            // checkAll
            // 
            checkAll.AutoSize = true;
            checkAll.Location = new Point(16, 22);
            checkAll.Margin = new Padding(5);
            checkAll.Name = "checkAll";
            checkAll.Size = new Size(18, 17);
            checkAll.TabIndex = 9;
            checkAll.UseVisualStyleBackColor = true;
            // 
            // stop
            // 
            stop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stop.BackColor = SystemColors.GradientActiveCaption;
            stop.Location = new Point(987, 5);
            stop.Margin = new Padding(5);
            stop.Name = "stop";
            stop.Size = new Size(108, 46);
            stop.TabIndex = 5;
            stop.Text = "Stop";
            stop.UseVisualStyleBackColor = false;
            // 
            // start
            // 
            start.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            start.BackColor = SystemColors.GradientActiveCaption;
            start.Location = new Point(751, 5);
            start.Margin = new Padding(5);
            start.Name = "start";
            start.Size = new Size(108, 46);
            start.TabIndex = 4;
            start.Text = "Start";
            start.UseVisualStyleBackColor = false;
            // 
            // refreshContainerList
            // 
            refreshContainerList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshContainerList.Location = new Point(1168, 5);
            refreshContainerList.Margin = new Padding(5);
            refreshContainerList.Name = "refreshContainerList";
            refreshContainerList.Size = new Size(118, 46);
            refreshContainerList.TabIndex = 0;
            refreshContainerList.Text = "Refresh";
            refreshContainerList.UseVisualStyleBackColor = true;
            // 
            // pause
            // 
            pause.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pause.BackColor = SystemColors.GradientActiveCaption;
            pause.Location = new Point(869, 5);
            pause.Margin = new Padding(5);
            pause.Name = "pause";
            pause.Size = new Size(108, 46);
            pause.TabIndex = 6;
            pause.Text = "Pause";
            pause.UseVisualStyleBackColor = false;
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
            containerList.Location = new Point(5, 62);
            containerList.Margin = new Padding(5);
            containerList.Name = "containerList";
            containerList.Size = new Size(1281, 609);
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
            // deleteContainer
            // 
            deleteContainer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteContainer.BackColor = Color.LightSalmon;
            deleteContainer.Location = new Point(604, 6);
            deleteContainer.Margin = new Padding(5);
            deleteContainer.Name = "deleteContainer";
            deleteContainer.Size = new Size(103, 46);
            deleteContainer.TabIndex = 7;
            deleteContainer.Text = "Delete";
            deleteContainer.UseVisualStyleBackColor = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(5, 5);
            splitContainer1.Margin = new Padding(5);
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
            splitContainer1.Size = new Size(1603, 678);
            splitContainer1.SplitterDistance = 310;
            splitContainer1.SplitterWidth = 7;
            splitContainer1.TabIndex = 11;
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
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "2312798.png");
            imageList1.Images.SetKeyName(1, "2312889.png");
            imageList1.Images.SetKeyName(2, "oie_transparent.png");
            // 
            // ContainerPage
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "ContainerPage";
            Size = new Size(1618, 687);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            containerContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label selectedGroupLabel;
        private TreeView containerGroups;
        private TextBox searchContainer;
        private CheckBox checkAll;
        private Button stop;
        private Button start;
        private Button refreshContainerList;
        private Button pause;
        private ListView containerList;
        private ColumnHeader icon;
        private ColumnHeader containerName;
        private ColumnHeader image;
        private ColumnHeader status;
        private ColumnHeader ports;
        private ColumnHeader lastStarted;
        private ColumnHeader message;
        private ImageList containerStates;
        private Button deleteContainer;
        private SplitContainer splitContainer1;
        private ContextMenuStrip containerContextMenu;
        private ToolStripMenuItem startContainerMenu;
        private ToolStripMenuItem stopContainerMenu;
        private ToolStripMenuItem pauseContainerMenu;
        private ToolStripMenuItem deleteContainerMenu;
        private ToolStripMenuItem restartContainerMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem copyIdContainerMenu;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem viewLogs;
        private ImageList imageList1;
    }
}
