using DB_993.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
    }
}
