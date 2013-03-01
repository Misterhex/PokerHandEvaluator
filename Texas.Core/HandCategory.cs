using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texas.Core
{
    public enum HandCategory
    {
        StraightFlush = 88,
        FourOfAKind = 77,
        FullHouse = 66,
        Flush = 55,
        Straight = 44,
        ThreeOfAKind = 33,
        TwoPair = 22,
        OnePair = 11,
        HighCard = 0,
        Unknown = -1
    }
}
