using DB_993.Classes;
using DB_993.Resourse;
using design;
using System.Net;
using System.Net.Mail;

namespace DB_993.Forms
{
    public partial class CheckСodeForm : Form
    {
        public WebAuto WebAuto { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Generate { get; set; }
        public int Status { get; set; } = 0;
        public CheckСodeForm(string email, string password, string name)
        {
            InitializeComponent();
            Email = email;
            Password = password;
            Name = name;
            CodeInEmail();
        }
        public CheckСodeForm(string email, WebAuto webAuto)
        {
            InitializeComponent();
            Email = email;
            WebAuto = webAuto;
            CodeInEmail();
        }
        public void CodeInEmail()
        {
            var generator = new Random();
            var r = generator.Next(0, 1000000).ToString("D6");
            Generate = r;
            try
            {
                var from = new MailAddress("testikovich77@mail.ru", "ООО ДДД");
                var to = new MailAddress(Email);
                var m = new MailMessage(from, to);
                m.Subject = "Подборка";
                m.Body = $"<h2>{r}</h2>";
                m.IsBodyHtml = true;
                var smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("testikovich77@mail.ru", "SS9rxQxQp63Yhi1jgXvx");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка. Возможно ваша почта не существует");
            }
        }

        private void TextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text == Generate)
            {
                this.Close();
                Status = 1;
                InDB();
            }
        }
        public void InDB()
        {
            using (var context = new DB_993.Classes.ApplicationContextBD())
            {
                var existingUser = context.Users.FirstOrDefault(user => user.Email == Email);              
                if (existingUser != null)
                {
                    MessageBox.Show(RegistrationWindowLocal.EmailTextReg);
                    return;
                }
                var editInput = new EditInput();
                User newUser;
                if (Name != null && Password != null)
                {
                    var heshPassword = new HashPassword();
                    newUser = new User
                    {
                        Name = Name,
                        Email = Email,
                        Password = heshPassword.GetPassword(Password)
                    };
                }
                else
                {
                    string[] profile = WebAuto.GetMyProfile();
                    newUser = new User
                    {
                        Email = Email,
                        Name = profile[0] + " " + profile[1]
                    };
                }
                context.Users.Add(newUser);
                context.SaveChanges();
                MessageBox.Show(RegistrationWindowLocal.RegText);
                var mainWindow = new MainWindow(Email);
                mainWindow.Show();


            }
        }
    }
}
