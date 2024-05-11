using DB_993.Classes;
namespace design
{
    /// <summary>
    /// Класс используется для отображения и взаимодействия с коллекцией карточек.
    /// </summary>
    public partial class CollectionCard : Form
    {
        public string Email { get; set; }
        public int IdComp { get; set; }
        public CollectionCard(int idComp, string email)
        {
            InitializeComponent();
            IdComp = idComp;
            Email = email;
            LoadData();

        }
        public void LoadData()
        {
            using (var context = new ApplicationContextBD())
            {
                if (IdComp != 0)
                {
                    var imageList = new ImageList();
                    imageList.ImageSize = new Size(100, 100);
                    var listRealty = context.Compilations.Where(w => w.Id == IdComp).Select(u => u.Realtys).FirstOrDefault();
                    if (listRealty != null)
                    {
                        FillListRealty(listRealty);
                    }
                }
                else
                {
                    var listGeneral = context.Realtys.OrderByDescending(o => o.Mark).ToList();
                    if (listGeneral != null)
                    {
                        FillListRealty(listGeneral);
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
            emailMComp.PushEmailMessage(Email, IdComp);
        }
    }
}
