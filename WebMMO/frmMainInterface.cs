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
    public partial class frmMainInterface : Form {
        public frmMainInterface() {
            InitializeComponent();
        }

        private void MainInterface_Load(object sender, EventArgs e) {
            SetVisibleUserStats(SessionManager.Instance.CurrentUser);
        }

        private void SetVisibleUserStats(User user) {
            lbl_user_username.Text = "Player: " + user.Username;
            lbl_user_level.Text = "Level: " + user.Data.CombatLevel.ToString("N0");
            lbl_user_exp.Text = "Exp: " + user.Data.CombatExperience.ToString("N0");
            lbl_user_hp.Text = "HP: " + user.Data.CombatStatistics.HP.ToString("N0");
            lbl_user_strength.Text = "Strength: " + user.Data.CombatStatistics.Strength.ToString("N1");
            lbl_user_vitality.Text = "Vitality: " + user.Data.CombatStatistics.Vitality.ToString("N1");
            lbl_user_magic.Text = "Magic: " + user.Data.CombatStatistics.Magic.ToString("N1");
            lbl_user_spirit.Text = "Spirit: " + user.Data.CombatStatistics.Spirit.ToString("N1");
            lbl_user_speed.Text = "Speed: " + user.Data.CombatStatistics.Speed.ToString("N1");
            lbl_user_evade.Text = "Evade: " + user.Data.CombatStatistics.Evade.ToString("N1");
            lbl_user_hit.Text = "Hit: " + user.Data.CombatStatistics.Hit.ToString("N1");
            lbl_user_luck.Text = "Luck: " + user.Data.CombatStatistics.Luck.ToString("N1");
        }

        private void toolstrip_system_logout_Click(object sender, EventArgs e) {
            FormManager.RunForm(new frmLoginWindow());
            FormManager.CloseForm(this);
        }

        private void toolstrip_system_exit_Click(object sender, EventArgs e) {
            FormManager.CloseForm(this);
            Application.Exit();
        }
    }
}
