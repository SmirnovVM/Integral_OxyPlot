using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    public class Integral_calculate
    {
        public double I(double a, double b, double n, double y)
        {
            return ((b - a) / (2 * n) * y);
        }

        public double y = 0, dy;
        double In;


        public double calcPosl(int n, double a, double b, Func<double, double> f)
        {
            if (n <= 0)
                throw new Exception("Ошибка, так как n - отрицательное");

            if(a >= b)
                throw new Exception("Ошибка, так как a>=b");
              
            y = 0;
            dy = (b - a) / n;
            y += f(a) + f(b);
            for (int i = 1; i < n; i++)
            {
                y += 2 * (f(a + dy * i));
            }
            return In = I(a, b, n, y);
        }

        public double calcParr(int n, double a, double b, Func<double, double> f)
        {
            object monitor = new object();
            y = 0;
            dy = (b - a) / n;
            y += (f(a) + f(b)) / 2;
            Parallel.For(0, (int)n, () => 0.0, (i, state, local) =>
            {

                local += f(a + dy * i);
                return local;
            }, local => { lock (monitor) y += local; });

            return y *= dy;
        }
       
    }
}
