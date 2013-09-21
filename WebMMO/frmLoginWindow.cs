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
    public delegate void FormActionDelegate();
    public partial class frmLoginWindow : Form {
        public frmLoginWindow() {
            InitializeComponent();
        }

        void OnLoginResponseReceived(Client.LoginHandler sender) {
            this.Invoke(new FormActionDelegate(SetFormAsUsableAsync));
            if (sender.Status == Client.LoginResponse.FAILED) {
                MessageBox.Show(sender.ErrorMessage, "Login Failed");
            } else {
                this.Invoke(new FormActionDelegate(RunMainInterfaceAsync));
            }
        }

        private void SetFormAsUnusable() {
            loadingCircle_login.Visible = true;
            txt_LoginWindow_Username.ReadOnly = true;
            txt_LoginWindow_Password.ReadOnly = true;
            btn_LoginWindow_Login.Enabled = false;
            btn_LoginWindow_Quit.Enabled = false;
        }

        private void SetFormAsUsableAsync() {
            loadingCircle_login.Visible = false;
            txt_LoginWindow_Username.ReadOnly = false;
            txt_LoginWindow_Password.ReadOnly = false;
            btn_LoginWindow_Login.Enabled = true;
            btn_LoginWindow_Quit.Enabled = true;
        }

        private void RunMainInterfaceAsync() {
            FormManager.RunForm(new frmMainInterface());
            FormManager.CloseForm(this);
        }

        private void btn_LoginWindow_Login_Click(object sender, EventArgs e) {
            SetFormAsUnusable();
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
