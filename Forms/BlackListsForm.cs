using DB_993.Classes;
using DB_993.Resourse;

namespace design
{
    public partial class BlackList : Form
    {
        /// <summary>
        /// Класс используется для добавления объектов в черный список, отображения информации об объектах и удаления объекта из черного списка.
        /// </summary>
        public int IdRealryForFav { get; set; }
        public string? Email { get; set; }
        public BlackList()
        {
            InitializeComponent();
            LoadData();

        }
        public BlackList(int idRealty)
        {
            IdRealryForFav = idRealty;
            FillTableFavourites();
            InitializeComponent();

        }


        private void FillTableFavourites()
        {
            using (var context = new ApplicationContextBD())
            {
                for (int i = 0; i < context.BlackLists.Count(); i++)
                {
                    var existingUser = context.BlackLists.FirstOrDefault(bl => bl.Realtys[i].Id == IdRealryForFav);
                    if (existingUser != null)
                    {
                        MessageBox.Show(BlackListLocal.BlackListText);
                        return;
                    }
                }
                var newBL = new BlackListTable
                {
                    Realtys = { context!.Realtys!.FirstOrDefault(fav => fav!.Id == IdRealryForFav)! },
                    EmailUser = Email
                };
                context.BlackLists.Add(newBL);
                context.SaveChanges();
            }
        }
        private void LoadData()
        {
            using (var context = new ApplicationContextBD())
            {
                var imageList = new ImageList();
                imageList.ImageSize = new Size(100, 100);
                var listFav = context.BlackLists.Where(w => w.EmailUser == Email).Select(u => u.Id).ToList();
                var listRealty = new List<Realty>();
                for (int i = 0; i < listFav.Count; i++)
                {
                    listRealty.Add(context.Realtys.FirstOrDefault(f => f.BlackListId == listFav[i])!);
                }
                if (listRealty != null)
                {
                    for (int i = 0; i < listRealty!.Count; i++)
                    {
                        imageList.Images.Add(new Bitmap(listRealty[i].PhotoRealty!));
                    }
                    listView1.SmallImageList = imageList;

                    for (int i = 0; i < listRealty.Count; i++)
                    {
                        var listViewItem = new ListViewItem(new string[] { string.Empty, listRealty[i].Price.ToString()!,
                        listRealty[i].Address!, listRealty[i].NameRealty!});
                        listViewItem.ImageIndex = i;
                        listView1.Items.Add(listViewItem);
                    }
                }

            }
        }

        private void BlackListButton_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationContextBD())
            {
                var fav = context.BlackLists.ToList();
                if (fav != null)
                {
                    listView1.Clear();
                    for (int i = 0; i < fav!.Count; i++)
                    {
                        if (fav[i] != null)
                        {
                            context.Entry(fav[i])
                             .Collection(c => c.Realtys)
                             .Load();
                            context.BlackLists.Remove(fav[i]);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        private void BlackList_Load(object sender, EventArgs e)
        {
            var t = new ToolTip();
            t.SetToolTip(BlackListButton, BlackListLocal.BlackListClearText);
        }
    }
}
