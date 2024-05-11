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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckСodeForm));
            Okbtn = new Button();
            TextBoxCode = new TextBox();
            labelCheckForm = new Label();
            SuspendLayout();
            // 
            // Okbtn
            // 
            resources.ApplyResources(Okbtn, "Okbtn");
            Okbtn.BackColor = Color.Gainsboro;
            Okbtn.ForeColor = SystemColors.ControlText;
            Okbtn.Name = "Okbtn";
            Okbtn.UseVisualStyleBackColor = false;
            // 
            // TextBoxCode
            // 
            resources.ApplyResources(TextBoxCode, "TextBoxCode");
            TextBoxCode.Name = "TextBoxCode";
            TextBoxCode.TextChanged += TextBoxCode_TextChanged;
            // 
            // labelCheckForm
            // 
            resources.ApplyResources(labelCheckForm, "labelCheckForm");
            labelCheckForm.Name = "labelCheckForm";
            // 
            // CheckСodeForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Okbtn);
            Controls.Add(TextBoxCode);
            Controls.Add(labelCheckForm);
            Name = "CheckСodeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Okbtn;
        private TextBox TextBoxCode;
        private Label labelCheckForm;
    }
}