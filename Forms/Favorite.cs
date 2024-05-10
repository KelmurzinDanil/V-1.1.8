using DB_993.Classes;
using DB_993.Resourse;
namespace design
{
    /// <summary>
    /// Класс используется для добавления объектов в избранное, отображения информации об объектах и удаления объекта из избранного.
    /// </summary>
    public partial class Favorite : Form
    {
        public int IdRealryForFav { get; set; }
        public List<Realty>? ListRealty { get; set; }
        public Favorite()
        {

            InitializeComponent();
            LoadData();

        }
        public Favorite(int idRealty)
        {
            IdRealryForFav = idRealty;
            FillTableFavourites();
            InitializeComponent();


        }

        private void FillTableFavourites()
        {
            using (var context = new ApplicationContextBD())
            {
                for (int i = 0; i < context.Favourites.Count(); i++)
                {
                    var existingUser = context.Favourites.FirstOrDefault(bl => bl.Realtys[i].Id == IdRealryForFav);
                    if (existingUser != null)
                    {
                        MessageBox.Show(FavoriteLocal.FavoriteText);
                        return;
                    }
                }
                var newFav = new Favourites
                {
                    Realtys = { context!.Realtys!.FirstOrDefault(fav => fav!.Id == IdRealryForFav)! }
                };
                context.Favourites.Add(newFav);
                context.SaveChanges();
            }
        }
        private void LoadData()
        {
            using (var context = new ApplicationContextBD())
            {
                var imageList = new ImageList();
                imageList.ImageSize = new Size(100, 100);
                var listRealty = context.Favourites.Select(u => u.Realtys).SingleOrDefault();
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
                var fav = context.Favourites.ToList();
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
                            context.Favourites.Remove(fav[i]);
                            context.SaveChanges();
                        }
                    }
                }


            }
        }

        private void Favorite_Load(object sender, EventArgs e)
        {
            var t = new ToolTip();
            t.SetToolTip(BlackListButton, FavoriteLocal.ClearFavoriteText);
        }
    }
}
