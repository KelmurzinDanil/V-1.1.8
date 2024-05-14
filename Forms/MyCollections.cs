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
                var listComp = context.Compilations.Where(w => w.Email == Email).ToList();
                var image = context.Compilations.Where(w => w.Email == Email).Select(u => u.Realtys).FirstOrDefault();
                Dict.Add(0, "Общая подборка");
                if (listComp != null)
                {
                    if (image != null)
                    {
                        for (int j = 0; j < image!.Count; j++)
                        {
                            imageList.Images.Add(new Bitmap(image[j].PhotoRealty!));
                        }
                    }
                    CompList.SmallImageList = imageList;

                    var listGeneral = context.Realtys.OrderByDescending(o => o.Mark).First();
                    var listViewCompGeneral = new ListViewItem(new string[] { string.Empty, "Общая подборка" });
                    CompList.Items.Add(listViewCompGeneral);

                    for (int i = 0; i < listComp.Count; i++)
                    {
                        var listViewComp = new ListViewItem(new string[] { string.Empty, listComp[i]!.Name!.ToString()! });
                        Dict.Add(i + 1, listComp[i].Name!);
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
                var cCard = new CollectionCard(Dict[indices[0]], Email);
                cCard.Show();
            }
        }
    }
}
