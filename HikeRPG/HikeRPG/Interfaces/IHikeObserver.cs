using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Interfaces
{
    public interface IHikeObserver
    {
        void Update(HikeRPG.Models.Hike hike);
        string GetName();
    }
}
