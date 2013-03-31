using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandEvaluator.Portable
{
    public static class SuitExtensions
    {
        private static Dictionary<Suit, string> _dict;
        public static Dictionary<Suit, string> Dict
        {
            get
            {
                if (_dict == null)
                {
                    _dict = new Dictionary<Suit, string>();
                    _dict.Add(Suit.Diamond, "♦");
                    _dict.Add(Suit.Club, "♣");
                    _dict.Add(Suit.Heart, "♥");
                    _dict.Add(Suit.Spade, "♠");
                }
                return _dict;
            }
        }

        public static string ToPokerString(this Suit suit)
        {
            return Dict[suit];
        }
    }
}
