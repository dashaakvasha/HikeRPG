using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Interfaces;
using HikeRPG.Models;

namespace HikeRPG.Boosts
{
    public class LevelUpBoost: IBoost
    {
        private int _xpBonus;
        private string _description;

        public LevelUpBoost(int xpBonus, string description)
        {
            _xpBonus = xpBonus;
            _description = description;
        }

        public void ApplyBoost(CharacterStats stats)
        {
            stats.XP += _xpBonus;
        }

        public string GetDescription()
        {
            return _description;
        }
    }
}
