using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandEvaluator.Portable
{
    public class CardComparer : IEqualityComparer<Card>, IComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return x.Point == y.Point;
        }

        public int GetHashCode(Card obj)
        {
            return obj.Point.GetHashCode();
        }

        public int Compare(Card x, Card y)
        {
            if (x.Point > y.Point)
                return 1;
            else
                return -1;
        }
    }
}
