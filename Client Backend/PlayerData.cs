using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class PlayerData
    {
        public class CombatStats {
            public float HP, Strength, Vitality, Magic, Spirit, Speed, Evade, Hit, Luck;
        };
        public int CombatLevel;
        public int CombatExperience;
        public CombatStats CombatStatistics = new CombatStats();
    }
}
