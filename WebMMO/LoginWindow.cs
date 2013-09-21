using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client;

namespace WebMMO {
    public delegate void CloseFormDelegate();
    public partial class LoginWindow : Form {
        public LoginWindow() {
            InitializeComponent();
        }

        void OnLoginResponseReceived(Client.LoginHandler sender) {
            if (sender.Status == Client.LoginResponse.FAILED) {
                MessageBox.Show(sender.ErrorMessage, "Login Failed");
            } else {
                MainInterface inter = new MainInterface();
                inter.Show();
                this.Invoke(new CloseFormDelegate(this.Close));
            }
        }

        private void btn_LoginWindow_Login_Click(object sender, EventArgs e) {
            LoginHandler loginHandler = 
                SessionManager.Instance.CreateWithLoginDetails(txt_LoginWindow_Username.Text,txt_LoginWindow_Password.Text);
            loginHandler.OnLoginResponseReceived += OnLoginResponseReceived;
            loginHandler.LoginAsync();
        }

        private void btn_LoginWindow_Quit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
