using PokerHandEvaluator.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandEvaluator.Portable
{
    public static class StringExtensions
    {

        private static List<KeyValuePair<Rank, string>> _ranksDict = new List<KeyValuePair<Rank, string>>()
        {
            new KeyValuePair<Rank,string>(Rank.Ace, "a"),
            new KeyValuePair<Rank,string>(Rank.Deuce, "2"),
            new KeyValuePair<Rank,string>(Rank.Three, "3"),
            new KeyValuePair<Rank,string>(Rank.Four, "4"),
            new KeyValuePair<Rank,string>(Rank.Five, "5"),
            new KeyValuePair<Rank,string>(Rank.Six, "6"),
            new KeyValuePair<Rank,string>(Rank.Seven, "7"),
            new KeyValuePair<Rank,string>(Rank.Eigth, "8"),
            new KeyValuePair<Rank,string>(Rank.Nine, "9"),
            new KeyValuePair<Rank,string>(Rank.Ten, "10"),
            new KeyValuePair<Rank,string>(Rank.Jack, "j"),
            new KeyValuePair<Rank,string>(Rank.Queen, "q"),
            new KeyValuePair<Rank,string>(Rank.King, "k")
        };

        private static List<KeyValuePair<Suit, string>> _suitsDict = new List<KeyValuePair<Suit, string>>()
        {
            new KeyValuePair<Suit,string>(Suit.Diamond, "d"),
            new KeyValuePair<Suit,string>(Suit.Club, "c"),
            new KeyValuePair<Suit,string>(Suit.Heart, "h"),
            new KeyValuePair<Suit,string>(Suit.Spade, "s")
        };


        private static Rank? AsRank(this string s)
        {
            try
            {
                return _ranksDict.Where(i => i.Value.Equals(s, StringComparison.OrdinalIgnoreCase)).Single().Key;
            }
            catch
            { }
            return null;
        }

        private static Suit? AsSuit(this string s)
        {
            try
            {
                return _suitsDict.Where(i => i.Value.Equals(s, StringComparison.OrdinalIgnoreCase)).Single().Key;
            }
            catch
            { }
            return null;
        }

        public static Card AsCard(this string str)
        {
            try
            {
                IEnumerable<string> sArray = str.ToCharArray().Select(j => j.ToString());
                if (sArray.Count() != 2) throw new FormatException("not a valid string format for parsing to Card.");

                Rank? r = sArray.First().AsRank();
                if (r == null) throw new FormatException("not a valid string format for parsing to Card.");

                Suit? s = sArray.Second().AsSuit();
                if (s == null) throw new FormatException("not a valid string format for parsing to Card.");

                return new Card(r.Value, s.Value);
            }
            catch
            { }
            return null;
        }

    }
}
