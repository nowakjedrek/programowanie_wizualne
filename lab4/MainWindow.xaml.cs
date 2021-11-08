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
using Microsoft.Win32;
using System.Windows.Interop;


namespace lab4
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


        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Picture = new OpenFileDialog();
            Picture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            Picture.FilterIndex = 1;

            if (Picture.ShowDialog() == true)
                Obraz.Source =
            new BitmapImage(new Uri(Picture.FileName));
         }
       
        private void Obrot_Click(object sender, RoutedEventArgs e)
        {
            this.Obraz.Source 

        }

    }
}