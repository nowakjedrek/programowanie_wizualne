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

namespace samochód
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int koszt =0;
       
        public MainWindow()
        {
            InitializeComponent();
            Cena.Content = koszt;
        }

        private void Button_Click_marka(object sender, RoutedEventArgs e)
        {
            Window1 subwindow = new Window1(koszt);
            subwindow.Show();
            koszt = subwindow.koszt + subwindow.polisa;
            Cena.Content = koszt;

        }

        private void Button_Click_silnik(object sender, RoutedEventArgs e)
        {
            Window2 subwindow2 = new Window2(koszt);
            subwindow2.Show();
            koszt = subwindow2.koszt + subwindow2.pojemnosc;
            Cena.Content = koszt;
        }
    }
}
