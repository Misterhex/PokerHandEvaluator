using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Texas.Core.Portable
{
    public static class StartingHandExtensions
    {
        public static HandCategory GetHandCategory(this StartingHand startingHand)
        {
            var rankHistogram = startingHand.GroupBy(i => i.Rank);
            IOrderedEnumerable<int> rankHistogramCounts = rankHistogram.Select(i => i.Count()).OrderByDescending(i => i);

            if (rankHistogramCounts.Count() == 1)
                return HandCategory.OnePair;
            else
                return HandCategory.HighCard;
        }
    }
}
