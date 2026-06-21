using HikeRPG.Interfaces;
using HikeRPG.Models;

namespace HikeRPG.Observers
{
    public class StatObserver : IHikeObserver
    {
        private Character _character;

        public StatObserver(Character character)
        {
            _character = character;
        }

        public void Update(Hike hike)
        {
            CharacterStats stats = _character.GetStats();

            int xpGained = hike.GetXP(stats);
            stats.XP += xpGained;
            stats.TotalXP += xpGained;
            stats.TotalDistance += hike.DistanceKm;
            stats.TotalElevation += hike.ElevationM;
            stats.Strength += (int)(hike.ElevationM * 0.01f);
            stats.Stamina += (int)(hike.DistanceKm * 0.5f);
            stats.Energy -= (int)(hike.GetDifficulty() * 10);

            UpdateStreak(hike);
        }

        private void UpdateStreak(Hike hike)
        {
            CharacterStats stats = _character.GetStats();

            if (stats.LastHikeDate == DateTime.MinValue)
            {
                stats.CurrentStreak = 1;
            }
            else if (stats.LastHikeDate.Date == hike.Date.Date.AddDays(-1))
            {
                stats.CurrentStreak++;
            }
            else if (stats.LastHikeDate.Date != hike.Date.Date)
            {
                stats.CurrentStreak = 0;
            }

            stats.LastHikeDate = hike.Date;
        }

        public string GetName()
        {
            return "StatObserver";
        }
    }
}