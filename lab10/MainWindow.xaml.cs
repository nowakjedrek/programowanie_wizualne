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
using Microsoft.Win32;


namespace lab10
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary
    /// 

    public class Piosenka
    {
        public string Title { get; set; }
        public string Path { get; set; }

    }
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        
       

        public MainWindow()
        {
            InitializeComponent();
           
            
            
            
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (List_view.SelectedItems.Count == 1)
            {
                var wybrana = List_view.SelectedItem as Piosenka;

                mediaPlayer.Open(new Uri(wybrana.Path));
                mediaPlayer.Play();

            }
            else
            {
                string msg = "Nie wybrano piosenki";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Uwaga",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void Wybierz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {


                List_view.Items.Add(new Piosenka { Path = openFileDialog.FileName, Title = openFileDialog.SafeFileName });
               
                
            }
           
        }
        }
    }

