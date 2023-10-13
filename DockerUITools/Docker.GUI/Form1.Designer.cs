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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            containerList = new ListView();
            containerName = new ColumnHeader();
            image = new ColumnHeader();
            status = new ColumnHeader();
            ports = new ColumnHeader();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(741, 12);
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
            containerList.Columns.AddRange(new ColumnHeader[] { containerName, image, status, ports });
            containerList.FullRowSelect = true;
            containerList.GridLines = true;
            containerList.Location = new Point(12, 60);
            containerList.Name = "containerList";
            containerList.Size = new Size(834, 441);
            containerList.TabIndex = 2;
            containerList.UseCompatibleStateImageBehavior = false;
            containerList.View = View.Details;
            // 
            // containerName
            // 
            containerName.Text = "Name";
            containerName.Width = 200;
            // 
            // image
            // 
            image.Text = "Image";
            image.Width = 280;
            // 
            // status
            // 
            status.Text = "Status";
            status.Width = 100;
            // 
            // ports
            // 
            ports.Text = "Ports";
            ports.Width = 220;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 513);
            Controls.Add(containerList);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Docker Tools";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ListView containerList;
        private ColumnHeader containerName;
        private ColumnHeader image;
        private ColumnHeader status;
        private ColumnHeader ports;
    }
}