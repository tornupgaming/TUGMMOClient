using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TUGLib.Forms;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Client
{
    public class SessionManager
    {
        private static SessionManager _Instance;
        public static SessionManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SessionManager();
                }
                return _Instance;
            }
        }
            
        // -------------------
        #region Login Handling
        // -------------------

        private LoginHandler m_CurrentLoginHandler;
        private string m_User, m_Pass;
        public LoginHandler CreateWithLoginDetails(string username, string password)
        {
            if (m_CurrentLoginHandler != null)
            {
                LogHandler.Log("Login Handler already active: Returning previous handler");
                return m_CurrentLoginHandler;
            }
            m_User = username;
            m_Pass = password;
            m_CurrentLoginHandler = new LoginHandler(username, password);
            m_CurrentLoginHandler.OnLoginResponseReceived += OnLoginResponseReceived;            
            return m_CurrentLoginHandler;
        }

        private void OnLoginResponseReceived(LoginHandler sender)
        {
            ReleaseLoginHandler();
        }

        private void ReleaseLoginHandler()
        {
            LogHandler.Log("Releasing login handler: " + m_CurrentLoginHandler.GetHashCode());
            m_CurrentLoginHandler.OnLoginResponseReceived -= OnLoginResponseReceived;
            m_CurrentLoginHandler = null;
        }

        // -------------------
        #endregion
        // -------------------

        // -------------------
        #region User Data
        // -------------------

        private User m_CurrentUser;
        public User CurrentUser {
            get {
                if (m_CurrentUser == null) {
                    m_CurrentUser = new User();
                }
                return m_CurrentUser;
            }
        }
        public void CreateUserFromJTokenResponse(JToken userData) {
            CurrentUser.ParseFromUserData(userData);
        }

        // -------------------
        #endregion
        // -------------------
    }
}
