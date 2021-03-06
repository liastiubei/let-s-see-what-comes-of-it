﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace DataStructuresTests
{
    public class ListTests
    {
        [Fact]
        public void CheckIfIEnumWorksCorrectly()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            Assert.Equal(0, array[0]);
        }

        [Fact]
        public void CheckIfAddWorksCorrectly()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            array.Add(4);
            Assert.Equal(4, array[4]);
        }

        [Fact]
        public void CheckIfAddExceptionWorks()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            array.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => array.Add(4));
        }

        [Fact]
        public void CheckIfInsertIndexExceptionWorks1()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            Assert.Throws<ArgumentOutOfRangeException>(() => array.Insert(-3, 9));
        }

        [Fact]
        public void CheckIfInsertIndexExceptionWorks2()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            Assert.Throws<ArgumentOutOfRangeException>(() => array.Insert(8, 5));
        }

        [Fact]
        public void CheckIfInsertReadonlyExceptionWorks()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            array.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => array.Insert(2, 4));
        }

        [Fact]
        public void CheckIfClearReadonlyExceptionWorks()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            array.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => array.Clear());
        }

        [Fact]
        public void CheckIfRemoveReadonlyExceptionWorks()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            array.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => array.Remove(2));
        }

        [Fact]
        public void CheckIfRemoveAtReadonlyExceptionWorks()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            array.MakeReadOnly();
            Assert.Throws<NotSupportedException>(() => array.RemoveAt(2));
        }

        [Fact]
        public void CheckIfCopyToOutOfExceptionWorks()
        {
            var array = new DataStructures.ListCollection<int> { 0, 1, 2, 3 };
            int[] copyArray = { 5, 2, 1 };
            Assert.Throws<ArgumentOutOfRangeException>(() => array.CopyTo(copyArray, -3));
        }
    }
}
