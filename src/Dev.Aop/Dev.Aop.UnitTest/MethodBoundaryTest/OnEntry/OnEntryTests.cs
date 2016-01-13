using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev.Aop.UnitTest.MethodBoundaryTest.OnEntry
{
    [TestClass]
    public class OnEntryTests
    {
        [TestMethod]
        public void OnEntry_ShouldNotChange_StringArgument()
        {
            Stopwatch stop = new Stopwatch();
            stop.Start();
            dynamic myTest = new OnEntryTest();
            string argument = myTest.ResturnStringArgument("argument");
            Assert.AreEqual(argument, "argument");
            stop.Stop();
            Console.WriteLine(stop.ElapsedMilliseconds);
        }
    }
}
