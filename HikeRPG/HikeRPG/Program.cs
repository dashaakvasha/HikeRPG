using HikeRPG.Engine;
using HikeRPG.UI;
using HikeRPG.Hikes;
using HikeRPG.Models;

namespace HikeRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI.ShowStartupScreen();

            bool playingGame = true;

            while (playingGame)
            {
                Console.Write("Enter your hero's name: ");
                string playerName = Console.ReadLine().Trim();

                string savePath = playerName + "_save.json";

                GameEngine engine = new GameEngine(playerName, savePath);
                ConsoleUI ui = new ConsoleUI(engine);

                if (engine.IsNewPlayer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"🌟 Welcome, new adventurer {playerName}! Your journey begins now!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"🥾 Welcome back, {playerName}! Ready for more adventures?");
                }
                Console.ResetColor();

                bool running = true;

                while (running)
                {
                    ui.ShowMenu();
                    string choice = ui.GetInput();

                    if (choice == "1")
                    {
                        CharacterStats currentStats = engine.GetCharacter().GetStats();

                        if (currentStats.Energy <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("⚠ You're too exhausted to hike! Rest and try again later.");
                            Console.ResetColor();
                            continue;
                        }

                        Console.Write("Hike name: ");
                        string name = ui.GetInput();

                        Console.Write("Distance (km): ");
                        float distance = float.Parse(ui.GetInput());

                        Console.Write("Elevation (m): ");
                        int elevation = int.Parse(ui.GetInput());

                        Console.Write("Hike type (trail/mountain/night): ");
                        string type = ui.GetInput().ToLower().Trim();

                        if (type != "trail" && type != "mountain" && type != "night")
                        {
                            Console.WriteLine("Invalid hike type! Please try again.");
                            continue;
                        }

                        HikeFactory factory = new HikeFactory();
                        Hike hike;

                        if (type == "trail")
                        {
                            Console.Write("Is it hard? (yes/no): ");
                            bool isHard = ui.GetInput().ToLower().Trim() == "yes";
                            hike = factory.CreateHike(type, name, distance, elevation, DateTime.Now, 0, isHard, "My Trail");
                        }
                        else if (type == "mountain")
                        {
                            Console.Write("Do you have gear? (yes/no): ");
                            bool hasGear = ui.GetInput().ToLower().Trim() == "yes";
                            hike = factory.CreateHike(type, name, distance, elevation, DateTime.Now, elevation, hasGear);
                        }
                        else
                        {
                            Console.Write("Start hour (0-23): ");
                            int hour = int.Parse(ui.GetInput());
                            Console.Write("Do you have light? (yes/no): ");
                            bool hasLight = ui.GetInput().ToLower().Trim() == "yes";
                            hike = factory.CreateHike(type, name, distance, elevation, DateTime.Now, hour, hasLight);
                        }

                        engine.ProcessHike(hike);
                        ui.ShowProcessingHike();
                        engine.SaveProgress();
                        Console.WriteLine("Hike logged! Check your stats!");
                    }
                    else if (choice == "2")
                    {
                        ui.ShowStats();
                    }
                    else if (choice == "3")
                    {
                        CharacterStats stats = engine.GetCharacter().GetStats();
                        BadgeCollection badges = engine.GetBadgeCollection();
                        List<string> earned = badges.GetEarned(stats);
                        ui.ShowAchievementsBox(earned);
                    }
                    else if (choice == "4")
                    {
                        var top = engine.GetGlobalLeaderboard(10);
                        ui.ShowGlobalLeaderboard(top);
                    }
                    else if (choice == "5")
                    {
                        engine.SaveProgress();
                        running = false;
                        playingGame = false;
                        CharacterStats finalStats = engine.GetCharacter().GetStats();
                        ConsoleUI.ShowGoodbyeScreen(playerName, finalStats.Level, finalStats.TotalXP);
                    }
                    else if (choice == "6")
                    {
                        engine.SaveProgress();
                        running = false;
                        Console.WriteLine("Switching character...");
                    }
                    else if (choice == "7")
                    {
                        Console.Write("Are you sure you want to delete your leaderboard entry? (yes/no): ");
                        string confirm = ui.GetInput().ToLower().Trim();
                        if (confirm == "yes")
                        {
                            engine.RemoveFromLeaderboard(playerName);
                            Console.WriteLine("Removed from leaderboard!");
                        }
                        else
                        {
                            Console.WriteLine("Cancelled.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option, try again!");
                    }
                }
            }
        }
    }
}