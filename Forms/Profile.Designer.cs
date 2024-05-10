namespace design
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            Picture4 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            NameText = new TextBox();
            EmailText = new TextBox();
            EditButton = new Button();
            SaveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Picture4).BeginInit();
            SuspendLayout();
            // 
            // Picture4
            // 
            resources.ApplyResources(Picture4, "Picture4");
            Picture4.Name = "Picture4";
            Picture4.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Name = "label3";
            // 
            // NameText
            // 
            resources.ApplyResources(NameText, "NameText");
            NameText.BackColor = Color.WhiteSmoke;
            NameText.BorderStyle = BorderStyle.None;
            NameText.ForeColor = SystemColors.ActiveCaptionText;
            NameText.Name = "NameText";
            // 
            // EmailText
            // 
            resources.ApplyResources(EmailText, "EmailText");
            EmailText.BackColor = Color.WhiteSmoke;
            EmailText.BorderStyle = BorderStyle.None;
            EmailText.ForeColor = SystemColors.ActiveCaptionText;
            EmailText.Name = "EmailText";
            // 
            // EditButton
            // 
            resources.ApplyResources(EditButton, "EditButton");
            EditButton.BackColor = Color.Gainsboro;
            EditButton.ForeColor = SystemColors.ActiveCaptionText;
            EditButton.Name = "EditButton";
            EditButton.UseVisualStyleBackColor = false;
            EditButton.Click += EditButton_Click;
            // 
            // SaveButton
            // 
            resources.ApplyResources(SaveButton, "SaveButton");
            SaveButton.BackColor = Color.Gainsboro;
            SaveButton.ForeColor = SystemColors.ActiveCaptionText;
            SaveButton.Name = "SaveButton";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click_1;
            // 
            // Profile
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SaveButton);
            Controls.Add(EditButton);
            Controls.Add(EmailText);
            Controls.Add(NameText);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Picture4);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Profile";
            ((System.ComponentModel.ISupportInitialize)Picture4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox Picture4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SaveButton;
    }
}