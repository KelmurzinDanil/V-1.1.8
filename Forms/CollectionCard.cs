using DB_993.Classes;
namespace design
{
    /// <summary>
    /// Класс используется для отображения и взаимодействия с коллекцией карточек.
    /// </summary>
    public partial class CollectionCard : Form
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public CollectionCard(string name, string email)
        {
            InitializeComponent();
            Name = name;
            Email = email;
            LoadData();

        }
        public void LoadData()
        {
            using (var context = new ApplicationContextBD())
            {
                if (Name != "Общая подборка")
                {
                    var listRealty = context.Compilations.Where(w => w.Email == Email && w.Name == Name).Select(u => u.Realtys).FirstOrDefault();
                    if (listRealty != null)
                    {
                        FillListRealty(listRealty);
                    }
                }
                else
                {
                    var listRealtyId = new List<int>();
                    var sortListRealtyId = new List<int>();
                    var listRealty = new List<Realty>();
                    var listGeneral = context.Compilations.Select(s => s.Realtys).ToList();
                    if (listGeneral != null)
                    {
                        for (int i = 0; i < listGeneral.Count; i++)
                        {
                            for (int j = 0; j < listGeneral[i].Count; j++)
                            {
                                listRealtyId.Add(listGeneral[i][j].Id);
                            }
                        }
                        sortListRealtyId = listRealtyId
                            .GroupBy(x => x)
                            .OrderByDescending(g => g.Count())
                            .Select(g => g.Key)
                            .ToList();
                        for (int i = 0; i < sortListRealtyId.Count; i++)
                        {
                            listRealty.Add(context.Realtys.FirstOrDefault(f => f.Id == sortListRealtyId[i])!);
                        }

                        FillListRealty(listRealty);
                    }
                }

            }
        }
        public void FillListRealty(List<Realty> listRealty)
        {
            var imageList = new ImageList();
            imageList.ImageSize = new Size(100, 100);
            for (int i = 0; i < listRealty!.Count; i++)
            {
                imageList.Images.Add(new Bitmap(listRealty[i].PhotoRealty!));
            }
            ListRealtyComp.SmallImageList = imageList;

            for (int i = 0; i < listRealty.Count; i++)
            {
                var listViewItem = new ListViewItem(new string[] { string.Empty, listRealty[i].Price.ToString()!,
                            listRealty[i].Address!, listRealty[i].NameRealty!});
                listViewItem.ImageIndex = i;
                ListRealtyComp.Items.Add(listViewItem);
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            var emailMComp = new EmailMessageCompilation();
            emailMComp.PushEmailMessage(Email, Name);
        }
    }
}
