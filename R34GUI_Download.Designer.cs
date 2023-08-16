namespace Rule34XXXGUI
{
    partial class R34GUI_Download
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
            Progressbar_ScanAndDownload = new ProgressBar();
            Textlabel_NowStatus = new Label();
            Textlabel_Progress = new Label();
            Button_CancelDownload = new Button();
            SuspendLayout();
            // 
            // Progressbar_ScanAndDownload
            // 
            Progressbar_ScanAndDownload.Location = new Point(12, 66);
            Progressbar_ScanAndDownload.Name = "Progressbar_ScanAndDownload";
            Progressbar_ScanAndDownload.Size = new Size(567, 39);
            Progressbar_ScanAndDownload.TabIndex = 0;
            // 
            // Textlabel_NowStatus
            // 
            Textlabel_NowStatus.AutoSize = true;
            Textlabel_NowStatus.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_NowStatus.Location = new Point(12, 9);
            Textlabel_NowStatus.Name = "Textlabel_NowStatus";
            Textlabel_NowStatus.Size = new Size(95, 27);
            Textlabel_NowStatus.TabIndex = 2;
            Textlabel_NowStatus.Text = "Progress";
            // 
            // Textlabel_Progress
            // 
            Textlabel_Progress.AutoSize = true;
            Textlabel_Progress.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_Progress.Location = new Point(12, 36);
            Textlabel_Progress.Name = "Textlabel_Progress";
            Textlabel_Progress.Size = new Size(89, 27);
            Textlabel_Progress.TabIndex = 3;
            Textlabel_Progress.Text = "Loading";
            // 
            // Button_CancelDownload
            // 
            Button_CancelDownload.Location = new Point(485, 7);
            Button_CancelDownload.Name = "Button_CancelDownload";
            Button_CancelDownload.Size = new Size(94, 29);
            Button_CancelDownload.TabIndex = 4;
            Button_CancelDownload.Text = "Cancel";
            Button_CancelDownload.UseVisualStyleBackColor = true;
            Button_CancelDownload.Click += Button_CancelDownload_Click;
            // 
            // R34GUI_Download
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 128);
            Controls.Add(Button_CancelDownload);
            Controls.Add(Textlabel_Progress);
            Controls.Add(Textlabel_NowStatus);
            Controls.Add(Progressbar_ScanAndDownload);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "R34GUI_Download";
            Text = "Download";
            Load += R34GUI_Download_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar Progressbar_ScanAndDownload;
        private Label Textlabel_NowStatus;
        private Label Textlabel_Progress;
        private Button Button_CancelDownload;
    }
}