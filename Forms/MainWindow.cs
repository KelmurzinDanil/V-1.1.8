using DB_993.Classes;
using DB_993.Forms;
using DB_993.Resourse;

namespace design
{
    /// <summary>
    /// Класс представляет главное окно приложения, который используется для работы с рекомендациями, выставлением рейтинга, 
    /// добавлением объекта в избранное и  черный список.
    /// </summary>
    public partial class MainWindow : Form
    {
        public int InitialDistanceS { get; set; }
        public int HeightLoc { get; set; }
        public int WidthLoc { get; set; }
        public int HeightF { get; set; }
        public int WidthF { get; set; }
        string? Email { get; set; }
        public int I { get; set; }
        int IdRealryForFavBlMark { get; set; }
        List<int>? SortList { get; set; }
        public Dictionary<int, decimal>? DictRecom { get; set; }
        public WebAuto WebAuto { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Design();
            FillSaveRecommendation();
        }
        public MainWindow(WebAuto webAuto)
        {
            InitializeComponent();
            Design();
            WebAuto = webAuto;
        }
        public MainWindow(GetRecommendation getRecommendation)
        {
            InitializeComponent();
            Design();
            FullListRecommendation(getRecommendation);
            FillRecommendation();
        }
        public MainWindow(GetRecommendation getRecommendation, string email)
        {
            InitializeComponent();
            Design();
            Email = email;
            FullListRecommendation(getRecommendation);
            FillRecommendation();
        }

        public MainWindow(string email)
        {
            InitializeComponent();
            Design();
            Email = email;
            FillSaveRecommendation();
        }
        /// <summary>
        /// Метод подгружает существующую рекомендацию
        /// </summary>
        public void FillSaveRecommendation()
        {
            using (var context = new ApplicationContextBD())
            {
                var recom = context.Realtys.Where(u => u.RecommendationsId == context.Recommendations.Where(w
                    => w.UserEmail == Email).Select(s => s.Id).FirstOrDefault()).Select(u => u.Id).ToList();
                SortList = recom;
                FillRecommendation();
            }
        }

        /// <summary>
        /// Метод заполняет список рекомендаций на основе полученных данных.
        /// </summary>
        /// <param name="getRecommendation"> Объект, содержащий рекомендации.</param>
        public void FullListRecommendation(GetRecommendation getRecommendation)
        {
            var dictRecom = new Dictionary<int, decimal>();
            using (var context = new ApplicationContextBD())
            {
                var existingRealty = context.Realtys.ToList();
                for (int i = 0; i < existingRealty.Count; i++)
                {
                    dictRecom.Add(existingRealty[i].Id, CalculateOverallRating(getRecommendation, existingRealty[i]));
                }
                DictRecom = dictRecom;

            }
            SortReccomendationList();
            SaveRecommendationUser();
        }

        /// <summary>
        /// Метод проверяет, находится ли объект недвижимости в черном списке.
        /// </summary>
        /// <param name="sortList">Список идентификаторов объектов недвижимости.</param>
        /// <returns>True, если объект недвижимости не находится в черном списке, иначе false.</returns>
        public bool CheckBlackList(int idRealty)
        {
            using (var context = new ApplicationContextBD())
            {
                var existingBl = context.BlackLists.ToList();
                for (int id = 0; id < existingBl.Count; id++)
                {
                    if (context.BlackLists.FirstOrDefault(bl => bl.Realtys[id].Id == idRealty) != null)
                    {
                        return false;
                    }
                }
                return true;
            }

        }
        /// <summary>
        /// Метод сортирует по значению словарь 
        /// </summary>
        public void SortReccomendationList()
        {
            var sortDict = from pair in DictRecom orderby pair.Value descending select pair;
            SortList = new List<int>();
            foreach (var pair in sortDict)
            {
                SortList.Add(pair.Key);
            }
        }
        /// <summary>
        /// Метод сохраняет подборку пользователя или обновляет ее
        /// </summary>
        public void SaveRecommendationUser()
        {
            using (var context = new ApplicationContextBD())
            {
                var recUser = context.Recommendations.FirstOrDefault(u => u.UserEmail == Email);
                if (recUser != null)
                {
                    recUser.UserEmail = Email;
                    foreach (var realtys in SortList!)
                    {
                        recUser.Realtys.Add(context.Realtys.FirstOrDefault(r => r.Id == realtys)!);
                    }
                    context.SaveChanges();
                }
                else
                {
                    var srtRec = new List<Realty>();
                    foreach (var realtys in SortList!)
                    {
                        if (CheckBlackList(realtys))
                        {
                            srtRec.Add(context.Realtys.FirstOrDefault(r => r.Id == realtys)!);
                        }
                    }
                    var newRecUser = new Recommendations
                    {
                        UserEmail = Email,
                        Realtys = srtRec

                    };
                    context.Add(newRecUser);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Метод заполняет интерфейс приложения рекомендациями.
        /// </summary>
        public void FillRecommendation()
        {
            if (I >= 0 && I < SortList!.Count)
            {
                using (var context = new ApplicationContextBD())
                {
                    if (CheckBlackList(SortList[I]))
                    {
                        var existingRealty = context.Realtys.FirstOrDefault(realty => realty.Id == SortList[I]);
                        RealtyPhoto.Image = Image.FromFile(existingRealty!.PhotoRealty!.ToString());
                        AddressText.Text = existingRealty.Address;
                        PriceText.Text = existingRealty.Price.ToString();
                        FloorText.Text = existingRealty.Floor.ToString();
                        SquareText.Text = existingRealty.Square.ToString();
                        IdRealryForFavBlMark = existingRealty.Id;
                    }
                }

            }
        }

        /// <summary>
        /// Метод вычисляет общий рейтинг объекта недвижимости на основе рекомендаций.
        /// </summary>
        /// <param name="getRecommendation">Объект, содержащий рекомендации.</param>
        /// <param name="existingRealty">Объект недвижимости.</param>
        /// <returns>Общий рейтинг объекта недвижимости.</returns>
        public decimal CalculateOverallRating(GetRecommendation getRecommendation, Realty existingRealty)
        {

            decimal comparisonPrice = getRecommendation.RatingPrice > existingRealty.Price
                ? (existingRealty.Price / getRecommendation.RatingPrice) : (getRecommendation.RatingPrice / existingRealty.Price);
            decimal comparisonFloor = getRecommendation.RatingFloоr > existingRealty.Floor
                ? (existingRealty.Floor / getRecommendation.RatingFloоr) : (getRecommendation.RatingFloоr / existingRealty.Floor);
            decimal comparisonSquare = getRecommendation.RatingSquare > existingRealty.Square
                ? (existingRealty.Square / getRecommendation.RatingPrice) : (getRecommendation.RatingSquare / existingRealty.Square);
            decimal comparisonRooms = getRecommendation.RatingRooms > existingRealty.Rooms
                ? (existingRealty.Rooms / getRecommendation.RatingRooms) : (getRecommendation.RatingRooms / existingRealty.Rooms);
            int comparisonCity = getRecommendation.RatingCity == existingRealty.City ? (1) : (0);
            int comparisonType = getRecommendation.RatingType == existingRealty.Type ? (1) : (0);
            int comparisonForWgat = getRecommendation.RatingForWhat == existingRealty.ForWhat ? (1) : (0);

            decimal overallRating = (comparisonPrice + comparisonFloor + comparisonSquare + comparisonRooms + comparisonCity
                + comparisonType + comparisonForWgat + (existingRealty.Mark / 5)) / 8;
            return overallRating;
        }

        /// <summary>
        /// Метод настраивает внешний вид элементов управления на форме.
        /// </summary>
        public void Design()
        {
            label1.Parent = Picture3;
            label1.BackColor = Color.Transparent;
            Address.Parent = Picture3;
            Address.BackColor = Color.Transparent;
            Price.Parent = Picture3;
            Price.BackColor = Color.Transparent;
            Square.Parent = Picture3;
            Square.BackColor = Color.Transparent;
            AmountOfFloors.Parent = Picture3;
            AmountOfFloors.BackColor = Color.Transparent;
            ProfileButton.Parent = Picture3;
            ProfileButton.BackColor = Color.Transparent;
            ProfileButton.FlatAppearance.BorderSize = 0;
            ProfileButton.FlatStyle = FlatStyle.Flat;
            FavButton.Parent = Picture3;
            FavButton.BackColor = Color.Transparent;
            FavButton.FlatAppearance.BorderSize = 0;
            FavButton.FlatStyle = FlatStyle.Flat;
            BlackListButton.Parent = Picture3;
            BlackListButton.BackColor = Color.Transparent;
            BlackListButton.FlatAppearance.BorderSize = 0;
            BlackListButton.FlatStyle = FlatStyle.Flat;
            MyCollectionsButton.Parent = Picture3;
            MyCollectionsButton.BackColor = Color.Transparent;
            MyCollectionsButton.FlatAppearance.BorderSize = 0;
            MyCollectionsButton.FlatStyle = FlatStyle.Flat;
            BackButton.Parent = Picture3;
            BackButton.BackColor = Color.Transparent;
            BackButton.FlatAppearance.BorderSize = 0;
            BackButton.FlatStyle = FlatStyle.Flat;
            StraightButton.Parent = Picture3;
            StraightButton.BackColor = Color.Transparent;
            StraightButton.FlatAppearance.BorderSize = 0;
            StraightButton.FlatStyle = FlatStyle.Flat;
            EstimateButton.Parent = Picture3;
            EstimateButton.BackColor = Color.Transparent;
            EstimateButton.FlatAppearance.BorderSize = 0;
            EstimateButton.FlatStyle = FlatStyle.Flat;
            AddressText.Parent = Picture3;
            AddressText.BackColor = Color.Transparent;
            PriceText.Parent = Picture3;
            PriceText.BackColor = Color.Transparent;
            SquareText.Parent = Picture3;
            SquareText.BackColor = Color.Transparent;
            FloorText.Parent = Picture3;
            FloorText.BackColor = Color.Transparent;
            AddFavButton.Parent = Picture3;
            AddFavButton.BackColor = Color.Transparent;
            AddFavButton.FlatAppearance.BorderSize = 0;
            AddFavButton.FlatStyle = FlatStyle.Flat;
            AddBlackListButton.Parent = Picture3;
            AddBlackListButton.BackColor = Color.Transparent;
            AddBlackListButton.FlatAppearance.BorderSize = 0;
            AddBlackListButton.FlatStyle = FlatStyle.Flat;
            button1.Parent = Picture3;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;


            WidthF = this.Width;
            HeightF = this.Height;
            HeightLoc = 773;
            WidthLoc = 464;

            tableLayoutPanel3.Width = 464;
            tableLayoutPanel3.Height = 773;
            tableLayoutPanel3.MaximumSize = new Size(612, 773);

            StraightButton.Location = new Point(662, 557);
            BackButton.Location = new Point(61, 557);

            MaximizeBox = true;
            tableLayoutPanel1.Controls.Add(Address, 0, 0);
            tableLayoutPanel1.Controls.Add(Price, 0, 1);
            tableLayoutPanel1.Controls.Add(Square, 0, 2);
            tableLayoutPanel1.Controls.Add(AmountOfFloors, 0, 3);
            tableLayoutPanel1.Controls.Add(AddressText, 1, 0);
            tableLayoutPanel1.Controls.Add(PriceText, 1, 1);
            tableLayoutPanel1.Controls.Add(SquareText, 1, 2);
            tableLayoutPanel1.Controls.Add(FloorText, 1, 3);

            tableLayoutPanel2.Controls.Add(AddBlackListButton, 0, 0);
            tableLayoutPanel2.Controls.Add(button1, 1, 0);
            tableLayoutPanel2.Controls.Add(EstimateButton, 2, 0);
            tableLayoutPanel2.Controls.Add(AddFavButton, 3, 0);

            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(RealtyPhoto, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 2);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutPanel3.Controls.Add(FormMyRecommendationButton, 0, 4);

            ProfileButton.Anchor = AnchorStyles.Top;
            FavButton.Anchor = AnchorStyles.Top;
            BlackListButton.Anchor = AnchorStyles.Top;
            MyCollectionsButton.Anchor = AnchorStyles.Top;
            FormMyRecommendationButton.Anchor = AnchorStyles.Bottom;
            Picture3.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tableLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tableLayoutPanel2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            RealtyPhoto.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            AddBlackListButton.Anchor = AnchorStyles.Left;
            button1.Anchor = AnchorStyles.Right;
            EstimateButton.Anchor = AnchorStyles.Left;
            AddFavButton.Anchor = AnchorStyles.Right;
            label1.Anchor = AnchorStyles.None;
            Address.Anchor = AnchorStyles.Left;
            Price.Anchor = AnchorStyles.Left;
            Square.Anchor = AnchorStyles.Left;
            AmountOfFloors.Anchor = AnchorStyles.Left;
            FormMyRecommendationButton.Anchor = AnchorStyles.Bottom;
            StraightButton.Anchor = AnchorStyles.Right;
            BackButton.Anchor = AnchorStyles.Left;

        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            if (WebAuto == null)
            {
                var profile = new Profile(Email!);
                profile.Show();
            }
            else
            {
                var profile = new Profile(WebAuto);
                profile.Show();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addList = new AddList();
            addList.Show();
        }

        private void FormMyRecommendationButton_Click(object sender, EventArgs e)
        {
            var testFirstWindow = new TestFirstWindow(Email!, this);
            testFirstWindow.Show();
        }

        private void FavButton_Click(object sender, EventArgs e)
        {
            var favorite = new Favorite(Email!);
            favorite.Show();
        }

        private void StraightButton_Click(object sender, EventArgs e)
        {
            if (SortList != null)
            {
                if (I++ < SortList.Count)
                {
                    I++;
                    FillRecommendation();
                }
            }


        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (SortList != null && CheckStringEmpty())
            {
                if (I-- > 0)
                {
                    I--;
                    FillRecommendation();
                }
            }

        }

        private void AddFavButton_Click(object sender, EventArgs e)
        {
            if (SortList != null && CheckStringEmpty())
            {
                new Favorite(IdRealryForFavBlMark, Email);
            }
        }

        private void AddBlackListButton_Click(object sender, EventArgs e)
        {
            if (SortList != null && CheckStringEmpty())
            {
                new BlackList(IdRealryForFavBlMark);
            }
        }

        private void BlackListButton_Click(object sender, EventArgs e)
        {
            var blackList = new BlackList();
            blackList.Show();
        }

        private void EstimateButton_Click(object sender, EventArgs e)
        {
            if (SortList != null && CheckStringEmpty())
            {
                var mark = new MarkWindow(IdRealryForFavBlMark);
                mark.Show();
            }
        }
        /// <summary>
        /// Метод проверяет пустые строки в карточки объекта
        /// </summary>
        public bool CheckStringEmpty()
        {
            if (RealtyPhoto.Image == null || AddressText.Text == null || PriceText.Text == null
                || FloorText.Text == null || SquareText.Text == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ToolTip profile = new ToolTip();
            profile.SetToolTip(ProfileButton, MainWindowLocal.MainWindowProfileText);
            ToolTip fav = new ToolTip();
            fav.SetToolTip(FavButton, MainWindowLocal.MainWindowFavoriteText);
            ToolTip black_list = new ToolTip();
            black_list.SetToolTip(BlackListButton, MainWindowLocal.MainWindowBlackListText);

            ToolTip add_bl = new ToolTip();
            add_bl.SetToolTip(AddBlackListButton, MainWindowLocal.AddBlackListText);
            ToolTip add_fav = new ToolTip();
            add_fav.SetToolTip(AddFavButton, MainWindowLocal.AddFavoriteText);
            ToolTip mark = new ToolTip();
            mark.SetToolTip(EstimateButton, MainWindowLocal.MainWindowMarkText);
            ToolTip next = new ToolTip();
            next.SetToolTip(StraightButton, MainWindowLocal.FollowRecommendationText);
            ToolTip back = new ToolTip();
            back.SetToolTip(BackButton, MainWindowLocal.PreviousRecommendationText);
            ToolTip list = new ToolTip();
            list.SetToolTip(MyCollectionsButton, MainWindowLocal.ListText);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addList = new AddList(IdRealryForFavBlMark, Email!);
            addList.Show();
        }
        private void MyCollectionsButton_Click(object sender, EventArgs e)
        {
            var compList = new MyCollections(Email!);
            compList.Show();
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel3.Width = (int)(((float)WidthLoc * ((float)this.Width / (float)WidthF)));
            tableLayoutPanel3.Height = (int)(((float)HeightLoc * ((float)this.Height / (float)HeightF)));

            int newX = (this.ClientSize.Width - tableLayoutPanel3.Width) / 2;
            int newY = (this.ClientSize.Height - tableLayoutPanel3.Height) / 2;
            tableLayoutPanel3.Location = new Point(newX, newY + 4);

        }


    }

}
