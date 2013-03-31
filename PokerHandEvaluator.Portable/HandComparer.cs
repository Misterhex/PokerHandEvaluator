using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PokerHandEvaluator.Portable
{
    public class HandComparer : IEqualityComparer<Hand>
    {
        public bool Equals(Hand x, Hand y)
        {
            return x.ToString() == y.ToString();
        }

        public int GetHashCode(Hand obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
