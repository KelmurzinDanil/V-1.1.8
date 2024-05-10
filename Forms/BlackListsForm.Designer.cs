﻿namespace design
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
            BlackListButton = new Button();
            Picture6 = new PictureBox();
            listView1 = new ListView();
            PhotoList = new ColumnHeader();
            PriceList = new ColumnHeader();
            AddressList = new ColumnHeader();
            NameList = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)Picture6).BeginInit();
            SuspendLayout();
            // 
            // BlackListButton
            // 
            resources.ApplyResources(BlackListButton, "BlackListButton");
            BlackListButton.BackColor = Color.Gainsboro;
            BlackListButton.Name = "BlackListButton";
            BlackListButton.UseVisualStyleBackColor = false;
            BlackListButton.Click += BlackListButton_Click;
            // 
            // Picture6
            // 
            resources.ApplyResources(Picture6, "Picture6");
            Picture6.Name = "Picture6";
            Picture6.TabStop = false;
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
            Controls.Add(listView1);
            Controls.Add(BlackListButton);
            Controls.Add(Picture6);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "BlackList";
            Load += BlackList_Load;
            ((System.ComponentModel.ISupportInitialize)Picture6).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button BlackListButton;
        private System.Windows.Forms.PictureBox Picture6;
        private ListView listView1;
        private ColumnHeader PhotoList;
        private ColumnHeader PriceList;
        private ColumnHeader AddressList;
        private ColumnHeader NameList;
    }
}