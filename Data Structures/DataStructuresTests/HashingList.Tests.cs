using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace DataStructuresTests
{
    public class HashingListTests
    {
        [Fact]
        public void CheckIfAddWorksCorrectly1()
        {
            var hashList = new DataStructures.HashingListDictionary<int, string>(10);
            hashList.Add(1, "Ana");
            hashList.Add(3, "Andrei");
            Assert.Equal("Ana", hashList[1]);
        }

        [Fact]
        public void CheckIfAddWorksCorrectly2()
        {
            var hashList = new DataStructures.HashingListDictionary<int, string>(10);
            hashList.Add(1, "Ana");
            hashList.Add(11, "Andrei");
            Assert.Equal("Andrei", hashList[11]);
        }

        [Fact]
        public void CheckIfClearWorksCorrectly()
        {
            var hashList = new DataStructures.HashingListDictionary<int, string>(10);
            hashList.Add(1, "Ana");
            hashList.Add(11, "Andrei");
            hashList.Clear();
            Assert.False(hashList.ContainsKey(1) || hashList.ContainsKey(11));
        }

        [Fact]
        public void CheckIfCopyToWorksCorrectly()
        {
            var hashList = new DataStructures.HashingListDictionary<int, string>(10);
            hashList.Add(1, "Ana");
            hashList.Add(11, "Andrei");
            KeyValuePair<int, string>[] array1 = { new KeyValuePair<int, string>(1, "Ana"), new KeyValuePair<int, string>(11, "Andrei") };
            KeyValuePair<int, string>[] array2 = new KeyValuePair<int, string>[2];
            hashList.CopyTo(array2, 0);
            Assert.Equal(array1, array2);
        }

        [Fact]
        public void CheckIfRemoveWorksCorrectly()
        {
            var hashList = new DataStructures.HashingListDictionary<int, string>(10);
            hashList.Add(1, "Ana");
            hashList.Add(11, "Andrei");
            hashList.Remove(1);
            Assert.False(hashList.ContainsKey(1));
        }

        [Fact]
        public void CheckIfAddAfterRemoveWorksCorrectly()
        {
            var hashList = new DataStructures.HashingListDictionary<int, string>(10);
            hashList.Add(1, "Ana");
            hashList.Add(11, "Andrei");
            hashList.Add(13, "Andreas");
            hashList.Remove(11);
            hashList.Add(11, "Paul");
            Assert.NotEqual("Andrei", hashList[hashList.Find(11).actual]);
        }

        [Fact]
        public void CheckIfTryGetValueWorksCorrectly()
        {
            var hashList = new DataStructures.HashingListDictionary<int, string>(10);
            hashList.Add(1, "Ana");
            string value;
            hashList.TryGetValue(1, out value);
            Assert.Equal("Ana", value);
        }

        [Fact]
        public void CheckIfThisExceptionsWorkCorrectly1()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.Add("1", "Ana");
            string value;
            const string key = null;
            Assert.Throws<ArgumentNullException>(() => value = hashList[key]);
        }

        [Fact]
        public void CheckIfThisExceptionsWorkCorrectly2()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.Add("1", "Ana");
            hashList.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => hashList["string"] = "Banana");
        }

        [Fact]
        public void CheckIfAddExceptionsWorkCorrectly1()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => hashList.Add("1", "Ana"));
        }

        [Fact]
        public void CheckIfAddExceptionsWorkCorrectly2()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            const string key = null;
            Assert.Throws<ArgumentNullException>(() => hashList.Add(key, "Ana"));
        }

        [Fact]
        public void CheckIfThisExceptionsWorkCorrectly3()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.Add("1", "Ana");
            Assert.Throws<ArgumentException>(() => hashList.Add("1", "Andrei"));
        }

        [Fact]
        public void CheckIfAddExceptionsWorkCorrectly4()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.MakeFixedSize();
            Assert.Throws<NotSupportedException>(() => hashList.Add("1", "Ana"));
        }

        [Fact]
        public void CheckIfContainsExceptionsWorkCorrectly()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.Add("1", "Ana");
            const string key = null;
            Assert.Throws<ArgumentNullException>(() => hashList.Contains(new KeyValuePair<string, string>(key, "Andrei")));
        }

        [Fact]
        public void CheckIfContainsKeyExceptionsWorkCorrectly()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.Add("1", "Ana");
            const string key = null;
            Assert.Throws<ArgumentNullException>(() => hashList.ContainsKey(key));
        }

        [Fact]
        public void CheckIfCopyToExceptionsWorkCorrectly1()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.Add("1", "Ana");
            KeyValuePair<string, string>[] array = null;
            Assert.Throws<ArgumentNullException>(() => hashList.CopyTo(array, 0));
        }

        [Fact]
        public void CheckIfCopyToExceptionsWorkCorrectly2()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.Add("1", "Ana");
            KeyValuePair<string, string>[] array = new KeyValuePair<string, string>[20];
            Assert.Throws<ArgumentOutOfRangeException>(() => hashList.CopyTo(array, -1));
        }

        [Fact]
        public void CheckIfCopyToExceptionsWorkCorrectly3()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.Add("1", "Ana");
            hashList.Add("2", "Ana");
            hashList.Add("3", "Ana");
            hashList.Add("4", "Ana");
            hashList.Add("5", "Ana");
            hashList.Add("6", "Ana");
            KeyValuePair<string, string>[] array = new KeyValuePair<string, string>[2];
            Assert.Throws<ArgumentException>(() => hashList.CopyTo(array, 0));
        }

        [Fact]
        public void CheckIfClearExceptionsWorkCorrectly()
        {
            var hashList = new DataStructures.HashingListDictionary<string, string>(10);
            hashList.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => hashList.Clear());
        }
    }
}
