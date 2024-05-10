namespace DB_993.Forms
{
    partial class CheckСodeForm
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
            Okbtn = new Button();
            TextBoxCode = new TextBox();
            labelCheckForm = new Label();
            SuspendLayout();
            // 
            // Okbtn
            // 
            Okbtn.Location = new Point(291, 119);
            Okbtn.Name = "Okbtn";
            Okbtn.Size = new Size(94, 29);
            Okbtn.TabIndex = 5;
            Okbtn.Text = "Ок";
            Okbtn.UseVisualStyleBackColor = true;
            // 
            // TextBoxCode
            // 
            TextBoxCode.Location = new Point(12, 73);
            TextBoxCode.Name = "TextBoxCode";
            TextBoxCode.Size = new Size(373, 27);
            TextBoxCode.TabIndex = 4;
            TextBoxCode.TextChanged += TextBoxCode_TextChanged;
            // 
            // labelCheckForm
            // 
            labelCheckForm.AutoSize = true;
            labelCheckForm.Location = new Point(12, 10);
            labelCheckForm.Name = "labelCheckForm";
            labelCheckForm.Size = new Size(350, 20);
            labelCheckForm.TabIndex = 3;
            labelCheckForm.Text = "Вам на почту был вышлен код. Введите его сюда";
            // 
            // CheckСodeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 159);
            Controls.Add(Okbtn);
            Controls.Add(TextBoxCode);
            Controls.Add(labelCheckForm);
            Name = "CheckСodeForm";
            Text = "CheckСodeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Okbtn;
        private TextBox TextBoxCode;
        private Label labelCheckForm;
    }
}