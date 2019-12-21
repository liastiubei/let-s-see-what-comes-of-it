using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public static class LinqFunctions
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var obj in source)
            {
                if (!predicate(obj))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var obj in source)
            {
                if (predicate(obj))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (Count<TSource>(source) == 0)
            {
                throw new InvalidOperationException("The enumeration has no elements");
            }

            return predicate(source.First()) ? source.First() : default;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            int num = 0;
            foreach (var obj in source)
            {
                num++;
            }

            return num;
        }
    }
}
