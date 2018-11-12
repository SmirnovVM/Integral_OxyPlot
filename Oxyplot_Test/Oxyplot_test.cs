using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integral;
using System.Diagnostics;

namespace Oxyplot_Test
{
    [TestClass]
    public class Oxyplot_test
    {
        [TestMethod]
        public void Test_Integral_XX_0_100()
        {
            double a = 0;
            int www;
            double b = 100;
            int n = 10000000;
            Func<double, double> f = x => x * x;
            double exact_result = 333333.333;
            Integral_calculate integr = new Integral_calculate();
            double real_result = integr.calcPosl(n, a, b, f);

            Assert.AreEqual(real_result, exact_result, 0.001);

        }

        [TestMethod]
        public void Test_Integral_posl_and_parallel()
        {
            double a = 0;
            double b = 100;
            int n = 100000;
            Func<double, double> f = x => x * x;
            Integral_calculate integr = new Integral_calculate();
            double real_result_posl = integr.calcPosl(n, a, b, f);
            double real_result_parallel = integr.calcParr(n, a, b, f);

            Assert.AreEqual(real_result_posl, real_result_parallel, 0.001);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_Integral_minus_n()
        {
            double a = 0;
            double b = 100;
            int n = -100000;
            Func<double, double> f = x => x * x;
            Integral_calculate integr = new Integral_calculate();

            double real_result = integr.calcPosl(n, a, b, f);

            //Assert.AreEqual(real_result, exact_result, 0.001);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_Integral_a_greater_b()
        {
            double a = 100;
            double b = 0;
            int n = 100000;
            Func<double, double> f = x => x * x;
            double exact_result = 333333.333;
            Integral_calculate integr = new Integral_calculate();

            double real_result = integr.calcPosl(n, a, b, f);
            Assert.AreEqual(real_result, exact_result, 0.001);
        }


        [TestMethod]
        public void Test_Integral_speed_run()
        {
            double a = 1;
            double b = 10000;
            int n = 100000;
            Func<double, double> f = x => x * x;
            Integral_calculate integr = new Integral_calculate();
            Stopwatch timer_posl = new Stopwatch();
            Stopwatch timer_paral = new Stopwatch();

            timer_posl.Start();
            double real_result = integr.calcPosl(n, a, b, f);
            timer_posl.Stop();

            timer_paral.Start();
            real_result = integr.calcParr(n, a, b, f);
            timer_paral.Stop();
            bool flag = true;
            if (timer_paral.ElapsedMilliseconds >= timer_posl.ElapsedMilliseconds)
            {
                flag = false;
            }
            Assert.IsFalse(flag, "Нет ускорения");

            //  Assert.Equals(timer_paral.ElapsedMilliseconds, timer_posl.ElapsedMilliseconds);
            //Assert.AreNotEqual(timer_paral.ElapsedMilliseconds, timer_posl.ElapsedMilliseconds);
        }


    }
}
