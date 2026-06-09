using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Interfaces;
using HikeRPG.Models;

namespace HikeRPG.Boosts
{
    public class EnergyBoost: IBoost
    {
        private int _energyAmount;
        private string _description;

        public EnergyBoost(int energyAmount, string description)
        {
            _energyAmount = energyAmount;
            _description = description;
        }

        public void ApplyBoost(CharacterStats stats)
        {
            stats.Energy += _energyAmount;
        }

        public string GetDescription()
        {
            return _description;
        }
    }
}
