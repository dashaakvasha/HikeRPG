using HikeRPG.Models;
using HikeRPG.Hikes;
using HikeRPG.Data;
using HikeRPG.Observers;
using HikeRPG.Achievements;
using System.Linq;

namespace HikeRPG.Engine
{
    public class GameEngine
    {
        private Character _character;
        private DataStorage _storage;
        private HikeFactory _hikeFactory;
        private Leaderboard _leaderboard;
        private BadgeCollection _badgeCollection;

        public bool IsNewPlayer { get; private set; }

        public GameEngine(string playerName, string savePath)
        {
            _character = new Character(playerName);
            _storage = new DataStorage(savePath);
            _hikeFactory = new HikeFactory();
            _leaderboard = new Leaderboard();

            _leaderboard.AddPlayer(_character);

            IsNewPlayer = !File.Exists(savePath);

            LoadProgress();
            RegenerateEnergy();
            SetupAchievements();
            SetupObservers();
        }

        private void RegenerateEnergy()
        {
            CharacterStats stats = _character.GetStats();
            stats.Energy += 20;
            if (stats.Energy > 100)
                stats.Energy = 100;
        }

        private void SetupObservers()
        {
            _character.Subscribe(new StatObserver(_character));
            _character.Subscribe(new AchievementObserver(_character, _badgeCollection));
            _character.Subscribe(new LevelObserver(_character));
        }

        private void SetupAchievements()
        {
            _badgeCollection = new BadgeCollection();

            _badgeCollection.Add(new DistanceAchievement("First Steps", 10f));
            _badgeCollection.Add(new DistanceAchievement("Trail Legend", 100f));
            _badgeCollection.Add(new ElevationAchievement("Hill Crusher", 500));
            _badgeCollection.Add(new ElevationAchievement("Summit Slayer", 5000));
            _badgeCollection.Add(new StreakAchievement("Unstoppable", 7));
        }

        public void StartGame()
        {
            Console.WriteLine($"Welcome, {_character.GetName()}!");
        }

        public void ProcessHike(Hike hike)
        {
            _character.LogHike(hike);
        }

        public void GetSummary()
        {
            CharacterStats stats = _character.GetStats();
            Console.WriteLine($"Level: {stats.Level} | XP: {stats.XP} | Energy: {stats.Energy}");
        }

        public Character GetCharacter()
        {
            return _character;
        }

        public BadgeCollection GetBadgeCollection()
        {
            return _badgeCollection;
        }

        public Leaderboard GetLeaderboard()
        {
            return _leaderboard;
        }

        public void SaveProgress()
        {
            _storage.Save(_character);
            _storage.SaveLeaderboardEntry(_character.GetName(), _character.GetStats());
        }

        public void LoadProgress()
        {
            CharacterStats loadedStats = _storage.Load(_character.GetName());
            CharacterStats currentStats = _character.GetStats();

            currentStats.Level = loadedStats.Level;
            currentStats.XP = loadedStats.XP;
            currentStats.TotalXP = loadedStats.TotalXP;
            currentStats.Energy = loadedStats.Energy;
            currentStats.Strength = loadedStats.Strength;
            currentStats.Stamina = loadedStats.Stamina;
            currentStats.TotalDistance = loadedStats.TotalDistance;
            currentStats.TotalElevation = loadedStats.TotalElevation;
            currentStats.CurrentStreak = loadedStats.CurrentStreak;
            currentStats.LastHikeDate = loadedStats.LastHikeDate;
        }

        public List<KeyValuePair<string, CharacterStats>> GetGlobalLeaderboard(int n)
        {
            Dictionary<string, CharacterStats> allPlayers = _storage.LoadAllPlayers();
            List<KeyValuePair<string, CharacterStats>> sorted = allPlayers
                .OrderByDescending(p => p.Value.TotalXP)
                .ToList();

            if (sorted.Count > n)
                return sorted.GetRange(0, n);
            else
                return sorted;
        }

        public void RemoveFromLeaderboard(string name)
        {
            _storage.RemoveLeaderboardEntry(name);
            _leaderboard.RemovePlayer(_character);
        }
    }
}