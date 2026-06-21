using Newtonsoft.Json;
using HikeRPG.Models;

namespace HikeRPG.Data
{
    public class DataStorage
    {
        private string _filePath;

        public DataStorage(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(Character character)
        {
            string json = JsonConvert.SerializeObject(character.GetStats(), Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public CharacterStats Load(string name)
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<CharacterStats>(json);
            }
            else
            {
                return new CharacterStats();
            }
        }

        public void SaveLeaderboardEntry(string name, CharacterStats stats)
        {
            Dictionary<string, CharacterStats> allPlayers = LoadAllPlayers();
            allPlayers[name] = stats;

            string json = JsonConvert.SerializeObject(allPlayers, Formatting.Indented);
            File.WriteAllText("leaderboard.json", json);
        }

        public Dictionary<string, CharacterStats> LoadAllPlayers()
        {
            if (File.Exists("leaderboard.json"))
            {
                string json = File.ReadAllText("leaderboard.json");
                return JsonConvert.DeserializeObject<Dictionary<string, CharacterStats>>(json);
            }
            else
            {
                return new Dictionary<string, CharacterStats>();
            }
        }
        public void RemoveLeaderboardEntry(string name)
        {
            Dictionary<string, CharacterStats> allPlayers = LoadAllPlayers();
            if (allPlayers.ContainsKey(name))
            {
                allPlayers.Remove(name);
                string json = JsonConvert.SerializeObject(allPlayers, Formatting.Indented);
                File.WriteAllText("leaderboard.json", json);
            }
        }
    }
}