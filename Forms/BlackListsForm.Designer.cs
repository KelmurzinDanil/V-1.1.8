namespace design
{
    partial class BlackList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackList));
            Picture6 = new PictureBox();
            BlackListButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            listView1 = new ListView();
            PhotoList = new ColumnHeader();
            PriceList = new ColumnHeader();
            AddressList = new ColumnHeader();
            NameList = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)Picture6).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // Picture6
            // 
            resources.ApplyResources(Picture6, "Picture6");
            Picture6.Name = "Picture6";
            Picture6.TabStop = false;
            // 
            // BlackListButton
            // 
            resources.ApplyResources(BlackListButton, "BlackListButton");
            BlackListButton.BackColor = Color.Gainsboro;
            BlackListButton.Name = "BlackListButton";
            BlackListButton.UseVisualStyleBackColor = false;
            BlackListButton.Click += BlackListButton_Click;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(listView1, 0, 0);
            tableLayoutPanel1.Controls.Add(BlackListButton, 0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // listView1
            // 
            resources.ApplyResources(listView1, "listView1");
            listView1.Columns.AddRange(new ColumnHeader[] { PhotoList, PriceList, AddressList, NameList });
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // PhotoList
            // 
            resources.ApplyResources(PhotoList, "PhotoList");
            // 
            // PriceList
            // 
            resources.ApplyResources(PriceList, "PriceList");
            // 
            // AddressList
            // 
            resources.ApplyResources(AddressList, "AddressList");
            // 
            // NameList
            // 
            resources.ApplyResources(NameList, "NameList");
            // 
            // BlackList
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(Picture6);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "BlackList";
            Load += BlackList_Load;
            SizeChanged += BlackList_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)Picture6).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox Picture6;
        private Button BlackListButton;
        private TableLayoutPanel tableLayoutPanel1;
        private ListView listView1;
        private ColumnHeader PhotoList;
        private ColumnHeader PriceList;
        private ColumnHeader AddressList;
        private ColumnHeader NameList;
    }
}