using Microsoft.Win32;
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
using System.Runtime;



namespace lab3
{
    
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int numer_id;
        class Users
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string Count { get; set; }

        }
        public string tekst;
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Zapis_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() ?? true)
            {
                StreamWriter streamWriter = new StreamWriter(fileDialog.FileName);
                StreamWriter sw = streamWriter;
                foreach (Users item in List_View.Items)
                {
                    sw.WriteLine("{0},{1},{2}", item.Name, item.ID, item.Count);
                }
            }
        }

        private void Odczyt_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string CSV_InputPath = fileDialog.FileName;
            List_View.Items.Clear();

            string[] lines = File.ReadAllLines(CSV_InputPath);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                List_View.Items.Add(new Users() { Name = data[0], ID = data[1], Count = data[2] });
            }
        }
            
        

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            numer_id += 1;
             this.List_View.Items.Add(newItem: new Users { ID = numer_id.ToString(), Name = Name_TextBox.Text, Count = Count_TextBox.Text });
           
        }

        private void Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            List_View.Items.Clear();

        }
    }
}
