using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class HashingListDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int[] buckets;
        private Element<TKey, TValue>[] elements;
        private int freeSpaces;

        public HashingListDictionary(int dictionaryCapacity)
        {
            buckets = new int[dictionaryCapacity];
            Array.Fill(buckets, -1);
            elements = new Element<TKey, TValue>[dictionaryCapacity * 5];
            IsReadOnly = false;
            freeSpaces = -1;
        }

        public TValue this[TKey key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException("The key is null");
                }

                return elements[Find(key).actual].Value;
            }

            set
            {
                if (IsReadOnly)
                {
                    throw new NotSupportedException("The Dictionary is read-only");
                }

                int element = Find(key).actual;
                elements[element] = new Element<TKey, TValue>(key, value, elements[element].Next);
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] array = new TKey[Count];
                int j = 0;
                foreach (var kvp in this)
                {
                    array[j] = kvp.Key;
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
                foreach (var kvp in this)
                {
                    array[j] = kvp.Value;
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

            if (Find(key).actual != -1)
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

            if (freeSpaces == -1)
            {
                elements[Count] = new Element<TKey, TValue>(key, value, buckets[actualKey]);
                buckets[actualKey] = Count;
                Count++;
            }
            else
            {
                int momentaryFreeSpace = elements[freeSpaces].Next;
                elements[freeSpaces] = new Element<TKey, TValue>(key, value, buckets[actualKey]);
                buckets[actualKey] = freeSpaces;
                freeSpaces = momentaryFreeSpace;
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
                elements[i] = new Element<TKey, TValue>();
            }

            freeSpaces = -1;
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (item.Key == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            int find = Find(item.Key).actual;
            return find != -1 && elements[find].Value.Equals(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            return Find(key).actual != -1;
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

            int j = Count - 1;
            foreach (var kvp in this)
            {
                array[j] = kvp;
                j--;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var bucket in buckets)
            {
                if (bucket != -1)
                {
                    int next = bucket;
                    {
                        while (next != -1)
                        {
                            yield return new KeyValuePair<TKey, TValue>(elements[next].Key, elements[next].Value);
                            next = elements[next].Next;
                        }
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

            int find = Find(key).actual;
            int findPrevious = Find(key).previous;
            if (find == -1)
            {
                return true;
            }

            int bucket = GetHashedKey(key);
            if (findPrevious == -1)
            {
                buckets[bucket] = elements[find].Next;
            }
            else
            {
                elements[findPrevious].Next = elements[find].Next;
            }

            elements[find].Next = freeSpaces;
            freeSpaces = find;
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = elements[Find(key).actual].Value;
            return true;
        }

        public void MakeReadOnly()
        {
            IsReadOnly = true;
        }

        public (int previous, int actual) Find(TKey key)
        {
            int actualKey = GetHashedKey(key);
            int nextValue = buckets[actualKey];
            if (nextValue == -1)
            {
                return (-1, -1);
            }

            if (elements[nextValue].Key.Equals(key))
            {
                return (-1, nextValue);
            }

            while (elements[nextValue].Next != -1)
            {
                if (elements[elements[nextValue].Next].Key.Equals(key))
                {
                    return (nextValue, elements[nextValue].Next);
                }

                nextValue = elements[elements[nextValue].Next].Next;
            }

            return (-1, -1);
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
