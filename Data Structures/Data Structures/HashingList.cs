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
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            elements = new Element<TKey, TValue>[1000];
            IsReadOnly = false;
            freeSpaces = -1;
        }

        public HashingListDictionary(int dictionaryCapacity, int valueArrayCapacity)
        {
            buckets = new int[dictionaryCapacity];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            elements = new Element<TKey, TValue>[valueArrayCapacity];
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

                return elements[Find(key)].Value;
            }

            set
            {
                if (IsReadOnly)
                {
                    throw new NotSupportedException("The Dictionary is read-only");
                }

                int element = Find(key);
                elements[element] = new Element<TKey, TValue>(key, value, elements[element].Next);
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
                    while (elements[j].Key.Equals(default))
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
                    while (elements[j].Value.Equals(default) && elements[j].Key.Equals(default))
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
                if (!elements[i].IsDeleted)
                {
                    yield return new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)this).GetEnumerator();
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
            if (FindPrevious(elements[find]) == -1)
            {
                buckets[bucket] = elements[find].Next;
            }
            else
            {
                elements[FindPrevious(elements[find])].Next = elements[find].Next;
            }

            if (freeSpaces == -1)
            {
                freeSpaces = find;
                elements[find].Next = -1;
            }
            else
            {
                int next = freeSpaces;
                while (elements[next].Next != -1)
                {
                    next = elements[next].Next;
                }

                elements[next].Next = find;
                elements[find].Next = -1;
            }

            elements[find].Delete();
            return true;
        }

        public int FindPrevious(Element<TKey, TValue> nextElement)
        {
            int hash = GetHashedKey(nextElement.Key);
            if (elements[buckets[hash]] == nextElement)
            {
                return -1;
            }

            int next = buckets[hash];
            while (next != -1)
            {
                if (elements[elements[next].Next] == nextElement)
                {
                    return next;
                }

                next = elements[next].Next;
            }

            return -2;
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

        public void MakeReadOnly()
        {
            IsReadOnly = true;
        }

        public int Find(TKey key)
        {
            int actualKey = GetHashedKey(key);
            int nextValue = buckets[actualKey];

            while (nextValue != -1)
            {
                if (elements[nextValue].Key.Equals(key))
                {
                    return nextValue;
                }

                nextValue = elements[nextValue].Next;
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
            return elements[actualKey].Next;
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
