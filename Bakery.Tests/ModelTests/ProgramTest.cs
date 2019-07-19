using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameSpace.Test
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void ConstructorTest_True()
        {
            Assert.AreEqual("Sir", testGame.Name);
            testGame.Name = "TestName";
            Assert.AreEqual("TestName", testGame.Name);
            string apple = "apple";
            Game secondGame = new Game(apple);
            Assert.AreEqual(apple, secondGame.Name);
            
        }
        [TestMethod]
        public void YesNoBranching_True()
        {
            Assert.AreEqual(true, testGame.CheckYes("yes"));
           
        }
    }
}