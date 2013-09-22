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
        private BattleHandler m_CurrentBattleHandler;
        private BattleAction[] m_BattleActions;
        private Timer m_BattleTimer;
        private int m_BattleActionIndex = 0;
        private float m_PlayerHP, m_EnemyHP;

        public frmMainInterface() {
            InitializeComponent();
        }

        private void MainInterface_Load(object sender, EventArgs e) {
            SetVisibleUserStats(SessionManager.Instance.CurrentUser);
            panel_combat.Visible = false;
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

        private void toolstrip_command_attack_lvl1mob_Click(object sender, EventArgs e) {
            m_CurrentBattleHandler = SessionManager.Instance.CreateBattle(0);
            m_CurrentBattleHandler.OnResponseReceived += battle_OnResponseReceived;
            m_CurrentBattleHandler.PerformBattle();
        }

        void battle_OnResponseReceived(WebResponseHandler sender) {
            this.Invoke(new FormActionDelegate(PlayBattleAsync));
        }

        private void PlayBattleAsync() {
            panel_combat.Visible = true;

            lbl_combat_mobname.Text = m_CurrentBattleHandler.EnemyName;

            m_PlayerHP = SessionManager.Instance.CurrentUser.Data.CombatStatistics.HP;
            m_EnemyHP = m_CurrentBattleHandler.EnemyHP;

            bar_combat_playerhp.Maximum = (int)m_PlayerHP;
            bar_combat_enemyhp.Maximum = (int)m_EnemyHP;

            bar_combat_playerhp.Value = (int)m_PlayerHP;
            bar_combat_enemyhp.Value = (int)m_EnemyHP;

            list_combat_battlelog.Items.Clear();

            m_BattleActionIndex = 0;
            m_BattleActions = m_CurrentBattleHandler.BattleActions;

            m_BattleTimer = new Timer();
            m_BattleTimer.Interval = 2000;
            m_BattleTimer.Tick += new EventHandler(m_BattleTimer_Tick);
            m_BattleTimer.Enabled = true;
        }

        void m_BattleTimer_Tick(object sender, EventArgs e) {
            float dmg = m_BattleActions[m_BattleActionIndex].Damage;
            switch (m_BattleActions[m_BattleActionIndex].ActionType) {
                case BattleActionType.MONSTER_DAMAGE:
                    m_EnemyHP -= dmg;
                    m_EnemyHP = Math.Max(m_EnemyHP, 0.0f);
                    bar_combat_enemyhp.Value = (int)m_EnemyHP;
                    list_combat_battlelog.Items.Add("Hit " + m_CurrentBattleHandler.EnemyName + " for " + dmg.ToString("N3") + " damage");
                    break;
                case BattleActionType.PLAYER_DAMAGE:                    
                    m_PlayerHP -= dmg;
                    m_PlayerHP = Math.Max(m_PlayerHP, 0.0f);
                    bar_combat_playerhp.Value = (int)m_PlayerHP;
                    list_combat_battlelog.Items.Add("You took " + dmg.ToString("N3") + " damage");
                    break;
            }

            m_BattleActionIndex++;

            if (m_BattleActionIndex >= m_BattleActions.Length) {
                if (m_CurrentBattleHandler.Victory) {
                    list_combat_battlelog.Items.Add("You won the battle!");
                    
                } else {
                     list_combat_battlelog.Items.Add("You lost the battle!");
                    
                }
                m_BattleTimer.Stop();
                m_BattleTimer = null;
            }
        }

        private void btn_debug_attackrat_Click(object sender, EventArgs e) {
            toolstrip_command_attack_lvl1mob_Click(sender, e);
        }
    }
}
