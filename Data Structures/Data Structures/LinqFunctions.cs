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
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("Source or Predicate null");
            }

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
            if (source == null)
            {
                throw new ArgumentNullException("Source null");
            }

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
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("Source or Predicate is null");
            }

            if (SimpleCount<TSource>(source) == 0)
            {
                throw new InvalidOperationException("The enumeration has no elements");
            }

            TSource variable = default;

            foreach (var obj in source)
            {
                if (predicate(obj))
                {
                    variable = obj;
                    break;
                }
            }

            return variable;
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("The Source or the Selector is null");
            }

            TResult[] output = new TResult[SimpleCount<TSource>(source)];
            int i = 0;
            foreach (var obj in source)
            {
                output[i++] = selector(obj);
            }

            return output;
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("The Source or the Selector is null");
            }

            TResult[] output = new TResult[CountWithSelector<TSource, TResult>(source, selector)];
            int i = 0;
            foreach (var obj in source)
            {
                foreach (var selectorObject in selector(obj))
                {
                    output[i++] = selectorObject;
                }
            }

            return output;
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("The Source or the Predicate is null");
            }

            List<TSource> returnList = new List<TSource>();
            foreach (var obj in source)
            {
                if (predicate(obj))
                {
                    returnList.Add(obj);
                }
            }

            return returnList;
        }

        public static int CountWithSelector<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            int num = 0;
            foreach (var obj in source)
            {
                foreach (var selectedObj in selector(obj))
                {
                    num++;
                }
            }

            return num;
        }

        public static int SimpleCount<TSource>(this IEnumerable<TSource> source)
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
