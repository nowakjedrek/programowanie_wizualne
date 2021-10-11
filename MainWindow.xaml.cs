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
using System.Windows.Threading;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>

	public partial class DispatcherTimerSample : Window
	{
		DispatcherTimer timer = new DispatcherTimer(); 
		public DispatcherTimerSample()
		{

			
			timer.Interval = TimeSpan.FromMilliseconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
			




		}

		void timer_Tick(object sender, EventArgs e)
		{
			Timer.Content = DateTime.Now.ToLongTimeString();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Window1 subwindow = new Window1();
			subwindow.Show();
		}
		private void startbtn_Click(object sender, RoutedEventArgs e)
		{
			timer.Start();

		} 


	}
}