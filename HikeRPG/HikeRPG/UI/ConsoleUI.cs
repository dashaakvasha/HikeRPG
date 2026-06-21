using HikeRPG.Engine;
using HikeRPG.Models;

namespace HikeRPG.UI
{
    public class ConsoleUI
    {
        private GameEngine _engine;

        public ConsoleUI(GameEngine engine)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            _engine = engine;
        }

        public void TypeText(string text, int delay)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        public void ShowMenu()
        {
            Character character = _engine.GetCharacter();
            CharacterStats stats = character.GetStats();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("                                       ");
            Console.WriteLine("        ⛰  H I K E   R P G ⛰              ");
            Console.WriteLine("                                        ");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine($"  👤 {character.GetName()}  🌟 Lv.{stats.Level}  ✨ {stats.XP}XP");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine("  [1] 🥾 Log a Hike");
            Console.WriteLine("  [2] 📊 My Stats");
            Console.WriteLine("  [3] 🏆 Achievements");
            Console.WriteLine("  [4] 🏅 Leaderboard");
            Console.WriteLine("  [5] 🚪 Exit");
            Console.WriteLine("  [6] 🔄 Switch Character");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Choose an option: ");
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void ShowStats()
        {
            Character character = _engine.GetCharacter();
            CharacterStats stats = character.GetStats();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("            📊 YOUR STATS 📊             ");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine($"👤 Name: {character.GetName()}");
            Console.WriteLine($"🌟 Level: {stats.Level}");
            Console.WriteLine($"✨ XP: {stats.XP}");
            Console.WriteLine();

            ShowBar("Energy", stats.Energy, 100);
            ShowBar("Strength", stats.Strength, 100);
            ShowBar("Stamina", stats.Stamina, 100);

            Console.WriteLine($"🛤 Total Distance: {stats.TotalDistance}km");
            Console.WriteLine($"🔥 Current Streak: {stats.CurrentStreak} days");
            Console.WriteLine();
        }

        private void ShowBar(string label, int value, int max)
        {
            int barLength = 20;
            int displayValue = value;

            if (displayValue > max)
                displayValue = max;
            if (displayValue < 0)
                displayValue = 0;

            int filled = (int)((float)displayValue / max * barLength);

            string bar = new string('█', filled) + new string(' ', barLength - filled);

            string emoji = "";
            if (label == "Energy") emoji = "⚡";
            else if (label == "Strength") emoji = "💪";
            else if (label == "Stamina") emoji = "🏃";

            float percentage = (float)displayValue / max;

            if (percentage >= 0.66f)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (percentage >= 0.33f)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"{emoji} {label,-10} |{bar}| {value}/{max}");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowAchievementsBox(List<string> earned)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("          🏆 ACHIEVEMENTS 🏆            ");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();

            if (earned.Count == 0)
            {
                Console.WriteLine("No achievements yet - keep hiking!");
            }
            else
            {
                foreach (var badge in earned)
                {
                    Console.WriteLine($"  🏆 {badge}");
                }
            }
            Console.WriteLine();
        }

        public void ShowGlobalLeaderboard(List<KeyValuePair<string, CharacterStats>> top)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("         🏅 LEADERBOARD 🏅             ");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();

            if (top.Count == 0)
            {
                Console.WriteLine("No players yet!");
            }
            else
            {
                int rank = 1;
                foreach (var entry in top)
                {
                    Console.WriteLine($"  {rank}. {entry.Key} - {entry.Value.TotalXP} XP");
                    rank++;
                }
            }
            Console.WriteLine();
        }

        public void ShowAchievement(string achievementName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText($"🏆 Achievement Unlocked: {achievementName}!", 30);
            Console.ResetColor();
        }

        public void ShowLevelUp(int level)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeText($"⚡⚡⚡ LEVEL UP! You are now Level {level}! ⚡⚡⚡", 30);
            Console.ResetColor();
        }
    }
}