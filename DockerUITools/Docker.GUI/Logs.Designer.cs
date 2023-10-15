namespace Docker.GUI
{
    partial class Logs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logs));
            logTextBox = new RichTextBox();
            refreshLogs = new Button();
            SuspendLayout();
            // 
            // logTextBox
            // 
            logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTextBox.BackColor = SystemColors.GradientInactiveCaption;
            logTextBox.Location = new Point(12, 56);
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.Size = new Size(776, 382);
            logTextBox.TabIndex = 0;
            logTextBox.Text = "";
            // 
            // refreshLogs
            // 
            refreshLogs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshLogs.Location = new Point(683, 8);
            refreshLogs.Name = "refreshLogs";
            refreshLogs.Size = new Size(105, 42);
            refreshLogs.TabIndex = 1;
            refreshLogs.Text = "Refresh";
            refreshLogs.UseVisualStyleBackColor = true;
            refreshLogs.Click += refreshLogs_Click;
            // 
            // Logs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(refreshLogs);
            Controls.Add(logTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Logs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Logs";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox logTextBox;
        private Button refreshLogs;
    }
}