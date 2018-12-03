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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Integral
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool flag = true;
        public MainWindow()
        {
            InitializeComponent();

        }
        int n;
        double a;
        double b;

        public bool Read_n()
        {
            n = Convert.ToInt32(this._n.Text);

            try
            {
                Convert.ToDouble(_n.Text);
            }
            catch
            {
                MessageBox.Show("Введите целое число");
                return false;
            }

            if (Convert.ToDouble(_n.Text) <= 0)
            {
                MessageBox.Show("Введите n больше 0");
                return false;
            }
            else {
                return true;
            }
        }


        public bool Read_A_B() {
            a = Convert.ToInt32(this._a.Text);
            b = Convert.ToInt32(this._b.Text);
            if (Convert.ToDouble(_a.Text) >= Convert.ToDouble(_b.Text))
            {
                MessageBox.Show("Нижняя граница не должна превышать или быть равной верхней");
                return false;
            }
            else
            {
                return true;
            }
        }




        void Default()
        {
            _resultText.Text = "";
            _timeText.Text = "";
            

        }
        

        void Calculate()
        {
            Integral_calculate integral = new Integral_calculate();
            double In;
            Stopwatch timer = new Stopwatch();
            if (_check.IsChecked.Value == true)
            {
                task = Task.Run(() =>
                {
                    timer.Start();
                    In = integral.calcParr(n, a, b, x => 2 * x - Math.Log10(2 * x) + 234);
                    timer.Stop();

                    Dispatcher.Invoke(() =>
                    {
                        this._resultText.Text = Convert.ToString(In);
                        this._timeText.Text = Convert.ToString(timer.ElapsedMilliseconds);
                        ButtonCulc.IsEnabled = true;
                    });

                    timer.Reset();
                });
            }
            if (_check.IsChecked.Value == false)
            {
                task = Task.Run(() =>
                {
                    timer.Start();
                    In = integral.calcParr(n, a, b, x => 2 * x - Math.Log10(2 * x) + 234);
                    timer.Stop();

                    Dispatcher.Invoke(() =>
                    {
                        this._resultText.Text = Convert.ToString(In);
                        this._timeText.Text = Convert.ToString(timer.ElapsedMilliseconds);
                        ButtonCulc.IsEnabled = true;
                    });

                    timer.Reset();
                });
            }



        }

        private void ButtonCulc_Click(object sender, RoutedEventArgs e)
        {
            // if ()
            ///  double.TryParse

           /* Read_A_B();
            Read_n();*/
            if (Read_A_B() == false) {
                return;
            }
            if (Read_n() == false)
            {
                return;
            }
            Default();
            Calculate();

            /* else {
                 MessageBox.Show("Введите целое число");
             }*/
        }
        Posl_graph posl = new Posl_graph();
        Paral_graph paral = new Paral_graph();
        Bars bar = new Bars();
        private Task task;

        private void PoslGraph_Click(object sender, RoutedEventArgs e)
        {
            if (Read_A_B() == false)
            {
                return;
            }
            if (Read_n() == false)
            {
                return;
            }
            posl.culc(a,b);
            posl.Show();

        }

        private void ParalGraph_Click(object sender, RoutedEventArgs e)
        {
            if (Read_A_B() == false)
            {
                return;
            }
            if (Read_n() == false)
            {
                return;
            }
            paral.culc(a, b);
            paral.Show();
        }

        private void barGraph_Click(object sender, RoutedEventArgs e)
        {
            if (Read_A_B() == false)
            {
                return;
            }
            if (Read_n() == false)
            {
                return;
            }
            bar.culc(a, b);
            bar.Show();

        }

        private void bt_Clear_Click(object sender, RoutedEventArgs e)
        {
            _resultText.Text = "";
            _timeText.Text = "";
        }

        private void bt_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
