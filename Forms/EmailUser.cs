using DB_993.Classes;
using DB_993.Resourse;
using design;

namespace DB_993.Forms
{
    public partial class EmailUser : Form
    {
        public WebAuto WebAuto { get; set; }
        public OpenWindow AutoWindow { get; set; }
        public EmailUser(WebAuto webAuto, OpenWindow auto)
        {
            InitializeComponent();
            WebAuto = webAuto;
            AutoWindow = auto;
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
                    var ccf = new CheckСodeForm(TextBoxEmail.Text, WebAuto, AutoWindow);
                    this.Close();
                    ccf.Show();
                }
                else
                {
                    MessageBox.Show(EmailUserLocal.EmailUserText);
                }
            }
        }
    }
}
