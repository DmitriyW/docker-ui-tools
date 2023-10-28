namespace Docker.GUI
{
    partial class VolumePage
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
            volumeList = new ListView();
            checkVolume = new ColumnHeader();
            nameVolume = new ColumnHeader();
            sizeVolume = new ColumnHeader();
            volumeContextMenu = new ContextMenuStrip(components);
            deleteDockerVolume = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            copyVolumeName = new ToolStripMenuItem();
            deleteVolume = new Button();
            checkAll = new CheckBox();
            searchVolume = new TextBox();
            refreshVolumeList = new Button();
            volumeContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // volumeList
            // 
            volumeList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            volumeList.BackColor = SystemColors.GradientInactiveCaption;
            volumeList.CheckBoxes = true;
            volumeList.Columns.AddRange(new ColumnHeader[] { checkVolume, nameVolume, sizeVolume });
            volumeList.ContextMenuStrip = volumeContextMenu;
            volumeList.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            volumeList.ForeColor = SystemColors.WindowText;
            volumeList.FullRowSelect = true;
            volumeList.GridLines = true;
            volumeList.Location = new Point(0, 57);
            volumeList.Margin = new Padding(8);
            volumeList.Name = "volumeList";
            volumeList.Size = new Size(904, 297);
            volumeList.TabIndex = 12;
            volumeList.UseCompatibleStateImageBehavior = false;
            volumeList.View = View.Details;
            // 
            // checkVolume
            // 
            checkVolume.Text = "";
            checkVolume.Width = 30;
            // 
            // nameVolume
            // 
            nameVolume.Text = "Name";
            nameVolume.Width = 650;
            // 
            // sizeVolume
            // 
            sizeVolume.Text = "Size";
            sizeVolume.Width = 150;
            // 
            // volumeContextMenu
            // 
            volumeContextMenu.ImageScalingSize = new Size(20, 20);
            volumeContextMenu.Items.AddRange(new ToolStripItem[] { deleteDockerVolume, toolStripSeparator1, copyVolumeName });
            volumeContextMenu.Name = "imageContextMenu";
            volumeContextMenu.Size = new Size(211, 58);
            // 
            // deleteDockerVolume
            // 
            deleteDockerVolume.Name = "deleteDockerVolume";
            deleteDockerVolume.Size = new Size(210, 24);
            deleteDockerVolume.Text = "Delete";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(207, 6);
            // 
            // copyVolumeName
            // 
            copyVolumeName.Name = "copyVolumeName";
            copyVolumeName.Size = new Size(210, 24);
            copyVolumeName.Text = "Copy Volume Name";
            // 
            // deleteVolume
            // 
            deleteVolume.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteVolume.BackColor = Color.LightSalmon;
            deleteVolume.Location = new Point(594, 8);
            deleteVolume.Margin = new Padding(5);
            deleteVolume.Name = "deleteVolume";
            deleteVolume.Size = new Size(109, 46);
            deleteVolume.TabIndex = 16;
            deleteVolume.Text = "Delete";
            deleteVolume.UseVisualStyleBackColor = false;
            // 
            // checkAll
            // 
            checkAll.AutoSize = true;
            checkAll.Location = new Point(11, 24);
            checkAll.Margin = new Padding(8);
            checkAll.Name = "checkAll";
            checkAll.Size = new Size(18, 17);
            checkAll.TabIndex = 13;
            checkAll.UseVisualStyleBackColor = true;
            // 
            // searchVolume
            // 
            searchVolume.Location = new Point(34, 13);
            searchVolume.Margin = new Padding(8);
            searchVolume.Name = "searchVolume";
            searchVolume.Size = new Size(525, 38);
            searchVolume.TabIndex = 14;
            // 
            // refreshVolumeList
            // 
            refreshVolumeList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshVolumeList.Location = new Point(733, 8);
            refreshVolumeList.Margin = new Padding(8);
            refreshVolumeList.Name = "refreshVolumeList";
            refreshVolumeList.Size = new Size(171, 46);
            refreshVolumeList.TabIndex = 15;
            refreshVolumeList.Text = "Refresh";
            refreshVolumeList.UseVisualStyleBackColor = true;
            // 
            // VolumePage
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(volumeList);
            Controls.Add(deleteVolume);
            Controls.Add(checkAll);
            Controls.Add(searchVolume);
            Controls.Add(refreshVolumeList);
            Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "VolumePage";
            Size = new Size(907, 356);
            volumeContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView volumeList;
        private ColumnHeader checkVolume;
        private ColumnHeader nameVolume;
        private ColumnHeader sizeVolume;
        private ContextMenuStrip volumeContextMenu;
        private ToolStripMenuItem deleteDockerVolume;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem copyVolumeName;
        private Button deleteVolume;
        private CheckBox checkAll;
        private TextBox searchVolume;
        private Button refreshVolumeList;
    }
}
