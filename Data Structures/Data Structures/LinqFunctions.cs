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

            foreach (var obj in source)
            {
                if (predicate(obj))
                {
                    return obj;
                }
            }

            throw new InvalidOperationException("The enumeration has no elements");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("The Source or the Selector is null");
            }

            foreach (var obj in source)
            {
                yield return selector(obj);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException("The Source or the Selector is null");
            }

            foreach (var obj in source)
            {
                foreach (var selectorObject in selector(obj))
                {
                    yield return selectorObject;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException("The Source or the Predicate is null");
            }

            foreach (var obj in source)
            {
                if (predicate(obj))
                {
                    yield return obj;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            if (source == null || keySelector == null || elementSelector == null)
            {
                throw new ArgumentNullException("Source or selector null");
            }

            Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>();
            foreach (var obj in source)
            {
                TKey key = keySelector(obj);
                if (key == null)
                {
                    throw new ArgumentNullException("Selector produces null key");
                }

                dictionary.Add(keySelector(obj), elementSelector(obj));
            }

            return dictionary;
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null || func == null)
            {
                throw new ArgumentNullException("Source or function null");
            }

            foreach (var obj in source)
            {
                seed = func(seed, obj);
            }

            return seed;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("First or Second is null");
            }

            var firstEnum = first.GetEnumerator();
            var secondEnum = second.GetEnumerator();
            while (firstEnum.MoveNext() && secondEnum.MoveNext())
            {
                yield return resultSelector(firstEnum.Current, secondEnum.Current);
            }
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            if (outer == null || inner == null || outerKeySelector == null || innerKeySelector == null || resultSelector == null)
            {
                throw new ArgumentNullException("Outer, Inner, OuterKeySelector, InnerKeySelector or RezultSelector is null");
            }

            var outerEnum = outer.GetEnumerator();
            var innerEnum = inner.GetEnumerator();
            while (outerEnum.MoveNext())
            {
                while (innerEnum.MoveNext())
                {
                    if (outerKeySelector(outerEnum.Current).Equals(innerKeySelector(innerEnum.Current)))
                    {
                        yield return resultSelector(outerEnum.Current, innerEnum.Current);
                    }
                }

                innerEnum = inner.GetEnumerator();
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source is null");
            }

            return new HashSet<TSource>(source, comparer);
        }

        public static IEnumerable<TSource> Intersect<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("First or Second is null");
            }

            HashSet<TSource> list = new HashSet<TSource>(first, comparer);
            list.IntersectWith(second);

            return list;
        }

        public static IEnumerable<TSource> Union<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("First or Second is null");
            }

            var final = new HashSet<TSource>(first, comparer);
            foreach (var obj in second)
            {
                final.Add(obj);
            }

            return final;
        }

        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("First or Second is null");
            }

            HashSet<TSource> list = new HashSet<TSource>(first, comparer);
            Predicate<TSource> isContainedBySecond = x => second.Contains(x, comparer);
            list.RemoveWhere(isContainedBySecond);

            return list;
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Dictionary<TKey, List<TElement>> dictionary = new Dictionary<TKey, List<TElement>>(comparer);
            foreach (var obj in source)
            {
                if (dictionary.ContainsKey(keySelector(obj)))
                {
                    dictionary[keySelector(obj)].Add(elementSelector(obj));
                    continue;
                }

                dictionary.Add(keySelector(obj), new List<TElement> { elementSelector(obj) });
            }

            foreach (var obj in dictionary)
            {
                yield return resultSelector(obj.Key, obj.Value);
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            OrderedEnumerable<TSource> list = new OrderedEnumerable<TSource>();
            foreach (var obj in source)
            {
                list.Add(obj);
            }

            return list.CreateOrderedEnumerable<TKey>(keySelector, comparer, false);
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
