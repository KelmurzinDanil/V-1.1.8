namespace DB_993.Forms
{
    partial class EmailUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailUser));
            labelEmailForm = new Label();
            TextBoxEmail = new TextBox();
            Okbtn = new Button();
            SuspendLayout();
            // 
            // labelEmailForm
            // 
            resources.ApplyResources(labelEmailForm, "labelEmailForm");
            labelEmailForm.Name = "labelEmailForm";
            // 
            // TextBoxEmail
            // 
            resources.ApplyResources(TextBoxEmail, "TextBoxEmail");
            TextBoxEmail.Name = "TextBoxEmail";
            // 
            // Okbtn
            // 
            resources.ApplyResources(Okbtn, "Okbtn");
            Okbtn.Name = "Okbtn";
            Okbtn.UseVisualStyleBackColor = true;
            Okbtn.Click += Okbtn_Click;
            Okbtn.KeyDown += Okbtn_KeyDown;
            // 
            // EmailUser
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Okbtn);
            Controls.Add(TextBoxEmail);
            Controls.Add(labelEmailForm);
            Name = "EmailUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelEmailForm;
        private TextBox TextBoxEmail;
        private Button Okbtn;
    }
}