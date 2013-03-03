using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        class StraightFlushShowDown
        {
            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> straightFlushes)
            {
                if (!straightFlushes.All(i => i.GetHandCategory() == HandCategory.StraightFlush))
                    throw new ArgumentException("straightFlushes must only contain straightFlush hands");

                // find highest suit.
                int highestSuit = straightFlushes.GroupBy(i => (int)i.ToList().First().Suit).Select(i => i.Key).Max();

                var highestSuitStraighFlushes = straightFlushes.Where(i => (int)i.First().Suit == highestSuit);

                // show down in same suit
                int highestCardPointInHighestSuit = highestSuitStraighFlushes.SelectMany(i => i).Max(i => i.Point);
                foreach (var straightFlush in highestSuitStraighFlushes)
                {
                    if (straightFlush.Where(i => i.Point == highestCardPointInHighestSuit).Any())
                        return new List<Hand>() { straightFlush };
                }

                throw new InvalidOperationException("was unable to determine any winner, check algorithm for StraightFlushShowDown GetWinners");
            }
        }

        public IEnumerable<Hand> GetWinners(IEnumerable<Hand> allHands)
        {
            if (allHands == null) throw new ArgumentNullException("allHands");

            if (allHands.SelectMany(i => i).Count() != allHands.SelectMany(i => i).Distinct(new CardComparer()).Count())
                throw new ArgumentException("allHands cannot contain duplicated cards");


            HandCategory highestCategory = allHands.Select(i => i.GetHandCategory()).Max();
            IEnumerable<Hand> highestHands = allHands.Where(i => i.GetHandCategory() == highestCategory);

            switch (highestCategory)
            {
                case HandCategory.StraightFlush:
                    return new StraightFlushShowDown().GetWinners(highestHands);

            }

            throw new NotSupportedException(string.Format("does not support getting winner for hand category {0}", highestCategory.ToString()));
        }
    }
}
