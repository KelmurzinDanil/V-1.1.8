namespace design
{
    partial class MyCollections
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyCollections));
            Picture7 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            Text1 = new Label();
            CompList = new ListView();
            PhotoFirst = new ColumnHeader();
            NameList = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)Picture7).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // Picture7
            // 
            resources.ApplyResources(Picture7, "Picture7");
            Picture7.Name = "Picture7";
            Picture7.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.Controls.Add(CompList, 0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // Text1
            // 
            resources.ApplyResources(Text1, "Text1");
            Text1.ForeColor = SystemColors.ActiveCaptionText;
            Text1.Name = "Text1";
            // 
            // CompList
            // 
            resources.ApplyResources(CompList, "CompList");
            CompList.Columns.AddRange(new ColumnHeader[] { PhotoFirst, NameList });
            CompList.MultiSelect = false;
            CompList.Name = "CompList";
            CompList.UseCompatibleStateImageBehavior = false;
            CompList.View = View.Details;
            CompList.ItemActivate += CompList_ItemActivate_1;
            // 
            // PhotoFirst
            // 
            resources.ApplyResources(PhotoFirst, "PhotoFirst");
            // 
            // NameList
            // 
            resources.ApplyResources(NameList, "NameList");
            // 
            // MyCollections
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Text1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(Picture7);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "MyCollections";
            SizeChanged += MyCollections_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)Picture7).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox Picture7;
        private Label Text1;
        private ListView CompList;
        private ColumnHeader PhotoFirst;
        private ColumnHeader NameList;
        private TableLayoutPanel tableLayoutPanel1;
    }
}