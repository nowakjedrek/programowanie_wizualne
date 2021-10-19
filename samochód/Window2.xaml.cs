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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public int koszt = 0;
        public int pojemnosc = 0;
        public Window2(int koszt)
        {
            InitializeComponent();
            this.koszt = koszt;
            Cena.Content = koszt + pojemnosc;
        }

        private void Button_Click_powrot2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Gaz_checked(object sender, RoutedEventArgs e)
        {
            koszt = koszt + 5000;
            Cena.Content = koszt + pojemnosc;
        }

        private void Diesel_checked(object sender,RoutedEventArgs e)
        {
            koszt = koszt + 2000;
            Cena.Content = koszt + pojemnosc;
        }

        private void Hybryda_Checked(object sender, RoutedEventArgs e)
        {
            koszt = koszt + 10000;
            Cena.Content = koszt + pojemnosc;
        }

        private void Benzyna_checked(object sender, RoutedEventArgs e)
        {
            koszt = koszt + 3000;
            Cena.Content = koszt + pojemnosc;
        }

        private void Benzyna_Unchecked(object sender, RoutedEventArgs e)
        {
            koszt = koszt - 3000;
            Cena.Content = koszt + pojemnosc;
        }

        private void Hybryda_Unchecked(object sender, RoutedEventArgs e)
        {
         
                koszt = koszt - 10000;
                Cena.Content = koszt + pojemnosc;
            
        }
    
        private void Gaz_Unchecked(object sender, RoutedEventArgs e)
        {
         koszt = koszt - 5000;
         Cena.Content = koszt + pojemnosc;
         }
        private void Diesel_Unchecked(object sender, RoutedEventArgs e)
        {
            koszt = koszt - 2000;
            Cena.Content = koszt + pojemnosc;
        }

        private void Button_19l(object sender, RoutedEventArgs e)
        {
            pojemnosc = 1000;
            Cena.Content = this.koszt + pojemnosc;
        }

        private void Button_16l(object sender, RoutedEventArgs e)
        {
            pojemnosc =500;
            Cena.Content = this.koszt + pojemnosc;

        }

        private void Button_25l(object sender, RoutedEventArgs e)
        {
            pojemnosc = 2000;
            Cena.Content = this.koszt + pojemnosc;
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            Cena.Content = 0;
        }
    }
}
