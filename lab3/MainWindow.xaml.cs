using System;
using System.Collections.Generic;
using System.IO;
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


namespace lab3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string tekst;
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Zapis_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Odczyt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Window1 subwindow = new Window1();
            subwindow.Show();

        }
    }
}
