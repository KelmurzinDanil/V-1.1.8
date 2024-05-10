using DB_993.Classes;
using DB_993.Forms;
using DB_993.Resourse;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace design
{
    /// <summary>
    /// Класс используется для регистрации пользователя в приложении.
    /// </summary>
    public partial class RegistrationWindow : Form
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            Design();
            MaximizeBox = false;
            PasswordRegText.PasswordChar = '*';
            LoginRegText.KeyPress += LoginRegText_KeyPress;
            PasswordRegText.KeyPress += PasswordRegText_KeyPress;
        }

        /// <summary>
        /// Метод настраивает внешний вид элементов управления на форме.
        /// </summary>
        public void Design()
        {
            label1.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;
            NameLabel.Parent = pictureBox2;
            NameLabel.BackColor = Color.Transparent;
            EmailLabel.Parent = pictureBox2;
            EmailLabel.BackColor = Color.Transparent;
            PasswordLabel.Parent = pictureBox2;
            PasswordLabel.BackColor = Color.Transparent;
        }

        private void PasswordRegText_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var edit = new EditInput();
            edit.PasswordEnter(e);
        }

        private void LoginRegText_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var edit = new EditInput();
            edit.FalseText(e);
        }
        private void RegistrationButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NameRegText.Text) || string.IsNullOrWhiteSpace(LoginRegText.Text) || string.IsNullOrWhiteSpace(PasswordRegText.Text))
            {
                MessageBox.Show(RegistrationWindowLocal.FieldsTextReg);
                return;
            }
            var editInput = new EditInput();
            if (editInput.CheckLogin(LoginRegText.Text) && LoginRegText.Text.Contains("@mail.ru"))
            {
                var check = new CheckСodeForm(LoginRegText.Text, PasswordRegText.Text, NameRegText.Text);
            check.Show();
            }
            else
            {
                MessageBox.Show("Неправильный формат почты. Потча должна быть обязательно с \"@mail.ru\" ");
            }
        }
    }
}
