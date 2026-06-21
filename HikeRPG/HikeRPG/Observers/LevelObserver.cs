using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Interfaces;
using HikeRPG.Models;

namespace HikeRPG.Observers
{
    public class LevelObserver : IHikeObserver
    {
        private Character _character;
        private int[] _xpThresholds;

        public LevelObserver(Character character)
        {
            _character = character;
            _xpThresholds = new int[] { 100, 250, 500, 1000, 2000 };
        }

        public void Update(Hike hike)
        {
            CharacterStats stats = _character.GetStats();

            if(stats.Level <= _xpThresholds.Length)
            {
                int xpNeeded = _xpThresholds[stats.Level - 1];

                if (stats.XP >= xpNeeded)
                {
                    _character.LevelUp();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"LEVEL UP you are now Level {stats.Level}!");
                    Console.ResetColor();
                }
            }

        }
        public string GetName()
        {
            return "LevelObserver";
        }
    }
}
