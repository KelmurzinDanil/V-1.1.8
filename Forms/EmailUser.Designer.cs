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
            labelEmailForm = new Label();
            TextBoxEmail = new TextBox();
            Okbtn = new Button();
            SuspendLayout();
            // 
            // labelEmailForm
            // 
            labelEmailForm.AutoSize = true;
            labelEmailForm.Location = new Point(12, 9);
            labelEmailForm.Name = "labelEmailForm";
            labelEmailForm.Size = new Size(151, 20);
            labelEmailForm.TabIndex = 0;
            labelEmailForm.Text = "Введите свою почту:";
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(12, 72);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(373, 27);
            TextBoxEmail.TabIndex = 1;
            // 
            // Okbtn
            // 
            Okbtn.Location = new Point(291, 118);
            Okbtn.Name = "Okbtn";
            Okbtn.Size = new Size(94, 29);
            Okbtn.TabIndex = 2;
            Okbtn.Text = "Ок";
            Okbtn.UseVisualStyleBackColor = true;
            Okbtn.Click += Okbtn_Click;
            Okbtn.KeyDown += Okbtn_KeyDown;
            // 
            // EmailUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 159);
            Controls.Add(Okbtn);
            Controls.Add(TextBoxEmail);
            Controls.Add(labelEmailForm);
            Name = "EmailUser";
            Text = "EmailUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelEmailForm;
        private TextBox TextBoxEmail;
        private Button Okbtn;
    }
}