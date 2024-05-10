using DB_993.Classes;
using DB_993.Forms;
using DB_993.Resourse;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace design
{
    /// <summary>
    /// Класс используется для просмотра и редактирования электронной почты, имени пользователя.
    /// </summary>
    public partial class Profile : Form
    {
        string? Email_ { get; set; }
        public WebAuto WebAuto { get; set; }
        public Profile()
        {
            InitializeComponent();
            SaveButton.Hide();
            LoadUserData();
            Design();
            NameText.ReadOnly = true;
            EmailText.ReadOnly = true;
            EmailText.KeyPress += EmailText_KeyPress;

        }
        public Profile(WebAuto webAuto)
        {
            WebAuto = webAuto;
            InitializeComponent();
            SaveButton.Hide();
            LoadUserDataWeb();
            EditButton.Visible = false;
            Design();
            NameText.ReadOnly = true;
            EmailText.ReadOnly = true;
            EmailText.KeyPress += EmailText_KeyPress;


        }

        public Profile(string email)
        {
            Email_ = email;
            InitializeComponent();
            SaveButton.Hide();
            LoadUserData();
            Design();
            NameText.ReadOnly = true;
            EmailText.ReadOnly = true;
            EmailText.KeyPress += EmailText_KeyPress;

        }

        /// <summary>
        /// Метод настраивает внешний вид элементов управления на форме.
        /// </summary>
        public void Design()
        {
            label1.Parent = Picture4;
            label1.BackColor = Color.Transparent;
            label2.Parent = Picture4;
            label2.BackColor = Color.Transparent;
            label3.Parent = Picture4;
            label3.BackColor = Color.Transparent;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            NameText.ReadOnly = false;
            EmailText.ReadOnly = false;

            SaveButton.Show();
        }
        public void LoadUserDataWeb()
        {
            string[] profile = WebAuto.GetMyProfile();
            NameText.Text = profile[0] + " " + profile[1];
            EmailText.Text = profile[2];  
        }
        private void LoadUserData()
        {
            using (var context = new ApplicationContextBD())
            {

                var user = context.Users.FirstOrDefault(user => user.Email == Email_);
                if (user != null)
                {
                    NameText.Text = user.Name ?? string.Empty;
                    EmailText.Text = user.Email ?? string.Empty;
                }
            }
        }

        private void EmailText_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var edit = new EditInput();
            edit.FalseText(e);
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameText.Text) || string.IsNullOrWhiteSpace(EmailText.Text))
            {
                MessageBox.Show(ProfileLocal.FieldsTextProfile);
                return;
            }

            using (var context = new ApplicationContextBD())
            {

                var existingUser = context.Users.FirstOrDefault(user => user.Email == EmailText.Text && user.Email != Email_);
                if (existingUser != null)
                {
                    MessageBox.Show(ProfileLocal.EmailTextProfile);
                    return;
                }
                var user = context.Users.FirstOrDefault(user => user.Email == Email_);
                var editInput = new EditInput();
                if (editInput.CheckLogin(EmailText.Text))
                {
                    if (user != null)
                    {
                        user.Name = NameText.Text;
                        user.Email = EmailText.Text;
                        context.SaveChanges();
                        MessageBox.Show(ProfileLocal.DataTextProfile);
                    }
                    else
                    {
                        MessageBox.Show(ProfileLocal.UserTextProfile);
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный формат почты");
                }

            }
        }
        
    }
}
