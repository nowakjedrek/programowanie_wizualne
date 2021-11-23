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
using System.Xml.Serialization;

namespace lab6
{

    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int numer_id;
       public class Users
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public string Count { get; set; }

            
        }
        public string tekst;
        bool data_saved = false;
        public object user;
        public IList<Users> lista = new List<Users>();
        public MainWindow()
        {
            InitializeComponent();
             
        }
        public static void SerializeToXml<T>(T anyobject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());

            using (StreamWriter writer = new StreamWriter(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
        }


        private void Zapis_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            IList<Users> lista = new List<Users>();
            
             foreach (Users item in List_View.Items)
                {
                
                lista.Add(user);
                
            }
            
            List_View.Items.Add(user );
            List_View.Items.Refresh();
            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.Filter = "XML-File | *.xml";
            fileDialog.ShowDialog();
            string savePathCSV = fileDialog.FileName;
            SerializeToXml(lista, savePathCSV);
        }
        public static object Deserialize<T>(T anyobject, string xmlFilePath)
        {
            using (TextReader reader = new StreamReader(xmlFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(anyobject.GetType());
                return (T)serializer.Deserialize(reader);
            }
        }

        private void Odczyt_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string CSV_InputPath = fileDialog.FileName;
            List_View.Items.Clear();
            IList<Users> lista = new List<Users>();
            lista = (IList<Users>)Deserialize(lista, CSV_InputPath);


            foreach (Users dataObject in lista)
            {
                this.List_View.Items.Add(dataObject);
            }
        }



        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            numer_id = rand.Next(1, 100);
            this.List_View.Items.Add(newItem: new Users { ID = numer_id, Name = Name_TextBox.Text, Count = Count_TextBox.Text });
           
            

        }

        private void Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            List_View.Items.Clear();

        }

        private void Wyszukaj_Click(object sender, RoutedEventArgs e)
        {
            bool numeric = Int32.TryParse(Wyszukaj.Text, out int value);
            List_View.Items.Clear();
            if (Wyszukaj.Text.Length != 0)
            {
                foreach(Users item in lista)
                {
                    if ((numeric && item.Count == value.ToString()) || (!numeric && item.Name.Contains(Wyszukaj.Text)))
                    {
                        List_View.Items.Add(item);
                    }
                }
            }
            else
            {
                List_View.Items.Add(lista);
            }
            List_View.Items.Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            


            if (data_saved == false)
            {
                string msg = "Czy chcesz zamknąć bez zapisywania?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Zamknij",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {

                    Window okno = new Window();
                    okno.Close();
                }
                else
                {
                    Users user = new Users();
                    IList<Users> lista = new List<Users>();

                    foreach (Users item in List_View.Items)
                    {

                        lista.Add(user);

                    }

                    List_View.Items.Add(user);
                    List_View.Items.Refresh();
                    SaveFileDialog fileDialog = new SaveFileDialog();

                    fileDialog.Filter = "XML-File | *.xml";
                    fileDialog.ShowDialog();
                    string savePathCSV = fileDialog.FileName;
                    SerializeToXml(lista, savePathCSV);
                }
                }
            }
        }
    }