using HikeRPG.Interfaces;
using HikeRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Observers
{
    public class AchievementObserver:IHikeObserver
    {
        private Character _character;
        private BadgeCollection _collection;

        public AchievementObserver(Character character, BadgeCollection collection)
        {
          _character = character;
          _collection = collection;
        }

        public void Update(Hike hike)
        {
            CharacterStats stats = _character.GetStats();
            List<string> earned = _collection.GetEarned(stats);

            foreach (var badge in earned)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Achievement Unlocked: {badge}!");
                Console.ResetColor();
            }
        }
        public string GetName()
        {
            return "AchievementObserver";
        }
    }
}
