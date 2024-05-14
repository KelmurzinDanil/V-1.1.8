using DB_993.Classes;
using System.Windows.Forms;
namespace design

{
    public partial class MyCollections : Form
    {
        public int Column1 { get; set; }
        public int Column2 { get; set; }
        public int HeightLoc { get; set; }
        public int WidthLoc { get; set; }
        public int HeightF { get; set; }
        public int WidthF { get; set; }
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
            Column1 = CompList.Columns[0].Width;
            Column2 = CompList.Columns[1].Width;
            Text1.Location = new Point((this.ClientSize.Width - Text1.Width) / 2, 4);
            CompList.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tableLayoutPanel1.BackColor = Color.Transparent;
            Text1.Parent = Picture7;
            Text1.BackColor = Color.Transparent;
            Picture7.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tableLayoutPanel1.Width = 639;
            WidthF = this.Width;
            HeightF = this.Height;
            tableLayoutPanel1.Height = 764;
            HeightLoc = 764;
            WidthLoc = 639;
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

        private void MyCollections_SizeChanged(object sender, EventArgs e)
        {

            tableLayoutPanel1.Width = (int)(((float)WidthLoc * ((float)this.Width / (float)WidthF)));
            tableLayoutPanel1.Height = (int)(((float)HeightLoc * ((float)this.Height / (float)HeightF)));

            CompList.Columns[0].Width = (int)(Column1 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));
            CompList.Columns[1].Width = (int)(Column2 * ((float)tableLayoutPanel1.Width / (float)WidthLoc));

            int newX = (this.ClientSize.Width - tableLayoutPanel1.Width) / 2;
            int newY = (this.ClientSize.Height - tableLayoutPanel1.Height) / 2;
            tableLayoutPanel1.Location = new Point(newX, newY);

            Text1.Location = new Point((this.ClientSize.Width - Text1.Width) / 2, 4);
        }
    }
}
