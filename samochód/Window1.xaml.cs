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

namespace samochód
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int koszt;
        public int polisa = 0;
        public Window1(int koszt)
        {
            InitializeComponent();
            this.koszt = koszt;
            Cena.Content = koszt + polisa;
            
        }

        private void Button_Click_powrot(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Fiat_Checked(object sender, RoutedEventArgs e)
        {
            koszt = koszt + 50000;
            Cena.Content = koszt + polisa;
        }

        private void Ford_Checked(object sender, RoutedEventArgs e)
        {
            koszt = koszt + 80000;
            Cena.Content = koszt + polisa;
        }

        private void Ferrari_Checked(object sender, RoutedEventArgs e)
        {
            koszt = koszt + 100000;
            Cena.Content = koszt + polisa;
        }

        private void Basic_Checked(object sender, RoutedEventArgs e)
        {
            koszt = koszt + 1000;
            Cena.Content = koszt + polisa;
        }

        private void Standard_Checked(object sender, RoutedEventArgs e)
        {
            koszt = koszt + 5000;
            Cena.Content = koszt + polisa;
        }

        private void Premium_Checked(object sender, RoutedEventArgs e)
        {
            koszt = koszt + 10000;
            Cena.Content = koszt + polisa;
        }
        private void Fiat_Unchecked(object sender, RoutedEventArgs e)
        {
            koszt = koszt - 50000;
            Cena.Content = koszt + polisa;
        }

        private void Ford_Unchecked(object sender, RoutedEventArgs e)
        {
            koszt = koszt - 80000;
            Cena.Content = koszt + polisa;
        }

        private void Ferrari_Unchecked(object sender, RoutedEventArgs e)
        {
            koszt = koszt - 100000;
            Cena.Content = koszt + polisa;
        }
        private void Basic_Unchecked(object sender, RoutedEventArgs e)
        {
            koszt = koszt - 1000;
            Cena.Content = koszt + polisa;
        }
        private void Standard_Unchecked(object sender, RoutedEventArgs e)
        {
            koszt = koszt - 5000;
            Cena.Content = koszt + polisa;
        }
        private void Premium_Unchecked(object sender, RoutedEventArgs e)
        {
            koszt = koszt - 10000;
            Cena.Content = koszt + polisa;
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            Cena.Content = 0;
        }
    }
}
