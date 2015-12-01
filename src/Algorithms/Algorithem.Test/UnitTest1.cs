using System;
using Algorithms.Greedy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithem.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GreedyBagAlgorithm algorithm = new GreedyBagAlgorithm();
            algorithm.GetGreedyBagOptimal();
        }
    }
}
