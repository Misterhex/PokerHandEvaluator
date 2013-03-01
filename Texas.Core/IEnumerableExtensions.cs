using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class IEnumerableExtensions
    {
        public static TElement Second<TElement>(this IEnumerable<TElement> source)
        {
            return source.ElementAt(1);
        }

        public static TElement Third<TElement>(this IEnumerable<TElement> source)
        {
            return source.ElementAt(2);
        }

        public static TElement Fourth<TElement>(this IEnumerable<TElement> source)
        {
            return source.ElementAt(3);
        }

        public static TElement Fifth<TElement>(this IEnumerable<TElement> source)
        {
            return source.ElementAt(4);
        }

        public static TElement Sixth<TElement>(this IEnumerable<TElement> source)
        {
            return source.ElementAt(5);
        }
    }
}
