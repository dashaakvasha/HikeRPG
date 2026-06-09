using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Interfaces;
using HikeRPG.Models;

namespace HikeRPG.Achievements
{
    public class DistanceAchievement: IAchievement
    {
        private float _threshold;
        private bool _unlocked;
        private string _name;

        public DistanceAchievement(float threshold, string name)
        {
            _threshold = threshold;
            _unlocked = false;
            _name = name;
        }

        public bool IsUnlocked(CharacterStats stats)
        {
            if (stats.TotalDistance >= _threshold)
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
