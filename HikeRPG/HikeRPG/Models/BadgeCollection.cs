using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Interfaces;

namespace HikeRPG.Models
{
    public class BadgeCollection
    {
        private List<IAchievement> _badges = new List<IAchievement>();

        public void Add(IAchievement achievement)
        {
            _badges.Add(achievement);
        }

        public List<string> GetEarned(CharacterStats stats)
        {
            List<string> earned = new List<string>();
            foreach (var badge in _badges)
            {
                if (badge.IsUnlocked(stats))
                    earned.Add(badge.GetName());
            }
            return earned;
        }

        public void UnlockAll(CharacterStats stats)
        {
            foreach (var badge in _badges)
            {
                if (badge.IsUnlocked(stats))
                    Console.WriteLine($"Achievement unlocked: {badge.GetName()} ");
            }
        }
    }
}

