using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;


namespace Integral
{
    /// <summary>
    /// Логика взаимодействия для Bars.xaml
    /// </summary>
    public partial class Bars : Window
    {
        public Bars()
        {
            InitializeComponent();
        }





        public void culc(double a, double b)
        {
            
            Stopwatch timer = new Stopwatch();
            int n = 100000;
            int nn = n;
            double In1 = 0;
            int kol = 7;
            Integral_calculate integ = new Integral_calculate();
            (graph3.Model.Series[0] as ColumnSeries).Items.Clear();
            (graph3.Model.Series[1] as ColumnSeries).Items.Clear();
            for (int k = 0; k < kol; k++)
            {


                timer.Start();
                In1 = integ.calcParr(n, a, b, x => 32 * x - Math.Log10(2 * x) - 41);
                timer.Stop();
                (graph3.Model.Series[0] as ColumnSeries).Items.Add(new ColumnItem(timer.ElapsedMilliseconds, n / nn-1));
                timer.Reset();

               // graph3.InvalidatePlot();

                timer.Start();
                In1 = integ.calcPosl(n, a, b, x => 32 * x - Math.Log10(2 * x) - 41);
                timer.Stop();
                //  (graph3.Model.Series[0] as ColumnSeries).Background.color

                (graph3.Model.Series[1] as ColumnSeries).Items.Add(new ColumnItem(timer.ElapsedMilliseconds, n / nn-1));
                timer.Reset();

                graph3.InvalidatePlot();
                // MessageBox.Show(Convert.ToString(k));

                n *= 2;
            }

        }



    }
}
