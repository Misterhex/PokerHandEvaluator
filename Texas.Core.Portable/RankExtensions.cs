using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Texas.Core.Portable
{
    public static class RankExtensions
    {
        private static Dictionary<Rank, string> _dict;
        public static Dictionary<Rank, string> Dict
        {
            get
            {
                if (_dict == null)
                {
                    _dict = new Dictionary<Rank, string>();
                    _dict.Add(Rank.Ace, "A");
                    _dict.Add(Rank.Two, "2");
                    _dict.Add(Rank.Three, "3");
                    _dict.Add(Rank.Four, "4");
                    _dict.Add(Rank.Five, "5");
                    _dict.Add(Rank.Six, "6");
                    _dict.Add(Rank.Seven, "7");
                    _dict.Add(Rank.Eigth, "8");
                    _dict.Add(Rank.Nine, "9");
                    _dict.Add(Rank.Ten, "10");
                    _dict.Add(Rank.Jack, "J");
                    _dict.Add(Rank.Queen, "Q");
                    _dict.Add(Rank.King, "K");
                }
                return _dict;
            }
        }

        public static string ToPokerString(this Rank rank)
        {
            return Dict[rank];
        }
    }

}
