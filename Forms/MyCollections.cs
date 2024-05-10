using DB_993.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace design

{
    public partial class MyCollections : Form
    {
        public string Email { get; set; }
        public Dictionary<int, string> Dict { get; set; } = new Dictionary<int, string>();
        public MyCollections(string email)
        {
            InitializeComponent();
            Design();
            Email = email;
            LoadData();
        }
        /// <summary>
        /// Метод настраивает внешний вид элементов управления на форме.
        /// </summary>
        public void Design()
        {
            Text1.Parent = Picture7;
            Text1.BackColor = Color.Transparent;
        }
        public void LoadData()
        {

            using (var context = new ApplicationContextBD())
            {
                var imageList = new ImageList();
                imageList.ImageSize = new Size(100, 100);
                var listComp = context.Compilations.ToList();
                var listRealty = context.Compilations.Select(u => u.Realtys).FirstOrDefault();
                for (int i = 0; i < listRealty!.Count; i++)
                {
                    imageList.Images.Add(new Bitmap(listRealty[i].PhotoRealty!));
                }
                CompList.SmallImageList = imageList;
                for (int i = 0; i < listComp.Count; i++)
                {
                    var listViewComp = new ListViewItem(new string[] {string.Empty, listComp[i]!.Name!.ToString()! });
                    Dict.Add(listComp[i].Id, listComp[i].Name!);
                    listViewComp.ImageIndex = i;
                    CompList.Items.Add(listViewComp);
                }
            }
        }
        private void CompList_ItemActivate_1(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = CompList.SelectedIndices;
            if (indices.Count > 0)
            {
                var cCard = new CollectionCard(indices[0] + 1, Email);
                cCard.Show();
            }
        }
    }
}
