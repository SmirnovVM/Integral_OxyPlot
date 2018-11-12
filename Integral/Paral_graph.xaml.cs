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
    /// Логика взаимодействия для Posl_graph.xaml
    /// </summary>
    public partial class Paral_graph : Window
    {
        public Paral_graph()
        {
            InitializeComponent();
            
        }
        public void culc(double a, double b) {
            (graph2.Model.Series[0] as LineSeries).Points.Clear();
            Stopwatch timer = new Stopwatch();
            int n = 100000;
            int nn = n;
            double In1 = 0;
            int kol = 7;
            Random rnd = new Random();
            Integral_calculate integ = new Integral_calculate();
            for (int k = 0; k < kol; k++)
            {

                timer.Start();
                In1 = integ.calcParr(n, a, b, x => 2 * x - Math.Log10(2 * x) + 234);
                timer.Stop();
                (graph2.Model.Series[0] as LineSeries).Points.Add(new DataPoint(timer.ElapsedMilliseconds, n / nn));
                timer.Reset();

                timer.Reset();

                graph2.InvalidatePlot();
                // MessageBox.Show(In1 + "  " + In2);
                n *= 2;
            }
            graph2.InvalidatePlot();
        }
    }
}

