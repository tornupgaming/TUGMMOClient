using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TUGLib.Web;
using Newtonsoft.Json.Linq;
using TUGLib.Forms;
using System.Threading;

namespace Client {
    public delegate void LoginResponseHandler(LoginHandler sender);
    public class LoginHandler {
        public event LoginResponseHandler OnLoginResponseReceived;

        public LoginResponse Status;
        public string ErrorMessage;
        public JToken UserData;
        private string m_User, m_Pass;

        public LoginHandler(string user, string pass) {
            m_User = user;
            m_Pass = pass;
            LogHandler.Log("Created new LoginHandler: " + this.GetHashCode());
        }

        public void LoginAsync() {
            new Thread(new ThreadStart(Login)).Start();
        }

        private void Login() {
            LogHandler.Log("Logging in within thread");
            ParseLoginResponse(HtmlHelper.GetStringResponseFromURL(
                "http://www.tornupgaming.com/orpg/login.php", SessionManager.Cookies, "user=" + m_User + "&pass=" + m_Pass));
        }

        private void ParseLoginResponse(string response) {
            JObject data = JObject.Parse(response);
            Status = ParseLoginValue(data["login"].ToString());
            if (Status == LoginResponse.SUCCESS) {
                UserData = data["userdata"];
                SessionManager.Instance.CreateUserFromJTokenResponse(UserData);
            } else {
                ErrorMessage = data["reason"].ToString();
            }

            // Let everyone else know we've logged in and parsed input
            OnLoginResponseReceived(this);
        }

        private static LoginResponse ParseLoginValue(string loginValue) {
            return (loginValue == "success") ? LoginResponse.SUCCESS : LoginResponse.FAILED;
        }
    }
}
