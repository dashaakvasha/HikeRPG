using HikeRPG.Interfaces;
using HikeRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Achievements
{
    public class StreakAchievement:IAchievement
    {
        private int _days;
        private string _name;
        private bool _unlocked;


        public StreakAchievement(string name, int days)
        {
            _days = days;
            _name = name;
            _unlocked = false;
        }

        public bool IsUnlocked(CharacterStats stats)
        {
            if (stats.CurrentStreak >= _days)
            {
                _unlocked = true;
            }
            return _unlocked;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
