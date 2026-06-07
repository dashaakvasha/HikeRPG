using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Interfaces
{
    public interface IBoost
    {
        void ApplyBoost(HikeRPG.Models.CharacterStats stats);
        string GetDescription();
    }
}
