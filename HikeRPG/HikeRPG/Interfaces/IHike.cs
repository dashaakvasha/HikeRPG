using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Interfaces
{
    public interface IHike
    {
        int GetXP(HikeRPG.Models.CharacterStats stats);
        float GetDifficulty();
    }
}
