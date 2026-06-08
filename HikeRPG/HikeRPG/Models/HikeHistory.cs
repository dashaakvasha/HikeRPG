using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Models
{
    public class HikeHistory
    {
        private List<Hike> _hikes = new List<Hike>();

        public void Add(Hike hike)
        {
            _hikes.Add(hike);
        }

        public List<Hike> GetAll()
        {
            return _hikes;
        }

        public float GetTotalDistance()
        {
            float total = 0f;
            foreach (var hike in _hikes)
                total += hike.DistanceKm;
            return total;
        }
        public int GetTotalElevation()
        {
         int total = 0;
            foreach(var hike in _hikes)
                total += hike.ElevationM;
            return total;
        }
    }
}
