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

            if (stats.Level <= _xpThresholds.Length)
            {
                int xpNeeded = _xpThresholds[stats.Level - 1];

                if (stats.XP >= xpNeeded)
                {
                    _character.LevelUp();

                    ConsoleColor[] colorValues = { ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Magenta };

                    for (int i = 0; i < 8; i++)
                    {
                        Console.ForegroundColor = colorValues[i % colorValues.Length];
                        Console.Write($"\r⚡⚡⚡ LEVEL UP! You are now Level {stats.Level}! ⚡⚡⚡");
                        Thread.Sleep(150);
                    }
                    Console.WriteLine();
                    Console.ResetColor();

                    PlayLevelUpSound();
                }
            }
        }

        private void PlayLevelUpSound()
        {
            Console.Beep(523, 150);
            Console.Beep(659, 150);
            Console.Beep(784, 150);
            Console.Beep(1047, 300);
        }

        public string GetName()
        {
            return "LevelObserver";
        }
    }
}