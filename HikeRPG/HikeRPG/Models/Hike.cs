using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Interfaces;

namespace HikeRPG.Models
{
    public abstract class Hike : IHike
    {
        public string Name { get; set; }
        public float DistanceKm { get; set; }
        public int ElevationKm { get; set; }
        public DateTime Date { get; set; }  

        public Hike(string name, float distanceKm, int elevationKm, DateTime date)
        {
            Name = name;
            DistanceKm = distanceKm;
            ElevationKm = elevationKm;
            Date = date;
        }

        public abstract int GetXP(CharacterStats stats);
        public abstract float GetDifficulty();

    }
}
