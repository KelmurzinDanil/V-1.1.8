namespace design
{
    partial class AddList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddList));
            Picture4 = new PictureBox();
            Text1 = new Label();
            CollectionsCombo = new ComboBox();
            CreateCollectionButton = new Button();
            AddCollectionBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)Picture4).BeginInit();
            SuspendLayout();
            // 
            // Picture4
            // 
            resources.ApplyResources(Picture4, "Picture4");
            Picture4.Name = "Picture4";
            Picture4.TabStop = false;
            // 
            // Text1
            // 
            resources.ApplyResources(Text1, "Text1");
            Text1.BackColor = Color.Transparent;
            Text1.ForeColor = SystemColors.ActiveCaptionText;
            Text1.Name = "Text1";
            // 
            // CollectionsCombo
            // 
            resources.ApplyResources(CollectionsCombo, "CollectionsCombo");
            CollectionsCombo.ForeColor = SystemColors.ActiveCaptionText;
            CollectionsCombo.FormattingEnabled = true;
            CollectionsCombo.Name = "CollectionsCombo";
            // 
            // CreateCollectionButton
            // 
            resources.ApplyResources(CreateCollectionButton, "CreateCollectionButton");
            CreateCollectionButton.BackColor = Color.Gainsboro;
            CreateCollectionButton.ForeColor = SystemColors.ActiveCaptionText;
            CreateCollectionButton.Name = "CreateCollectionButton";
            CreateCollectionButton.UseVisualStyleBackColor = false;
            CreateCollectionButton.Click += CreateCollectionButton_Click;
            // 
            // AddCollectionBtn
            // 
            resources.ApplyResources(AddCollectionBtn, "AddCollectionBtn");
            AddCollectionBtn.BackColor = Color.Gainsboro;
            AddCollectionBtn.Name = "AddCollectionBtn";
            AddCollectionBtn.UseVisualStyleBackColor = false;
            AddCollectionBtn.Click += AddCollectionBtn_Click;
            // 
            // AddList
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(AddCollectionBtn);
            Controls.Add(CreateCollectionButton);
            Controls.Add(CollectionsCombo);
            Controls.Add(Text1);
            Controls.Add(Picture4);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "AddList";
            ((System.ComponentModel.ISupportInitialize)Picture4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox Picture4;
        private System.Windows.Forms.Label Text1;
        private System.Windows.Forms.ComboBox CollectionsCombo;
        private Button CreateCollectionButton;
        private Button AddCollectionBtn;
    }
}