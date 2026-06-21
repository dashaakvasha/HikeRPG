using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeRPG.Models
{
    public class Leaderboard
    {
        private List<Character> _players;

        public Leaderboard()
        {
            _players = new List<Character>();
        }

        public void AddPlayer(Character character)
        {
            _players.Add(character);
        }

        public void RemovePlayer(Character character)
        {
            _players.Remove(character);
        }

        public List<Character> GetTop(int n)
        {
            List<Character> sorted = _players.OrderByDescending(p => p.GetStats().XP).ToList();
            if (sorted.Count > n)
            {
                return sorted.GetRange(0,n);
            }
            else
            {
                return sorted;
            }
        }

        public void Clear()
        {
            _players.Clear();
        }

    }
}
