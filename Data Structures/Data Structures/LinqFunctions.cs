﻿using System;
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

            var firstEnum = source.GetEnumerator();
            var secondEnum = source.GetEnumerator();
            secondEnum.MoveNext();
            int i = 1;
            while (firstEnum.MoveNext())
            {
                int j = 1;
                var x = secondEnum;
                bool c = false;
                while (x.MoveNext())
                {
                    if (j < i)
                    {
                        j++;
                    }
                    else if (comparer.Equals(x.Current, firstEnum.Current))
                    {
                        c = true;
                        break;
                    }
                }

                if (!c)
                {
                    yield return firstEnum.Current;
                }

                secondEnum.Reset();
                secondEnum.MoveNext();
                i++;
            }
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

            var final = new List<TSource>();
            foreach (var obj in first)
            {
                final.Add(obj);
            }

            foreach (var obj in second)
            {
                final.Add(obj);
            }

            return final.Distinct<TSource>(comparer);
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
