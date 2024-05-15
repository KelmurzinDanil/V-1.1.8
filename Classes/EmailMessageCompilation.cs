using DB_993.Interfaces;
using System.Net;
using System.Net.Mail;

namespace DB_993.Classes
{
    internal class EmailMessageCompilation : IEmailMessage
    {
        public void PushEmailMessage(string email, int idComp)
        {

        }
        public void PushEmailMessage(string email, string r)
        {
            using (var context = new ApplicationContextBD())
            {
                try
                {
                    var from = new MailAddress("testikovich77@mail.ru", "ООО ДДД");
                    var to = new MailAddress(email);
                    var m = new MailMessage(from, to);
                    List<Realty> realty;
                    if (r != String.Empty)
                    {
                        realty = context.Realtys.OrderByDescending(o => o.Mark).ToList();
                    }
                    else
                    {
                        realty = context.Compilations.Where(w => w.Name == r).Select(u => u.Realtys).FirstOrDefault()!;
                    }
                    string textComp = String.Empty;
                    string messegeText = String.Empty;
                    string imagePath = String.Empty;
                    for (int i = 0; i < realty?.Count; i++)
                    {
                        m.Attachments.Add(new Attachment(realty[i].PhotoRealty!));
                        textComp = $"<p>Название - {realty[i].NameRealty}," +
                            $"<br/> Цена - {realty[i].Price}," +
                            $"<br/> Адрес - {realty[i].Address}," +
                            $"<br/> Площадь - {realty[i].Square}," +
                            $"<br/> Этажи - {realty[i].Floor}," +
                            $"<br/> Комнаты - {realty[i].Rooms}," +
                            $"<br/> Город - {realty[i].City}," +
                            $"<br/> Тип - {realty[i].Type}," +
                            $"<br/> Для чего - {realty[i].ForWhat}</p>";
                        messegeText = string.Concat(messegeText, textComp);
                    }
                    m.Subject = "Подборка";
                    m.Body = $"<h2>{messegeText}</h2>";
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
        }
    }
}
