using Microsoft.Win32;
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
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace lab5
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        public class PatternCount { }




        private void Znajdz_Click(object sender, RoutedEventArgs e)
        {
            string tekst = Sekwencja.Text;
            int count = 0;
            for (int i = 0; i < tekst.Length - 4; i++)
            {

            }

        }


        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Tekst = new OpenFileDialog();

            Tekst.Filter = "Text files|*.txt;*.fasta;|All files|*.*";



            if (Tekst.ShowDialog() == true)
            {
                string filename = Tekst.FileName;
                Sekwencja.Text = File.ReadAllText(filename);

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] nuc = Regex.Split(Sekwencja.Text, string.Empty);
            for (int i = 0; i < nuc.Length; i++)
            {
               
               

                
            }


        }

    }
}
