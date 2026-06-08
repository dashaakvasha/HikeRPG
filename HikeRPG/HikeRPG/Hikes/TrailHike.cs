using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Models;

namespace HikeRPG.Hikes
{
    public class TrailHike : Hike
    {
        private string _trailName;
        private bool _isHard;

        public TrailHike(string name, float distanceKm, int elevationM, DateTime date,
                         string trailName, bool isHard) : base(name,distanceKm,elevationM,date)
        {
            _trailName = trailName;
            _isHard = isHard;
        }

        public override int GetXP(CharacterStats stats)
        {
            return (int)(DistanceKm * 10 * GetDifficulty());
        }

        public override float GetDifficulty()
        {
            if (_isHard)
                return 1.5f;
            else
                return 1.0f;
        }
    }
}
