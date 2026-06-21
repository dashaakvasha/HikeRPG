using HikeRPG.Interfaces;
using HikeRPG.Models;

namespace HikeRPG.Observers
{
    public class AchievementObserver : IHikeObserver
    {
        private Character _character;
        private BadgeCollection _collection;
        private List<string> _alreadyShown;

        public AchievementObserver(Character character, BadgeCollection collection)
        {
            _character = character;
            _collection = collection;
            _alreadyShown = new List<string>();

            CharacterStats stats = _character.GetStats();
            List<string> currentlyEarned = _collection.GetEarned(stats);
            foreach (var badge in currentlyEarned)
            {
                _alreadyShown.Add(badge);
            }
        }

        public void Update(Hike hike)
        {
            CharacterStats stats = _character.GetStats();
            List<string> earned = _collection.GetEarned(stats);

            foreach (var badge in earned)
            {
                if (!_alreadyShown.Contains(badge))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"\r🏆 Achievement Unlocked: {badge}! 🏆");
                        Thread.Sleep(200);
                        Console.Write($"\r                                          ");
                        Thread.Sleep(100);
                    }

                    PlayAchievementSound();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\r🏆 Achievement Unlocked: {badge}! 🏆");
                    Console.ResetColor();
                    _alreadyShown.Add(badge);
                }
            }
        }

        private void PlayAchievementSound()
        {
            Console.Beep(523, 100);
            Console.Beep(659, 100);
            Console.Beep(784, 150);
        }

        public string GetName()
        {
            return "AchievementObserver";
        }
    }
}