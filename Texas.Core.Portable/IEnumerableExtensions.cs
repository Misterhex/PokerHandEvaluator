using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static bool Contains<TElement>(this IEnumerable<TElement> source, params TElement[] elements)
        {
            foreach (var e in elements)
            {
                if (!source.Contains(value: e))
                    return false;
            }
            return true;
        }

        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }
}
