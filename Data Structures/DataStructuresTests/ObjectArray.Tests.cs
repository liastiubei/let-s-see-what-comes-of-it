﻿using System;
using Xunit;

namespace DataStructuresTests
{
    public class ObjectArrayTests
    {
        [Fact]
        public void CheckIfIEnumWorksCorrectly1()
        {
            DataStructures.ObjectArrayCollection array = new DataStructures.ObjectArrayCollection { "hat", 1, "hercules", 'a' };
            Assert.Same("hat", array[0]);
        }

        [Fact]
        public void CheckIfIEnumWorksCorrectly2()
        {
            DataStructures.ObjectArrayCollection array = new DataStructures.ObjectArrayCollection { "hat", 1, "hercules", 'a' };
            Assert.Equal(1, array[1]);
        }

        [Fact]
        public void CheckIfIEnumWorksCorrectly3()
        {
            DataStructures.ObjectArrayCollection array = new DataStructures.ObjectArrayCollection { "hat", 1, "hercules", 'a' };
            Assert.Same("hercules", array[2]);
        }

        [Fact]
        public void CheckIfIEnumWorksCorrectly4()
        {
            DataStructures.ObjectArrayCollection array = new DataStructures.ObjectArrayCollection { "hat", 1, "hercules", 'a' };
            Assert.Equal('a', array[3]);
        }
    }
}
