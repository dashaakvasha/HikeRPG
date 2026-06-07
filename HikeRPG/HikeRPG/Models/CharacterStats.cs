using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Models
{
    public class CharacterStats
    {
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;
        public int Energy { get; set; } = 50;
        public int Strength { get; set; } = 10;
        public int Stamina {  get; set; } = 10;
        public float TotalDistance { get; set; } = 0f;
        public int TotalElevation { get; set; } = 0;


    }
}
