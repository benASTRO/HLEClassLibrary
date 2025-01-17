﻿using System.Collections.Generic;
using System.Linq;
using HLE.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HLETests.CollectionsTests
{
    [TestClass]
    public class NumberCollectionTest
    {
        [TestMethod]
        public void NumbersTest()
        {
            Assert.IsFalse(NumberCollection.Numbers.IsNullOrEmpty());
        }

        [TestMethod]
        public void CreateTest()
        {
            long min = 1;
            long max = 10000;
            List<long> list = NumberCollection.Create(min, max).ToList();
            Assert.IsTrue(min == list[0]);
            Assert.IsTrue(max == list[^1]);
            Assert.AreEqual(list.Count, max);
        }
    }
}
