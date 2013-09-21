namespace WebMMO
{
    partial class frmLoginWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_LoginWindow_Username = new System.Windows.Forms.TextBox();
            this.txt_LoginWindow_Password = new System.Windows.Forms.TextBox();
            this.btn_LoginWindow_Login = new System.Windows.Forms.Button();
            this.btn_LoginWindow_Quit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadingCircle_login = new MRG.Controls.UI.LoadingCircle();
            this.SuspendLayout();
            // 
            // txt_LoginWindow_Username
            // 
            this.txt_LoginWindow_Username.Location = new System.Drawing.Point(77, 11);
            this.txt_LoginWindow_Username.Name = "txt_LoginWindow_Username";
            this.txt_LoginWindow_Username.Size = new System.Drawing.Size(157, 20);
            this.txt_LoginWindow_Username.TabIndex = 0;
            // 
            // txt_LoginWindow_Password
            // 
            this.txt_LoginWindow_Password.Location = new System.Drawing.Point(78, 37);
            this.txt_LoginWindow_Password.Name = "txt_LoginWindow_Password";
            this.txt_LoginWindow_Password.PasswordChar = '*';
            this.txt_LoginWindow_Password.Size = new System.Drawing.Size(156, 20);
            this.txt_LoginWindow_Password.TabIndex = 1;
            // 
            // btn_LoginWindow_Login
            // 
            this.btn_LoginWindow_Login.Location = new System.Drawing.Point(12, 94);
            this.btn_LoginWindow_Login.Name = "btn_LoginWindow_Login";
            this.btn_LoginWindow_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_LoginWindow_Login.TabIndex = 2;
            this.btn_LoginWindow_Login.Text = "Login";
            this.btn_LoginWindow_Login.UseVisualStyleBackColor = true;
            this.btn_LoginWindow_Login.Click += new System.EventHandler(this.btn_LoginWindow_Login_Click);
            // 
            // btn_LoginWindow_Quit
            // 
            this.btn_LoginWindow_Quit.Location = new System.Drawing.Point(159, 94);
            this.btn_LoginWindow_Quit.Name = "btn_LoginWindow_Quit";
            this.btn_LoginWindow_Quit.Size = new System.Drawing.Size(75, 23);
            this.btn_LoginWindow_Quit.TabIndex = 3;
            this.btn_LoginWindow_Quit.Text = "Quit";
            this.btn_LoginWindow_Quit.UseVisualStyleBackColor = true;
            this.btn_LoginWindow_Quit.Click += new System.EventHandler(this.btn_LoginWindow_Quit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // loadingCircle_login
            // 
            this.loadingCircle_login.Active = true;
            this.loadingCircle_login.Color = System.Drawing.Color.RoyalBlue;
            this.loadingCircle_login.InnerCircleRadius = 8;
            this.loadingCircle_login.Location = new System.Drawing.Point(86, 65);
            this.loadingCircle_login.Name = "loadingCircle_login";
            this.loadingCircle_login.NumberSpoke = 24;
            this.loadingCircle_login.OuterCircleRadius = 9;
            this.loadingCircle_login.RotationSpeed = 40;
            this.loadingCircle_login.Size = new System.Drawing.Size(75, 23);
            this.loadingCircle_login.SpokeThickness = 4;
            this.loadingCircle_login.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.IE7;
            this.loadingCircle_login.TabIndex = 6;
            this.loadingCircle_login.Text = "loadingCircle1";
            this.loadingCircle_login.Visible = false;
            // 
            // LoginWindow
            // 
            this.AcceptButton = this.btn_LoginWindow_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 129);
            this.ControlBox = false;
            this.Controls.Add(this.loadingCircle_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_LoginWindow_Quit);
            this.Controls.Add(this.btn_LoginWindow_Login);
            this.Controls.Add(this.txt_LoginWindow_Password);
            this.Controls.Add(this.txt_LoginWindow_Username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginWindow";
            this.Text = "Torn Up Gaming Web MMO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_LoginWindow_Username;
        private System.Windows.Forms.TextBox txt_LoginWindow_Password;
        private System.Windows.Forms.Button btn_LoginWindow_Login;
        private System.Windows.Forms.Button btn_LoginWindow_Quit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MRG.Controls.UI.LoadingCircle loadingCircle_login;
    }
}

