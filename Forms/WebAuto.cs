using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Json.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json.Linq;
using System.Net;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System;

namespace DB_993.Forms
{
    public partial class WebAuto : Form
    {
        public WebAuto()
        {
            InitializeComponent();
        }
        const int AppID = 51920258; //ID нашего приложения

        private string access_token = null!; //ключ сессии
        private string user_id = null!; //ID авторизованного пользователя
        public bool Authorize()
        {
            access_token = null!;
            user_id = null!;
            //создаем форму авторизации
            WebAuto authform = new WebAuto();
            //получаем объект компонента WebView2
            var webView2 = (WebView2)authform.webView21;
            //Подписываемся на событие NavigationCompleted в функции Authorize_proceed
            webView2.NavigationStarting += new EventHandler<CoreWebView2NavigationStartingEventArgs>(Authorize_proceed);
            //переходим на страницу авторизации с нужными нам данными.
            webView2.Source = new Uri("https://api.vkontakte.ru/oauth/authorize?client_id=" + AppID.ToString() +
            "&scope=photos&redirect_uri=" +
            "https://api.vkontakte.ru/blank.html&display=popup&response_type=token");
            //показываем диалог авторизации
            authform.ShowDialog();

            //проверяем были ли мы авторизованы и возвращаем значение
            if (access_token == null || user_id == null) return false;
            else return true;
        }
        private void Authorize_proceed(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            //Разбираем ссылку на кусочки
            string[] parts = e.Uri.Split('#');
            //получаем объект браузера
            WebView2 browser = (WebView2)sender;
            //проверяем, что нас перенаправили на нужный адрес при успешной авторизации
            if (parts[0] == "https://api.vkontakte.ru/blank.html")
            {
                //если ошибка, закрываем форму
                if (parts[1].Substring(0, 5) == "error") this.Close();
                //если авторизация успешна
                else if (parts[1].Substring(0, 12) == "access_token")
                {
                    //разбираем ответ
                    parts = parts[1].Split('&');

                    //записываем данные
                    access_token = parts[0].Split('=')[1];
                    user_id = parts[2].Split('=')[1];
                    //закрываем форму авторизации
                    this.Close();
                }
            }
            else
            {
                //неизвестный ответ при неудачном входе и нажатии кнопки "отмена"
                parts = e.Uri.Split('?');
                if (parts[0] == "https://api.vkontakte.ru/oauth/grant_access")
                    //снова переходим к авторизации
                    browser.Source = new Uri("https://api.vkontakte.ru/oauth/authorize?client_id=" + AppID.ToString() +
                    "&scope=photos&redirect_uri=" +
                    "https://api.vkontakte.ru/blank.html&display=popup&response_type=token");
            }
        }
        public string[] GetMyProfile()
        {
            //"https://api.vkontakte.ru/method/users.get?user_ids=" метод users.get
            //"https://api.vk.com/method/auth.exchangeSilentAuthToken?" 
            //"https://api.vkontakte.ru/method/account.getProfileInfo?user_id=" 
            string profiles = "https://api.vkontakte.ru/method/users.get?user_ids=" + user_id +
            "&access_token=" + access_token + "&fields=email" + "&v=5.199";
            WebRequest reqGET = WebRequest.Create(profiles);
            WebResponse resp = reqGET.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string json = sr.ReadToEnd();

            JObject o = JObject.Parse(json);
            JArray response = (JArray)o["response"]!;
            
            string[] profile = new string[3];
            profile[0] = (string)response[0]["first_name"]!;
            profile[1] = (string)response[0]["last_name"]!;
            profile[2] = (string)response[0]["email"]!;
            return profile;
        }
    }
}

