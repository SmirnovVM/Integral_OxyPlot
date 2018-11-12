using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integral;
using System.Diagnostics;

namespace UnitTestIntegral
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double a = 0;
            double b = 100;
            int n = 10000000;
            Func<double, double> f = x => x * x;
            double exact_result = 333333.333;
            Integral_calculate integr = new Integral_calculate();
            double real_result = integr.calcPosl(n, a, b, f);

            Assert.AreEqual(real_result, exact_result, 0.001);
        }
    }
}
