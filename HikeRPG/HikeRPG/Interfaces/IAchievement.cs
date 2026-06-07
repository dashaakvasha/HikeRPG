using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Interfaces
{
    public interface IAchievement
    {
        bool IsUnlocked(HikeRPG.Models.CharacterStats stats);
        string GetName();
    }
}
