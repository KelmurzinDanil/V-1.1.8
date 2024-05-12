using DB_993.Classes;
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
                if (listRealty != null)
                {
                    for (int i = 0; i < listRealty!.Count; i++)
                    {
                        imageList.Images.Add(new Bitmap(listRealty[i].PhotoRealty!));
                    }
                    CompList.SmallImageList = imageList;

                    var listGeneral = context.Realtys.OrderByDescending(o => o.Mark).First();
                    var listViewCompGeneral = new ListViewItem(new string[] { string.Empty, "Общая подборка" });
                    listViewCompGeneral.ImageIndex = 0;
                    CompList.Items.Add(listViewCompGeneral);

                    for (int i = 0; i < listComp.Count; i++)
                    {
                        var listViewComp = new ListViewItem(new string[] { string.Empty, listComp[i]!.Name!.ToString()! });
                        Dict.Add(listComp[i].Id, listComp[i].Name!);
                        listViewComp.ImageIndex = i;
                        CompList.Items.Add(listViewComp);
                    }
                }
               
            }
        }
        private void CompList_ItemActivate_1(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = CompList.SelectedIndices;
            if (indices.Count > 0)
            {
                var cCard = new CollectionCard(indices[0], Email);
                cCard.Show();
            }
        }
    }
}
