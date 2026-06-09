using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Models;

namespace HikeRPG.Hikes
{
    public class HikeFactory
    {
        public Hike CreateHike(string type, string name, float distanceKm,
                                      int elevationM, DateTime date,
                                      int intParam = 0, bool boolParam = false,
                                      string stringParam = "")
        {
            switch (type)
            {
                case "trail":
                    return new TrailHike(name, distanceKm, elevationM, date, stringParam, boolParam);

                case "mountain":
                    return new MountainHike(name, distanceKm, elevationM, date, intParam, boolParam);

                case "night":
                    return new NightHike(name, distanceKm, elevationM, date, intParam, boolParam);

                default:
                    throw new Exception("Hike type '" + type + "' does not exist. Use: trail, mountain, night");
            }
        }
    }
}
