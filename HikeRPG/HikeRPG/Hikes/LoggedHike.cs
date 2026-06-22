using System;
using HikeRPG.Models;

namespace HikeRPG.Hikes
{
    public class LoggedHike : Hike
    {
        public LoggedHike(string name, float distanceKm, int elevationM, DateTime date)
            : base(name, distanceKm, elevationM, date)
        {
        }

        public override int GetXP(CharacterStats stats)
        {
            return 0;
        }

        public override float GetDifficulty()
        {
            return 1.0f;
        }
    }
}