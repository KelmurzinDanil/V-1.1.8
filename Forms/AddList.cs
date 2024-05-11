using DB_993.Classes;

namespace design
{
    /// <summary>
    /// Класс используется для добавления новых элементов.
    /// </summary>
    public partial class AddList : Form
    {
        public string Email { get; set; }
        public Dictionary<int, string> Dict { get; set; } = new();
        public int IdRealty { get; set; }
        public AddList()
        {
            InitializeComponent();
            Design();
            FillComboBox();
        }
        public AddList(int idRealty, string email)
        {
            InitializeComponent();
            Design();
            IdRealty = idRealty;
            Email = email;
            FillComboBox();

        }
        private void CreateCollectionButton_Click(object sender, EventArgs e)
        {
            CreateNewList createNewList = new CreateNewList(Email);
            createNewList.ShowDialog();
        }

        /// <summary>
        /// Метод настраивает внешний вид элементов управления на форме.
        /// </summary>
        public void Design()
        {
            Text1.Parent = Picture4;
            Text1.BackColor = Color.Transparent;

        }
        public void FillComboBox()
        {
            using (var context = new ApplicationContextBD())
            {
                var compilation = context.Compilations.Where(w => w.Email == Email).ToList();
                foreach (var comp in compilation)
                {
                    CollectionsCombo.Items.Add(comp.Name!).ToString();
                    Dict.Add(comp.Id, comp.Name!);
                }
            }
        }

        private void AddCollectionBtn_Click(object sender, EventArgs e)
        {
            if (CollectionsCombo.Text != String.Empty)
            {
                using (var context = new ApplicationContextBD())
                {
                    var realty = context.Realtys.FirstOrDefault(i => i.Id == IdRealty);
                    if (realty != null)
                    {
                        realty!.CompilationId = Dict.Keys.First(f => Dict[f] == CollectionsCombo.Text);
                        context.SaveChanges();
                    }

                }
            }
        }

        private void DeleteComp_Click(object sender, EventArgs e)
        {
            if (CollectionsCombo.Text != String.Empty)
            {
                using (var context = new ApplicationContextBD())
                {
                    var compilation = context.Compilations.FirstOrDefault(f => f.Name == CollectionsCombo.Text);
                    if (compilation != null)
                    {
                        if (compilation != null)
                        {
                            context.Entry(compilation)
                             .Collection(c => c.Users)
                             .Load();
                            context.Compilations.Remove(compilation);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
