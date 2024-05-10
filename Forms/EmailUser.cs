using DB_993.Classes;

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
            var patern = new EditInput();
            if (TextBoxEmail.Text != String.Empty && patern.CheckLogin(TextBoxEmail.Text) && TextBoxEmail.Text.Contains("@mail.ru"))
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
