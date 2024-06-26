﻿using DB_993.Classes;
using design;

namespace DB_993.Forms
{
    public partial class CheckСodeForm : Form
    {
        public OpenWindow AutoWindow { get; set; }
        public RegistrationWindow Registration { get; set; }
        public WebAuto WebAuto { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Generate { get; set; }
        public int Status { get; set; } = 0;
        public CheckСodeForm(string email, string password, string name, RegistrationWindow registration)
        {
            InitializeComponent();
            Email = email;
            Password = password;
            Name = name;
            CodeInEmail();
            Registration = registration;
        }
        public CheckСodeForm(string email, WebAuto webAuto, OpenWindow auto)
        {
            InitializeComponent();
            Email = email;
            WebAuto = webAuto;
            CodeInEmail();
            AutoWindow = auto;
        }
        public void CodeInEmail()
        {
            var generator = new Random();
            var r = generator.Next(0, 1000000).ToString("D6");
            Generate = r;
            var emailMessageCode = new EmailMessageCode();
            emailMessageCode.PushEmailMessage(Email, Generate);
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
                var editInput = new PatternLogin();
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
                        Name = profile[0] + " " + profile[1],
                        VkId = int.Parse(profile[2])
                    };
                }
                context.Users.Add(newUser);
                context.SaveChanges();
                //MessageBox.Show(CheckCodeLocal.CheckCodeText);
                var mainWindow = new MainWindow(Email);
                if (AutoWindow != null)
                {
                    AutoWindow.Visible = false;

                }
                else
                {
                    Registration.Visible = false;
                }
                mainWindow.Show();
            }
        }
    }
}
