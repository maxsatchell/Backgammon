using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backgammon.Model;
using System.Collections.Generic;

namespace BackgammonTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidMoveTest1()
        {
            var b = new Board();
            var l = b.ValidMoves(Colours.Black);
            var expected = new List<int>() {1,2,3,4,5,6,7,8,9,10,12,13,14,15,16,18,20,21,22,23};
            CollectionAssert.AreEqual(expected, l);
        }

        [TestMethod]
        public void ValidMoveTest2()
        {
            var b = new Board();
            var l = b.ValidMoves(Colours.White);
            var expected = new List<int>() { 0,1, 2, 3, 5,7, 8, 9, 10,11, 13, 14, 15, 16, 17,18,19, 20, 21, 22};
            CollectionAssert.AreEqual(expected, l);
        }
    }
}
