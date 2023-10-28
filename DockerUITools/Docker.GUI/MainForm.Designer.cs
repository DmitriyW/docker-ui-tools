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
            navigation = new TabControl();
            containerTab = new TabPage();
            imageTab = new TabPage();
            volumeTab = new TabPage();
            navigation.SuspendLayout();
            SuspendLayout();
            
            // 
            // navigation
            // 
            navigation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            navigation.Controls.Add(containerTab);
            navigation.Controls.Add(imageTab);
            navigation.Controls.Add(volumeTab);
            navigation.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            navigation.Location = new Point(12, 12);
            navigation.Multiline = true;
            navigation.Name = "navigation";
            navigation.SelectedIndex = 0;
            navigation.Size = new Size(1593, 744);
            navigation.TabIndex = 3;
            // 
            // containerTab
            //
            containerTab.Location = new Point(4, 40);
            containerTab.Name = "containerTab";
            containerTab.Padding = new Padding(3);
            containerTab.Size = new Size(1585, 700);
            containerTab.TabIndex = 0;
            containerTab.Text = "Containers";
            containerTab.UseVisualStyleBackColor = true;
            // 
            // imageTab
            // 
            imageTab.Location = new Point(4, 40);
            imageTab.Name = "imageTab";
            imageTab.Padding = new Padding(3);
            imageTab.Size = new Size(1585, 700);
            imageTab.TabIndex = 1;
            imageTab.Text = "Images";
            imageTab.UseVisualStyleBackColor = true;
            // 
            // volumeTab
            // 
            volumeTab.Location = new Point(4, 40);
            volumeTab.Name = "volumeTab";
            volumeTab.Padding = new Padding(3);
            volumeTab.Size = new Size(1585, 700);
            volumeTab.TabIndex = 2;
            volumeTab.Text = "Volumes";
            volumeTab.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1617, 768);
            Controls.Add(navigation);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Docker Tools";
            navigation.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl navigation;
        private TabPage containerTab;
        private TabPage imageTab;
        private TabPage volumeTab;
    }
}