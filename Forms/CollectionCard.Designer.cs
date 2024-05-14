namespace design
{
    partial class CollectionCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectionCard));
            Picture7 = new PictureBox();
            EditButton = new Button();
            ListRealtyComp = new ListView();
            PhotoList = new ColumnHeader();
            PriceList = new ColumnHeader();
            AddressList = new ColumnHeader();
            NameList = new ColumnHeader();
            tableLayoutPanel1 = new TableLayoutPanel();
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
            // EditButton
            // 
            resources.ApplyResources(EditButton, "EditButton");
            EditButton.BackColor = Color.Gainsboro;
            EditButton.ForeColor = SystemColors.ActiveCaptionText;
            EditButton.Name = "EditButton";
            EditButton.UseVisualStyleBackColor = false;
            EditButton.Click += EditButton_Click;
            // 
            // ListRealtyComp
            // 
            resources.ApplyResources(ListRealtyComp, "ListRealtyComp");
            ListRealtyComp.Columns.AddRange(new ColumnHeader[] { PhotoList, PriceList, AddressList, NameList });
            ListRealtyComp.MultiSelect = false;
            ListRealtyComp.Name = "ListRealtyComp";
            ListRealtyComp.UseCompatibleStateImageBehavior = false;
            ListRealtyComp.View = View.Details;
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
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(ListRealtyComp, 0, 0);
            tableLayoutPanel1.Controls.Add(EditButton, 0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // CollectionCard
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(Picture7);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "CollectionCard";
            SizeChanged += CollectionCard_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)Picture7).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox Picture7;
        private System.Windows.Forms.Button EditButton;
        private ListView ListRealtyComp;
        private ColumnHeader PhotoList;
        private ColumnHeader PriceList;
        private ColumnHeader AddressList;
        private ColumnHeader NameList;
        private TableLayoutPanel tableLayoutPanel1;
    }
}