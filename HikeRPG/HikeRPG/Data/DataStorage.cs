using Newtonsoft.Json;
using HikeRPG.Models;
using HikeRPG.Hikes;

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

        private class HikeData
        {
            public string Name { get; set; }
            public float DistanceKm { get; set; }
            public int ElevationM { get; set; }
            public DateTime Date { get; set; }
        }

        public void SaveHikeHistory(string name, List<Hike> hikes)
        {
            List<HikeData> data = new List<HikeData>();
            foreach (Hike hike in hikes)
            {
                data.Add(new HikeData
                {
                    Name = hike.Name,
                    DistanceKm = hike.DistanceKm,
                    ElevationM = hike.ElevationM,
                    Date = hike.Date
                });
            }

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(name + "_hikes.json", json);
        }

        public List<Hike> LoadHikeHistory(string name)
        {
            string filePath = name + "_hikes.json";
            List<Hike> hikes = new List<Hike>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<HikeData> data = JsonConvert.DeserializeObject<List<HikeData>>(json);

                foreach (HikeData h in data)
                {
                    hikes.Add(new LoggedHike(h.Name, h.DistanceKm, h.ElevationM, h.Date));
                }
            }

            return hikes;
        }
    }
}