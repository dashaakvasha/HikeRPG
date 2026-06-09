using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikeRPG.Interfaces;

namespace HikeRPG.Models
{
    public class Character
    {
        private string _name;
        private List<IHikeObserver> _observers;
        private HikeHistory _hikeHistory;
        private BadgeCollection _badgeCollection;
        private CharacterStats _stats;

        public Character(string name)
        {
            _name = name;
            _observers = new List<IHikeObserver>();
            _hikeHistory= new HikeHistory();
            _badgeCollection = new BadgeCollection();
            _stats = new CharacterStats();
        }

        public void Subscribe(IHikeObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnSubscribe(IHikeObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Hike hike)
        {
            foreach (var observer in _observers)
            {
                observer.Update(hike);
            }
        }

        public void LogHike(Hike hike)
        {
            _hikeHistory.Add(hike);
            Notify(hike);
        }

        public void LevelUp()
        {
            _stats.Level++;
            _stats.XP = 0;
        }

        public CharacterStats GetStats()
        {
            return _stats;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
