using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Texas.Core.Portable
{
    /// <summary>
    /// ShowDown a texas holdem game.
    /// </summary>
    public class ShowDown
    {
        class CardComparer : IEqualityComparer<Card>
        {
            public bool Equals(Card x, Card y)
            {
                return x.Point == y.Point;
            }

            public int GetHashCode(Card obj)
            {
                return obj.Point.GetHashCode();
            }
        }

        class FlushAndStraightFlushShowDown
        {
            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> hands)
            {
                // find highest suit.
                int highestSuit = hands.GroupBy(i => (int)i.ToList().First().Suit).Select(i => i.Key).Max();

                var highestSuitStraighFlushes = hands.Where(i => (int)i.First().Suit == highestSuit);

                // show down in same suit
                int highestCardPointInHighestSuit = highestSuitStraighFlushes.SelectMany(i => i).Max(i => i.Point);
                foreach (var hand in highestSuitStraighFlushes)
                {
                    if (hand.Where(i => i.Point == highestCardPointInHighestSuit).Any())
                        return new List<Hand>() { hand };
                }

                throw new InvalidOperationException("was unable to determine any winner, check algorithm for FlushAndStraightFlushShowDown");
            }
        }

        class StraightShowDown
        {
            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> hands)
            {
                int highestCardPointInHighestSuit = hands.SelectMany(i => i).Max(i => i.Point);
                foreach (var hand in hands)
                {
                    if (hand.Where(i => i.Point == highestCardPointInHighestSuit).Any())
                        return new List<Hand>() { hand };
                }

                throw new InvalidOperationException("was unable to determine any winner, check algorithm for StraightShowDown");
            }
        }


        public IEnumerable<Hand> GetWinners(IEnumerable<Hand> allHands)
        {
            if (allHands == null) throw new ArgumentNullException("allHands");
            if (allHands.Count() < 2) throw new ArgumentNullException("nothing to show down if less than 2 hands.");

            if (allHands.SelectMany(i => i).Count() != allHands.SelectMany(i => i).Distinct(new CardComparer()).Count())
            {
                var duplicatedCards = allHands.SelectMany(i => i).Except(allHands.SelectMany(i => i).Distinct(new CardComparer()));
                StringBuilder sb = new StringBuilder();
                foreach (var s in duplicatedCards.Select(i => i.ToString() + " "))
                {
                    sb.Append(s + " ");
                }
                throw new ArgumentException(string.Format("allHands cannot contain duplicated cards {0}", sb));
            }

            HandCategory highestCategory = allHands.Select(i => i.GetHandCategory()).Max();
            IEnumerable<Hand> highestHands = allHands.Where(i => i.GetHandCategory() == highestCategory);

            switch (highestCategory)
            {
                case HandCategory.StraightFlush:
                case HandCategory.Flush:
                    return new FlushAndStraightFlushShowDown().GetWinners(highestHands);
                case HandCategory.Straight:
                    return new StraightShowDown().GetWinners(highestHands);
            }

            throw new NotSupportedException(string.Format("does not support getting winners for hand category {0}", highestCategory.ToString()));
        }
    }
}
