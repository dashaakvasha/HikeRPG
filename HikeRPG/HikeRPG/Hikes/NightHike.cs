using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Models;


namespace HikeRPG.Hikes
{
    public class NightHike : Hike
    {
        private int _startHour;
        private bool _hasLight;

        public NightHike(string name, float distanceKm, int elevationM,
                            DateTime date, int startHour, bool hasLight) : base(name, distanceKm, elevationM, date)
        {
            _startHour = startHour;
            _hasLight = hasLight;
        }

        public override int GetXP(CharacterStats stats)
        {
            return (int)(DistanceKm * 10 * GetDifficulty());
        }

        public override float GetDifficulty()
        {
            if (_startHour >= 0 && _startHour <= 4) 
            {
                if (_hasLight)
                    return 3.0f;
                else
                    return 0.5f;
            }
            else
            {
                if (_hasLight)
                    return 2.0f;
                else
                    return 0.7f;
            }
        }
    }
}
