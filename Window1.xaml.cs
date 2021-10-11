using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DateTime xd = new DateTime();
        DispatcherTimer timer = new DispatcherTimer();
        public Window1()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            xd = xd.AddSeconds(1);
            Timer.Content = xd.ToString("HH:mm:ss");
        }

        private void strbtn_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void stpbtn_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void rstbtn_Click(object sender, RoutedEventArgs e)
        {
            xd = new DateTime();
        }
    }
}
