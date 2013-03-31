using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandEvaluator.Portable
{
    public enum HandCategory
    {
        StraightFlush = 80000,
        FourOfAKind = 70000,
        FullHouse = 60000,
        Flush = 50000,
        Straight = 40000,
        ThreeOfAKind = 30000,
        TwoPair = 20000,
        OnePair = 10000,
        HighCard = 0,
        Unknown = -1
    }
}
