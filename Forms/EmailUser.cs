using DB_993.Classes;
using DB_993.Resourse;

namespace DB_993.Forms
{
    public partial class EmailUser : Form
    {
        public WebAuto WebAuto { get; set; }
        public EmailUser(WebAuto webAuto)
        {
            InitializeComponent();
            WebAuto = webAuto;
        }

        private void Okbtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Okbtn.PerformClick();
        }

        private void Okbtn_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationContextBD())
            {
                var existingUser = context.Users.FirstOrDefault(user => user.Email == TextBoxEmail.Text);
                if (existingUser != null)
                {
                    MessageBox.Show(RegistrationWindowLocal.EmailTextReg);
                    return;
                }
                var patern = new PatternLogin();
                if (TextBoxEmail.Text != String.Empty && patern.CheckPattern(TextBoxEmail.Text) && TextBoxEmail.Text.Contains("@mail.ru"))
                {
                    var ccf = new CheckСodeForm(TextBoxEmail.Text, WebAuto);
                    ccf.Show();
                }
                else
                {
                    MessageBox.Show("Неправильный формат почты. Потча должна быть обязательно с \"@mail.ru\" ");
                }
            }
        }
    }
}
