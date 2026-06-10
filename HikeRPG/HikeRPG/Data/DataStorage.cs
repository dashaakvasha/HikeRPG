using HikeRPG.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string json = JsonConvert.SerializeObject(character.GetStats(),Formatting.Indented);
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
    }
}
