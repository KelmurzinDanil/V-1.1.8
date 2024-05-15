using DB_993.Classes;
using DB_993.Resourse;
namespace design
{
    /// <summary>
    /// Класс используется для создания нового элемента.
    /// </summary>
    public partial class CreateNewList : Form
    {
        string Email { get; set; }
        public CreateNewList(string email)
        {
            InitializeComponent();
            Design();
            Email = email;
        }

        /// <summary>
        /// Метод настраивает внешний вид элементов управления на форме.
        /// </summary>
        public void Design()
        {
            Text1.Parent = Picture5;
            Text1.BackColor = Color.Transparent;
            Text2.Parent = Picture5;
            Text2.BackColor = Color.Transparent;
        }


        private void CreateCollectionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CollectionNameText.Text))
            {
                MessageBox.Show("Название не должно быть пустым");
                return;
            }
            using (var context = new ApplicationContextBD())
            {
                var comp = context.Compilations.FirstOrDefault(d => d.Name == CollectionNameText.Text);
                if (comp != null)
                {
                    MessageBox.Show(CreateNewListLocal.ListText);
                    return;
                }
                var newCompilation = new Compilation
                {
                    Name = CollectionNameText.Text,
                    Email = Email,
                    Users = { context!.Users!.FirstOrDefault(fav => fav!.Email == Email)! }
                };
                context.Compilations.Add(newCompilation);
                context.SaveChanges();
            }
            this.Close();
            MessageBox.Show("Создано");


        }
    }
}
