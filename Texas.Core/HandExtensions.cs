using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texas.Core
{
    public static class HandExtensions
    {
        public static HandCategory GetHandCategory(this Hand hand)
        {
            var rankHistogram = hand.GroupBy(i => i.Rank);
            IOrderedEnumerable<int> rankHistogramCounts = rankHistogram.Select(i => i.Count()).OrderByDescending(i => i);

            // If the histogram has 4 ranks in it, then the hand is one pair.
            if (rankHistogramCounts.Count() == 4)
                return HandCategory.OnePair;

            // If the histogram counts are 2, 2 and 1, then the hand is two pair.
            else if (rankHistogramCounts.Count() == 3
                && rankHistogramCounts.First() == 2
                && rankHistogramCounts.Second() == 2
                && rankHistogramCounts.Third() == 1)
                return HandCategory.TwoPair;

            // If the histogram counts are 3, 1 and 1, then the hand is a three of a kind.
            else if (rankHistogramCounts.Count() == 3
                 && rankHistogramCounts.First() == 3
                 && rankHistogramCounts.Second() == 1
                 && rankHistogramCounts.Third() == 1)
                return HandCategory.ThreeOfAKind;

             // If the histogram counts are 3 and a 2, then the hand is full house.
            else if (rankHistogramCounts.Count() == 2
                && rankHistogramCounts.First() == 3
                && rankHistogramCounts.Second() == 2)
                return HandCategory.FullHouse;

            // If the histogram counts are 4 and a 1, then the hand is four of a kind.
            else if (rankHistogramCounts.Count() == 2
                && rankHistogramCounts.First() == 4
                && rankHistogramCounts.Second() == 1)
                return HandCategory.FourOfAKind;

            // StraightFlush
            else if (hand.IsFlush() && hand.IsStraight())
                return HandCategory.StraightFlush;

            else if (hand.IsFlush())
                return HandCategory.Flush;

            else if (hand.IsStraight())
                return HandCategory.Straight;

            else if (rankHistogram.Count() == 5)
                return HandCategory.HighCard;

            throw new NotSupportedException("was not able to determine hand category, check algorithm.");
        }

        private static bool IsFlush(this Hand hand)
        {
            return hand.Count() == 5 && hand.GroupBy(i => i.Suit).Count() == 1;
        }

        private static bool IsStraight(this Hand hand)
        {
            if (hand.Count() == 5)
            {
                var orderedByRank = hand.OrderByDescending(i => i.Rank);
                var highestRank = orderedByRank.First();
                var lowestRank = orderedByRank.Last();
                if ((highestRank.Rank - lowestRank.Rank) == 4)
                    return true;
            }
            return false;
        }
    }
}
