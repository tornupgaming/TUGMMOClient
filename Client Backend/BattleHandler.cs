using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TUGLib.Web;
using Newtonsoft.Json.Linq;
using TUGLib.Forms;

namespace Client {
    public class BattleHandler : WebResponseHandler {
        private int m_MobID;

        public bool Victory = false;
        public string EnemyName = string.Empty;
        public int EnemyHP = 0;
        private List<BattleAction> m_BattleActions;
        public BattleAction[] BattleActions {
            get {
                return m_BattleActions.ToArray();
            }
        }


        public BattleHandler(int mobID) {
            m_MobID = mobID;
        }

        public void PerformBattle() {
            string response = HtmlHelper.GetStringResponseFromURL(
                "http://www.tornupgaming.com/orpg/battle.php", SessionManager.Cookies, "monster_id=" + m_MobID
                );
            LogHandler.Log("Battle: " + response);
            JObject battleData = JObject.Parse(response);
            Victory = (int.Parse(battleData["victory"].ToString()) == 1);
            EnemyName = battleData["monster_name"].ToString();
            EnemyHP = int.Parse(battleData["monster_hp"].ToString());
            m_BattleActions = new List<BattleAction>();
            string battleLog = battleData["battle_log"].ToString();
            List<string> splitBattleLog = battleLog.Split(',').ToList<string>();
            foreach (string str in splitBattleLog) {
                AddBattleAction(str);
            }
            SendResponseEvent();
        }

        private void AddBattleAction(string action) {
            string[] actionSplit = action.Split(':');
            BattleAction battleAction = new BattleAction(){
                ActionType = ParseBattleActionType(actionSplit[0])   
            };
            switch (battleAction.ActionType) {
                case BattleActionType.PLAYER_DAMAGE:
                    battleAction.Damage = float.Parse(actionSplit[1]);
                    break;
                case BattleActionType.MONSTER_DAMAGE:
                    battleAction.Damage = float.Parse(actionSplit[1]);
                    break;
            }

            m_BattleActions.Add(battleAction);
        }

        private BattleActionType ParseBattleActionType(string str) {
            if (str.CompareTo("player_damage") == 0) {
                return BattleActionType.PLAYER_DAMAGE;
            }
            if (str.CompareTo("monster_damage") == 0) {
                return BattleActionType.MONSTER_DAMAGE;
            }
            return BattleActionType.MONSTER_DAMAGE;
        }
    }
}
