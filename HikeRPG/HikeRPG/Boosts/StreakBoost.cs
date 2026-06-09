using HikeRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Interfaces;

namespace HikeRPG.Boosts
{
    public class StreakBoost: IBoost
    {
        private int _streakBonus;
        private string _description;

        public StreakBoost(int streakBonus, string description)
        {
            _streakBonus = streakBonus;
            _description = description;
        }

        public void ApplyBoost(CharacterStats stats)
        {
            stats.Stamina += _streakBonus;
            stats.Strength += _streakBonus;
        }

        public string GetDescription() 
        { 
            return _description;
        }
    }
}
