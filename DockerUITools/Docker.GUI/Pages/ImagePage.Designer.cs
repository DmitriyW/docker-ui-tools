namespace Docker.GUI.Pages
{
    partial class ImagePage
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
            imageList = new ListView();
            checkImg = new ColumnHeader();
            nameImg = new ColumnHeader();
            tagImg = new ColumnHeader();
            createdImg = new ColumnHeader();
            sizeImg = new ColumnHeader();
            refreshImageList = new Button();
            searchImage = new TextBox();
            checkAll = new CheckBox();
            deleteImage = new Button();
            imageContextMenu = new ContextMenuStrip(components);
            deleteDockerImage = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            copyImageId = new ToolStripMenuItem();
            imageContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // imageList
            // 
            imageList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            imageList.BackColor = SystemColors.GradientInactiveCaption;
            imageList.CheckBoxes = true;
            imageList.Columns.AddRange(new ColumnHeader[] { checkImg, nameImg, tagImg, createdImg, sizeImg });
            imageList.ContextMenuStrip = imageContextMenu;
            imageList.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            imageList.ForeColor = SystemColors.WindowText;
            imageList.FullRowSelect = true;
            imageList.GridLines = true;
            imageList.Location = new Point(5, 63);
            imageList.Margin = new Padding(5);
            imageList.Name = "imageList";
            imageList.Size = new Size(1023, 553);
            imageList.TabIndex = 4;
            imageList.UseCompatibleStateImageBehavior = false;
            imageList.View = View.Details;
            // 
            // checkImg
            // 
            checkImg.Text = "";
            checkImg.Width = 30;
            // 
            // nameImg
            // 
            nameImg.Text = "Name";
            nameImg.Width = 400;
            // 
            // tagImg
            // 
            tagImg.Text = "Tag";
            tagImg.Width = 220;
            // 
            // createdImg
            // 
            createdImg.Text = "Created";
            createdImg.Width = 200;
            // 
            // sizeImg
            // 
            sizeImg.Text = "Size";
            sizeImg.Width = 150;
            // 
            // refreshImageList
            // 
            refreshImageList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshImageList.Location = new Point(859, 7);
            refreshImageList.Margin = new Padding(5);
            refreshImageList.Name = "refreshImageList";
            refreshImageList.Size = new Size(171, 46);
            refreshImageList.TabIndex = 10;
            refreshImageList.Text = "Refresh";
            refreshImageList.UseVisualStyleBackColor = true;
            refreshImageList.Click += refreshImageList_Click;
            // 
            // searchImage
            // 
            searchImage.Location = new Point(38, 12);
            searchImage.Margin = new Padding(5);
            searchImage.Name = "searchImage";
            searchImage.Size = new Size(403, 38);
            searchImage.TabIndex = 10;
            // 
            // checkAll
            // 
            checkAll.AutoSize = true;
            checkAll.Location = new Point(10, 24);
            checkAll.Margin = new Padding(5);
            checkAll.Name = "checkAll";
            checkAll.Size = new Size(18, 17);
            checkAll.TabIndex = 10;
            checkAll.UseVisualStyleBackColor = true;
            // 
            // deleteImage
            // 
            deleteImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteImage.BackColor = Color.LightSalmon;
            deleteImage.Location = new Point(684, 7);
            deleteImage.Name = "deleteImage";
            deleteImage.Size = new Size(109, 46);
            deleteImage.TabIndex = 11;
            deleteImage.Text = "Delete";
            deleteImage.UseVisualStyleBackColor = false;
            deleteImage.Click += deleteImage_Click;
            // 
            // imageContextMenu
            // 
            imageContextMenu.ImageScalingSize = new Size(20, 20);
            imageContextMenu.Items.AddRange(new ToolStripItem[] { deleteDockerImage, toolStripSeparator1, copyImageId });
            imageContextMenu.Name = "imageContextMenu";
            imageContextMenu.Size = new Size(176, 58);
            // 
            // deleteDockerImage
            // 
            deleteDockerImage.Name = "deleteDockerImage";
            deleteDockerImage.Size = new Size(175, 24);
            deleteDockerImage.Text = "Delete";
            deleteDockerImage.Click += deleteDockerImage_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(172, 6);
            // 
            // copyImageId
            // 
            copyImageId.Name = "copyImageId";
            copyImageId.Size = new Size(175, 24);
            copyImageId.Text = "Copy Image Id";
            copyImageId.Click += copyImageId_Click;
            // 
            // ImagePage
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(deleteImage);
            Controls.Add(checkAll);
            Controls.Add(searchImage);
            Controls.Add(refreshImageList);
            Controls.Add(imageList);
            Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "ImagePage";
            Size = new Size(1035, 623);
            imageContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView imageList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button refreshImageList;
        private ColumnHeader checkImg;
        private ColumnHeader nameImg;
        private ColumnHeader tagImg;
        private ColumnHeader createdImg;
        private ColumnHeader sizeImg;
        private TextBox searchImage;
        private CheckBox checkAll;
        private Button deleteImage;
        private ContextMenuStrip imageContextMenu;
        private ToolStripMenuItem deleteDockerImage;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem copyImageId;
    }
}
