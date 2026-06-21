using HikeRPG.Interfaces;
using HikeRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Achievements
{
    public class ElevationAchievement : IAchievement
    {
        private int _minHeight;
        private bool _unlocked;
        private string _name;

        public ElevationAchievement(string name, int maxHeight)
        {
            _minHeight = maxHeight;
            _unlocked = false;
            _name = name;
        }

        public bool IsUnlocked(CharacterStats stats)
        {
            if (stats.TotalElevation >= _minHeight)
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
