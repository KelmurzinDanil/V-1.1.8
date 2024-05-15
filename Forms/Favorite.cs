using DB_993.Classes;
using DB_993.Resourse;
namespace design
{
    /// <summary>
    /// Класс используется для добавления объектов в избранное, отображения информации об объектах и удаления объекта из избранного.
    /// </summary>
    public partial class Favorite : Form
    {
        public int Column1 { get; set; }
        public int Column2 { get; set; }
        public int Column3 { get; set; }
        public int Column4 { get; set; }
        public int HeightLoc { get; set; }
        public int WidthLoc { get; set; }
        public int HeightF { get; set; }
        public int WidthF { get; set; }
        public string? Email { get; set; }
        public int IdRealryForFav { get; set; }
        public List<Realty>? ListRealty { get; set; }
        public Favorite(string email)
        {

            InitializeComponent();
            Design();
            Email = email;
            LoadData();
        }
        public Favorite(int idRealty, string email)
        {
            IdRealryForFav = idRealty;
            Email = email;
            FillTableFavourites();
            InitializeComponent();
            Design();


        }
        public void Design()
        {
            Column1 = listView1.Columns[0].Width;
            Column2 = listView1.Columns[1].Width;
            Column3 = listView1.Columns[2].Width;
            Column4 = listView1.Columns[3].Width;
            listView1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            BlackListButton.Anchor = AnchorStyles.Left;
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.Width = 740;
            WidthF = this.Width;
            HeightF = this.Height;
            tableLayoutPanel1.Height = 629; 
            HeightLoc = 629;
            WidthLoc = 740;
            Picture6.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
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
                    Realtys = { context!.Realtys!.FirstOrDefault(fav => fav!.Id == IdRealryForFav)! },
                    EmailUser = Email
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
                var listFav = context.Favourites.Where(w => w.EmailUser == Email).Select(u => u.Id).ToList();
                var listRealty = new List<Realty>();
                for (int i = 0; i < listFav.Count; i++)
                {
                    listRealty.Add(context.Realtys.FirstOrDefault(f => f.FavouritesId == listFav[i])!);
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
            var toolTip = new ToolTip();
            toolTip.SetToolTip(BlackListButton, FavoriteLocal.ClearFavoriteText);
        }

        private void Favorite_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Width = (int)(((float)WidthLoc * ((float)this.Width / (float)WidthF)));
            tableLayoutPanel1.Height = (int)(((float)HeightLoc * ((float)this.Height / (float)HeightF)));


            listView1.Columns[0].Width = (int)(Column1 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));
            listView1.Columns[1].Width = (int)(Column2 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));
            listView1.Columns[2].Width = (int)(Column3 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));
            listView1.Columns[3].Width = (int)(Column4 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));

            int newX = (this.ClientSize.Width - tableLayoutPanel1.Width) / 2;
            int newY = (this.ClientSize.Height - tableLayoutPanel1.Height) / 2;
            tableLayoutPanel1.Location = new Point(newX, newY);
        }
    }
}
