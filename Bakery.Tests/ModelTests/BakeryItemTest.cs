using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bakery;

namespace Bakery.Test
{
    [TestClass]
    public class BakeryItemTest
    {
        [TestMethod]
        public void ConstructorTest_True()
        {
            BakeryItem item = new BakeryItem("Eclair", 2, 1);
            Assert.AreEqual(typeof(BakeryItem), item.GetType());

            Assert.AreEqual("Eclair", item.ItemName);
        }
        [TestMethod]
        public void chekSome()
        {}
    }
}