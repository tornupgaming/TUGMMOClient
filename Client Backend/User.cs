using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using TUGLib.Forms;

namespace Client {
    public class User {
        public User() {
            LogHandler.Log("Creating new User: " + this.GetHashCode());
        }

        public string Username;
        public PlayerData Data = new PlayerData();

        public void ParseFromUserData(JToken userDataStr) {
            Username = userDataStr["username"].ToString();
            Data.CombatLevel = int.Parse(userDataStr["com_level"].ToString());
            Data.CombatExperience = int.Parse(userDataStr["com_exp"].ToString());

            Data.CombatStatistics.HP = float.Parse(userDataStr["stat_hp"].ToString());
            Data.CombatStatistics.Strength = float.Parse(userDataStr["stat_strength"].ToString());
            Data.CombatStatistics.Vitality = float.Parse(userDataStr["stat_vitality"].ToString());
            Data.CombatStatistics.Magic = float.Parse(userDataStr["stat_magic"].ToString());
            Data.CombatStatistics.Spirit = float.Parse(userDataStr["stat_spirit"].ToString());
            Data.CombatStatistics.Speed = float.Parse(userDataStr["stat_speed"].ToString());
            Data.CombatStatistics.Evade = float.Parse(userDataStr["stat_evade"].ToString());
            Data.CombatStatistics.Hit = float.Parse(userDataStr["stat_hit"].ToString());
            Data.CombatStatistics.Luck = float.Parse(userDataStr["stat_luck"].ToString());
        }
    }
}
