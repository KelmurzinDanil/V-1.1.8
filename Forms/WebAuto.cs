using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json.Linq;
using System.Net;

namespace DB_993.Forms
{
    public partial class WebAuto : Form
    {
        public WebAuto()
        {
            InitializeComponent();
            webView21.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            webView21.Dock = DockStyle.Fill;
        }
        const int AppID = 51920258; //ID нашего приложения

        private string access_token = null!; //ключ сессии
        private string user_id = null!; //ID авторизованного пользователя
        public bool Authorize()
        {
            access_token = null!;
            user_id = null!;
            var authform = new WebAuto();
            var webView2 = (WebView2)authform.webView21;
            webView2.NavigationStarting += new EventHandler<CoreWebView2NavigationStartingEventArgs>(Authorize_proceed);
            webView2.Source = new Uri("https://api.vkontakte.ru/oauth/authorize?client_id=" + AppID.ToString() +
            "&scope=photos&redirect_uri=" +
            "https://api.vkontakte.ru/blank.html&display=popup&response_type=token");
            authform.ShowDialog();

            if (access_token == null || user_id == null) return false;
            else return true;
        }
        private void Authorize_proceed(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            string[] parts = e.Uri.Split('#');
            var browser = (WebView2)sender;
            if (parts[0] == "https://api.vkontakte.ru/blank.html")
            {
                if (parts[1].Substring(0, 5) == "error") this.Close();
                else if (parts[1].Substring(0, 12) == "access_token")
                {
                    parts = parts[1].Split('&');
                    access_token = parts[0].Split('=')[1];
                    user_id = parts[2].Split('=')[1];
                    this.Close();
                }
            }
            else
            {
                parts = e.Uri.Split('?');
                if (parts[0] == "https://api.vkontakte.ru/oauth/grant_access")
                    browser.Source = new Uri("https://api.vkontakte.ru/oauth/authorize?client_id=" + AppID.ToString() +
                    "&scope=photos&redirect_uri=" +
                    "https://api.vkontakte.ru/blank.html&display=popup&response_type=token");
            }
        }
        public string[] GetMyProfile()
        {
            //"https://api.vkontakte.ru/method/users.get?user_ids=" метод users.get
            //"https://api.vk.com/method/auth.exchangeSilentAuthToken?" почему-то не работает
            //"https://api.vkontakte.ru/method/account.getProfileInfo?user_id=" метод account.getProfileInfo
            string profiles = "https://api.vkontakte.ru/method/users.get?user_ids=" + user_id +
            "&access_token=" + access_token + "&fields=email" + "&v=5.199";
            var reqGET = WebRequest.Create(profiles);
            var resp = reqGET.GetResponse();
            var stream = resp.GetResponseStream();
            var sr = new StreamReader(stream);
            string json = sr.ReadToEnd();

            var o = JObject.Parse(json);
            var response = (JArray)o["response"]!;

            string[] profile = new string[3];
            profile[0] = (string)response[0]["first_name"]!;
            profile[1] = (string)response[0]["last_name"]!;
            profile[2] = (string)response[0]["id"]!;
            return profile;
        }
    }
}

