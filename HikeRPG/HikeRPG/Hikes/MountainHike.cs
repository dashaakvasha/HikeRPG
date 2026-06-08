using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Models;

namespace HikeRPG.Hikes
{
    public class MountainHike : Hike
    {
        private int _peakHeight;
        private bool _needsGear;

        public MountainHike(string name, float distanceKm, int elevationM,
                            DateTime date, int peakHeight, bool needsGear):base(name,distanceKm,elevationM,date) 
        {
            _peakHeight = peakHeight;
            _needsGear = needsGear;
        }

        public override int GetXP(CharacterStats stats)
        {
            return (int)(DistanceKm * 10 * GetDifficulty() + _peakHeight * 0.1f);
        }

        public override float GetDifficulty()
        {
            if (_needsGear)
                return 2.0f;
            else
                return 1.0f;
        }
    }
}
