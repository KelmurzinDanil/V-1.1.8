using DB_993.Classes;
using DB_993.Resourse;
namespace design
{
    /// <summary>
    /// Класс используется для отображения и взаимодействия с коллекцией карточек.
    /// </summary>
    public partial class CollectionCard : Form
    {
        public int Column1 { get; set; }
        public int Column2 { get; set; }
        public int Column3 { get; set; }
        public int Column4 { get; set; }
        public int HeightLoc { get; set; }
        public int WidthLoc { get; set; }
        public int HeightF { get; set; }
        public int WidthF { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public CollectionCard(string name, string email)
        {
            InitializeComponent();
            Name = name;
            Email = email;
            LoadData();
            Design();
        }
        public void Design()
        {
            Column1 = ListRealtyComp.Columns[0].Width;
            Column2 = ListRealtyComp.Columns[1].Width;
            Column3 = ListRealtyComp.Columns[2].Width;
            Column4 = ListRealtyComp.Columns[3].Width;
            ListRealtyComp.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            EditButton.Anchor = AnchorStyles.Left;
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.Width = 634;
            WidthF = this.Width;
            HeightF = this.Height;
            tableLayoutPanel1.Height = 760;
            HeightLoc = 760;
            WidthLoc = 634;
            Picture7.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

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
            MessageBox.Show(CollectionCardLocal.CollectionCardText);
        }

        private void CollectionCard_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Width = (int)(((float)WidthLoc * ((float)this.Width / (float)WidthF)));
            tableLayoutPanel1.Height = (int)(((float)HeightLoc * ((float)this.Height / (float)HeightF)));


            ListRealtyComp.Columns[0].Width = (int)(Column1 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));
            ListRealtyComp.Columns[1].Width = (int)(Column2 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));
            ListRealtyComp.Columns[2].Width = (int)(Column3 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));
            ListRealtyComp.Columns[3].Width = (int)(Column4 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));

            int newX = (this.ClientSize.Width - tableLayoutPanel1.Width) / 2;
            int newY = (this.ClientSize.Height - tableLayoutPanel1.Height) / 2;
            tableLayoutPanel1.Location = new Point(newX, newY);

        }
    }
}
