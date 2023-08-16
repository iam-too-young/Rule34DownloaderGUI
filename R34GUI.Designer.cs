namespace Rule34XXXGUI
{
    partial class R34GUI
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
            Textlabel_Static_tagList = new Label();
            Textbox_tagList = new TextBox();
            Button_CheckIfTagsValid = new Button();
            Textlabel_Static_tagInfo = new Label();
            Textlabel_tagStatus = new Label();
            Textlabel_Static_PageNumber = new Label();
            Textbox_PageNumber = new TextBox();
            Button_CheckPageNumberOfTags = new Button();
            Textlabel_Static_RequestsHeaders_UserAgent = new Label();
            Textbox_RequestsHeaders_UserAgent = new TextBox();
            Textlabel_Static_Proxy_Address = new Label();
            Textbox_Proxy_Address = new TextBox();
            Textbox_Proxy_Account = new TextBox();
            Textbox_Proxy_Password = new TextBox();
            Textlabel_Static_Proxy_Account = new Label();
            Textlabel_Static_Proxy_Password = new Label();
            Checkbox_Proxy_EnableVerify = new CheckBox();
            Checkbox_EnableMultiThread = new CheckBox();
            Checkbox_EnableTimeoutToCancel = new CheckBox();
            Button_StartDownload = new Button();
            Textlabel_Static_AWarmTip = new Label();
            SuspendLayout();
            // 
            // Textlabel_Static_tagList
            // 
            Textlabel_Static_tagList.AutoSize = true;
            Textlabel_Static_tagList.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_Static_tagList.Location = new Point(12, 9);
            Textlabel_Static_tagList.Name = "Textlabel_Static_tagList";
            Textlabel_Static_tagList.Size = new Size(99, 23);
            Textlabel_Static_tagList.TabIndex = 0;
            Textlabel_Static_tagList.Text = "List of tags";
            // 
            // Textbox_tagList
            // 
            Textbox_tagList.Location = new Point(12, 39);
            Textbox_tagList.Multiline = true;
            Textbox_tagList.Name = "Textbox_tagList";
            Textbox_tagList.ScrollBars = ScrollBars.Vertical;
            Textbox_tagList.Size = new Size(235, 423);
            Textbox_tagList.TabIndex = 1;
            Textbox_tagList.Text = "example_tag_1\r\n-example_tag_2\r\n-dont_leave_an_empty_line\r\n-It_will_cause_exception";
            Textbox_tagList.TextChanged += Textbox_tagList_TextChanged;
            // 
            // Button_CheckIfTagsValid
            // 
            Button_CheckIfTagsValid.Location = new Point(12, 491);
            Button_CheckIfTagsValid.Name = "Button_CheckIfTagsValid";
            Button_CheckIfTagsValid.Size = new Size(235, 41);
            Button_CheckIfTagsValid.TabIndex = 2;
            Button_CheckIfTagsValid.Text = "Check if tag are valid";
            Button_CheckIfTagsValid.UseVisualStyleBackColor = true;
            Button_CheckIfTagsValid.Click += Button_CheckIfTagsValid_ClickAsync;
            // 
            // Textlabel_Static_tagInfo
            // 
            Textlabel_Static_tagInfo.AutoSize = true;
            Textlabel_Static_tagInfo.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_Static_tagInfo.Location = new Point(12, 465);
            Textlabel_Static_tagInfo.Name = "Textlabel_Static_tagInfo";
            Textlabel_Static_tagInfo.Size = new Size(68, 23);
            Textlabel_Static_tagInfo.TabIndex = 3;
            Textlabel_Static_tagInfo.Text = "Status :";
            // 
            // Textlabel_tagStatus
            // 
            Textlabel_tagStatus.AutoSize = true;
            Textlabel_tagStatus.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_tagStatus.ForeColor = Color.Black;
            Textlabel_tagStatus.Location = new Point(86, 465);
            Textlabel_tagStatus.Name = "Textlabel_tagStatus";
            Textlabel_tagStatus.Size = new Size(95, 23);
            Textlabel_tagStatus.TabIndex = 4;
            Textlabel_tagStatus.Text = "Not Check";
            // 
            // Textlabel_Static_PageNumber
            // 
            Textlabel_Static_PageNumber.AutoSize = true;
            Textlabel_Static_PageNumber.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_Static_PageNumber.Location = new Point(394, 9);
            Textlabel_Static_PageNumber.Name = "Textlabel_Static_PageNumber";
            Textlabel_Static_PageNumber.Size = new Size(58, 23);
            Textlabel_Static_PageNumber.TabIndex = 5;
            Textlabel_Static_PageNumber.Text = "Pages";
            // 
            // Textbox_PageNumber
            // 
            Textbox_PageNumber.Location = new Point(309, 39);
            Textbox_PageNumber.Name = "Textbox_PageNumber";
            Textbox_PageNumber.Size = new Size(67, 27);
            Textbox_PageNumber.TabIndex = 6;
            // 
            // Button_CheckPageNumberOfTags
            // 
            Button_CheckPageNumberOfTags.Enabled = false;
            Button_CheckPageNumberOfTags.Location = new Point(382, 37);
            Button_CheckPageNumberOfTags.Name = "Button_CheckPageNumberOfTags";
            Button_CheckPageNumberOfTags.Size = new Size(157, 29);
            Button_CheckPageNumberOfTags.TabIndex = 7;
            Button_CheckPageNumberOfTags.Text = "Get Pages";
            Button_CheckPageNumberOfTags.UseVisualStyleBackColor = true;
            Button_CheckPageNumberOfTags.Click += Button_CheckPageNumberOfTags_ClickAsync;
            // 
            // Textlabel_Static_RequestsHeaders_UserAgent
            // 
            Textlabel_Static_RequestsHeaders_UserAgent.AutoSize = true;
            Textlabel_Static_RequestsHeaders_UserAgent.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_Static_RequestsHeaders_UserAgent.Location = new Point(318, 84);
            Textlabel_Static_RequestsHeaders_UserAgent.Name = "Textlabel_Static_RequestsHeaders_UserAgent";
            Textlabel_Static_RequestsHeaders_UserAgent.Size = new Size(209, 23);
            Textlabel_Static_RequestsHeaders_UserAgent.TabIndex = 9;
            Textlabel_Static_RequestsHeaders_UserAgent.Text = "User-Agent (if you have)";
            // 
            // Textbox_RequestsHeaders_UserAgent
            // 
            Textbox_RequestsHeaders_UserAgent.Location = new Point(309, 110);
            Textbox_RequestsHeaders_UserAgent.Name = "Textbox_RequestsHeaders_UserAgent";
            Textbox_RequestsHeaders_UserAgent.Size = new Size(230, 27);
            Textbox_RequestsHeaders_UserAgent.TabIndex = 10;
            // 
            // Textlabel_Static_Proxy_Address
            // 
            Textlabel_Static_Proxy_Address.AutoSize = true;
            Textlabel_Static_Proxy_Address.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_Static_Proxy_Address.Location = new Point(304, 171);
            Textlabel_Static_Proxy_Address.Name = "Textlabel_Static_Proxy_Address";
            Textlabel_Static_Proxy_Address.Size = new Size(235, 23);
            Textlabel_Static_Proxy_Address.TabIndex = 11;
            Textlabel_Static_Proxy_Address.Text = "Proxy Address (if you need)";
            // 
            // Textbox_Proxy_Address
            // 
            Textbox_Proxy_Address.Location = new Point(309, 197);
            Textbox_Proxy_Address.Name = "Textbox_Proxy_Address";
            Textbox_Proxy_Address.Size = new Size(230, 27);
            Textbox_Proxy_Address.TabIndex = 12;
            // 
            // Textbox_Proxy_Account
            // 
            Textbox_Proxy_Account.Location = new Point(439, 245);
            Textbox_Proxy_Account.Name = "Textbox_Proxy_Account";
            Textbox_Proxy_Account.Size = new Size(100, 27);
            Textbox_Proxy_Account.TabIndex = 13;
            // 
            // Textbox_Proxy_Password
            // 
            Textbox_Proxy_Password.Location = new Point(439, 287);
            Textbox_Proxy_Password.Name = "Textbox_Proxy_Password";
            Textbox_Proxy_Password.Size = new Size(100, 27);
            Textbox_Proxy_Password.TabIndex = 14;
            Textbox_Proxy_Password.UseSystemPasswordChar = true;
            // 
            // Textlabel_Static_Proxy_Account
            // 
            Textlabel_Static_Proxy_Account.AutoSize = true;
            Textlabel_Static_Proxy_Account.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_Static_Proxy_Account.Location = new Point(291, 246);
            Textlabel_Static_Proxy_Account.Name = "Textlabel_Static_Proxy_Account";
            Textlabel_Static_Proxy_Account.Size = new Size(148, 23);
            Textlabel_Static_Proxy_Account.TabIndex = 15;
            Textlabel_Static_Proxy_Account.Text = "Account (if have)";
            // 
            // Textlabel_Static_Proxy_Password
            // 
            Textlabel_Static_Proxy_Password.AutoSize = true;
            Textlabel_Static_Proxy_Password.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_Static_Proxy_Password.Location = new Point(276, 288);
            Textlabel_Static_Proxy_Password.Name = "Textlabel_Static_Proxy_Password";
            Textlabel_Static_Proxy_Password.Size = new Size(157, 23);
            Textlabel_Static_Proxy_Password.TabIndex = 16;
            Textlabel_Static_Proxy_Password.Text = "Password (if have)";
            // 
            // Checkbox_Proxy_EnableVerify
            // 
            Checkbox_Proxy_EnableVerify.AutoSize = true;
            Checkbox_Proxy_EnableVerify.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Checkbox_Proxy_EnableVerify.Location = new Point(304, 330);
            Checkbox_Proxy_EnableVerify.Name = "Checkbox_Proxy_EnableVerify";
            Checkbox_Proxy_EnableVerify.Size = new Size(243, 27);
            Checkbox_Proxy_EnableVerify.TabIndex = 17;
            Checkbox_Proxy_EnableVerify.Text = "Validate Server Certificate";
            Checkbox_Proxy_EnableVerify.UseVisualStyleBackColor = true;
            // 
            // Checkbox_EnableMultiThread
            // 
            Checkbox_EnableMultiThread.AutoSize = true;
            Checkbox_EnableMultiThread.Checked = true;
            Checkbox_EnableMultiThread.CheckState = CheckState.Checked;
            Checkbox_EnableMultiThread.Enabled = false;
            Checkbox_EnableMultiThread.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Checkbox_EnableMultiThread.Location = new Point(335, 402);
            Checkbox_EnableMultiThread.Name = "Checkbox_EnableMultiThread";
            Checkbox_EnableMultiThread.Size = new Size(212, 27);
            Checkbox_EnableMultiThread.TabIndex = 18;
            Checkbox_EnableMultiThread.Text = "Enable Multithreading";
            Checkbox_EnableMultiThread.UseVisualStyleBackColor = true;
            // 
            // Checkbox_EnableTimeoutToCancel
            // 
            Checkbox_EnableTimeoutToCancel.AutoSize = true;
            Checkbox_EnableTimeoutToCancel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Checkbox_EnableTimeoutToCancel.Location = new Point(335, 435);
            Checkbox_EnableTimeoutToCancel.Name = "Checkbox_EnableTimeoutToCancel";
            Checkbox_EnableTimeoutToCancel.Size = new Size(204, 27);
            Checkbox_EnableTimeoutToCancel.TabIndex = 20;
            Checkbox_EnableTimeoutToCancel.Text = "Enable Timeout (10s)";
            Checkbox_EnableTimeoutToCancel.UseVisualStyleBackColor = true;
            // 
            // Button_StartDownload
            // 
            Button_StartDownload.Enabled = false;
            Button_StartDownload.Location = new Point(309, 491);
            Button_StartDownload.Name = "Button_StartDownload";
            Button_StartDownload.Size = new Size(534, 41);
            Button_StartDownload.TabIndex = 22;
            Button_StartDownload.Text = "Start Download!";
            Button_StartDownload.UseVisualStyleBackColor = true;
            Button_StartDownload.Click += Button_StartDownload_Click;
            // 
            // Textlabel_Static_AWarmTip
            // 
            Textlabel_Static_AWarmTip.AutoSize = true;
            Textlabel_Static_AWarmTip.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Textlabel_Static_AWarmTip.Location = new Point(557, 149);
            Textlabel_Static_AWarmTip.Name = "Textlabel_Static_AWarmTip";
            Textlabel_Static_AWarmTip.Size = new Size(299, 162);
            Textlabel_Static_AWarmTip.TabIndex = 23;
            Textlabel_Static_AWarmTip.Text = "You should Check tags at first,\r\n\r\nand get the number of pages\r\nabout tags,\r\n\r\nand start download.";
            // 
            // R34GUI
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(868, 544);
            Controls.Add(Textlabel_Static_AWarmTip);
            Controls.Add(Button_StartDownload);
            Controls.Add(Checkbox_EnableTimeoutToCancel);
            Controls.Add(Checkbox_EnableMultiThread);
            Controls.Add(Checkbox_Proxy_EnableVerify);
            Controls.Add(Textlabel_Static_Proxy_Password);
            Controls.Add(Textlabel_Static_Proxy_Account);
            Controls.Add(Textbox_Proxy_Password);
            Controls.Add(Textbox_Proxy_Account);
            Controls.Add(Textbox_Proxy_Address);
            Controls.Add(Textlabel_Static_Proxy_Address);
            Controls.Add(Textbox_RequestsHeaders_UserAgent);
            Controls.Add(Textlabel_Static_RequestsHeaders_UserAgent);
            Controls.Add(Button_CheckPageNumberOfTags);
            Controls.Add(Textbox_PageNumber);
            Controls.Add(Textlabel_Static_PageNumber);
            Controls.Add(Textlabel_tagStatus);
            Controls.Add(Textlabel_Static_tagInfo);
            Controls.Add(Button_CheckIfTagsValid);
            Controls.Add(Textbox_tagList);
            Controls.Add(Textlabel_Static_tagList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "R34GUI";
            RightToLeft = RightToLeft.No;
            Text = "Rule34Downloader";
            Load += R34GUI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Textlabel_Static_tagList;
        private TextBox Textbox_tagList;
        private Button Button_CheckIfTagsValid;
        private Label Textlabel_Static_tagInfo;
        private Label Textlabel_tagStatus;
        private Label Textlabel_Static_PageNumber;
        private TextBox Textbox_PageNumber;
        private Button Button_CheckPageNumberOfTags;
        private Label Textlabel_Static_RequestsHeaders_UserAgent;
        private TextBox Textbox_RequestsHeaders_UserAgent;
        private Label Textlabel_Static_Proxy_Address;
        private TextBox Textbox_Proxy_Address;
        private TextBox Textbox_Proxy_Account;
        private TextBox Textbox_Proxy_Password;
        private Label Textlabel_Static_Proxy_Account;
        private Label Textlabel_Static_Proxy_Password;
        private CheckBox Checkbox_Proxy_EnableVerify;
        private CheckBox Checkbox_EnableMultiThread;
        private CheckBox Checkbox_EnableTimeoutToCancel;
        private Button Button_StartDownload;
        private Label Textlabel_Static_AWarmTip;
    }
}