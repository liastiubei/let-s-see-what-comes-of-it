using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class HashingListDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int[] buckets;
        private KeyValuePair<TKey, TValue>[] elements;
        int[] next;
        private DoubleLink<int> freeSpaces;

        public HashingListDictionary(int dictionaryCapacity)
        {
            buckets = new int[dictionaryCapacity];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            next = new int[1000];
            for (int i = 0; i < next.Length; i++)
            {
                next[i] = -1;
            }

            elements = new KeyValuePair<TKey, TValue>[1000];
            IsReadOnly = false;
            freeSpaces = new DoubleLink<int>(-1);
            freeSpaces.NextLink = freeSpaces;
            freeSpaces.PreviousLink = freeSpaces;
        }

        public HashingListDictionary(int dictionaryCapacity, int valueArrayCapacity)
        {
            buckets = new int[dictionaryCapacity];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            next = new int[1000];
            for (int i = 0; i < next.Length; i++)
            {
                next[i] = -1;
            }

            elements = new KeyValuePair<TKey, TValue>[valueArrayCapacity];
            IsReadOnly = false;
            freeSpaces = new DoubleLink<int>(-1);
            freeSpaces.NextLink = freeSpaces;
            freeSpaces.PreviousLink = freeSpaces;
        }

        public TValue this[TKey key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException("The key is null");
                }

                return elements[Find(key)].Value;
            }

            set
            {
                if (IsReadOnly)
                {
                    throw new NotSupportedException("The Dictionary is read-only");
                }

                elements[Find(key)] = new KeyValuePair<TKey, TValue>(key, value);
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] array = new TKey[Count];
                int j = 0;
                for (int i = 0; i < Count; i++)
                {
                    while (elements[j].Equals(default))
                    {
                        j++;
                    }

                    array[i] = elements[j].Key;
                    j++;
                }

                return array;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] array = new TValue[Count];
                int j = 0;
                for (int i = 0; i < Count; i++)
                {
                    while (elements[j].Equals(default))
                    {
                        j++;
                    }

                    array[i] = elements[j].Value;
                    j++;
                }

                return array;
            }
        }

        public int Count { get; protected set; }

        public bool IsReadOnly { get; protected set; }

        public bool IsFixedSized { get; protected set; }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            if (Find(key) != -1)
            {
                throw new ArgumentException("The key already exists in the dictionary");
            }

            if (IsFixedSized)
            {
                throw new NotSupportedException("The dictionary is fixed-sized");
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException("The dictionary is readonly");
            }

            int actualKey = GetHashedKey(key);

            if (freeSpaces.NextLink == freeSpaces)
            {
                elements[Count] = new KeyValuePair<TKey, TValue>(key, value);
                next[Count] = buckets[actualKey];
                buckets[actualKey] = Count;
                Count++;
            }
            else
            {
                elements[freeSpaces.NextLink.Value] = new KeyValuePair<TKey, TValue>(key, value);
                next[freeSpaces.NextLink.Value] = buckets[actualKey];
                buckets[actualKey] = freeSpaces.NextLink.Value;
                freeSpaces.NextLink = freeSpaces.NextLink.NextLink;
                Count++;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The dictionary is readonly");
            }

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = default;
            }

            for (int i = 0; i < next.Length; i++)
            {
                next[i] = -1;
            }

            freeSpaces.NextLink = freeSpaces;
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (item.Key == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            int find = Find(item.Key);
            return find != -1 && elements[find].Value.Equals(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            return Find(key) != -1;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index is less than zero");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The number of elements in the list is greater than the available space from index to the end of the array");
            }

            int j = 0;
            for (int i = arrayIndex; i < arrayIndex + Count; i++)
            {
                while (elements[j].Equals(default))
                {
                    j++;
                }

                array[i] = new KeyValuePair<TKey, TValue>(elements[j].Key, elements[j].Value);
                j++;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return elements[i];
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            if (IsFixedSized)
            {
                throw new NotSupportedException("The dictionary is fixed-sized");
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException("The dictionary is readonly");
            }

            int find = Find(key);
            if (find == -1)
            {
                return true;
            }

            int bucket = GetHashedKey(key);
            elements[find] = default;
            buckets[bucket] = next[find];
            next[find] = -1;
            freeSpaces.NextLink = new DoubleLink<int>(find);
            Count--;
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = elements[Find(key)].Value;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)this).GetEnumerator();
        }

        public void MakeReadOnly()
        {
            IsReadOnly = true;
        }

        public int Find(TKey key)
        {
            int actualKey = GetHashedKey(key);
            int nextValue = buckets[actualKey];
            if (nextValue == -1)
            {
                return -1;
            }

            while (nextValue != -1)
            {
                if (elements[nextValue].Key.Equals(key))
                {
                    return nextValue;
                }

                nextValue = next[nextValue];
            }

            return -1;
        }

        public TValue ShowValue(int actualKey)
        {
            return elements[actualKey].Value;
        }

        public TKey ShowKey(int actualKey)
        {
            return elements[actualKey].Key;
        }

        public int ShowNext(int actualKey)
        {
            return next[actualKey];
        }

        public void MakeFixedSize()
        {
            IsFixedSized = true;
        }

        private int GetHashedKey(TKey key)
        {
            int actualKey = key.GetHashCode();
            if (actualKey < 0)
            {
                actualKey = -actualKey;
            }

            if (actualKey > buckets.Length - 1)
            {
                actualKey = actualKey % buckets.Length;
            }

            return actualKey;
        }
    }
}
