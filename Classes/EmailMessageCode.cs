using DB_993.Interfaces;
using System.Net;
using System.Net.Mail;

namespace DB_993.Classes
{
    internal class EmailMessageCode : IEmailMessage
    {
        public void PushEmailMessage(string email, string r)
        {
            try
            {
                var from = new MailAddress("testikovich77@mail.ru", "ООО ДДД");
                var to = new MailAddress(email);
                var m = new MailMessage(from, to);
                m.Subject = "Код";
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
        public void PushEmailMessage(string email, int IdComp) { }
    }
}
