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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace lab9
{
    public class Licencjat
    {
        public string Uczelnia { get; set; }
        public string Profil { get; set; }
        public string Kierunek { get; set; }
        public string FormaStudiow { get; set; }
        public string Zakres { get; set; }
        public string Poziom { get; set; }
        public string Student { get; set; }
        public string Indeks { get; set; }
        public string DataiPodpis { get; set; }
        public string Tytul { get; set; }
        public string Angielski { get; set; }
        public string Input { get; set; }
        public string ZakresPracy { get; set; }
        public string Termin { get; set; }
        public string Promotor { get; set; }
        public string JednostkaPromotora { get; set; }
        public string PodpisKierownika { get; set; }
        public string DataPodpisu { get; set; }
        public string PodpisDziekana { get; set; }

    }
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Licencjat> formularz = new List<Licencjat>();
        public MainWindow()
        {
            InitializeComponent();
            string msg = "Czy chcesz wczytać formularz?";
            MessageBoxResult result = System.Windows.MessageBox.Show(msg, "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();

                string inputPathXML = fileDialog.FileName;

                if (fileDialog.FileName != string.Empty)
                {
                    using (TextReader reader = new StreamReader(inputPathXML))
                    {
                        XmlSerializer serializer = new XmlSerializer(formularz.GetType());
                        formularz = (List<Licencjat>)serializer.Deserialize(reader);
                    }
                    this.DataContext = formularz;
                    this.Show();
                }
             }
            else if (result == MessageBoxResult.No)
            {
                formularz.Add(new Licencjat());
                this.DataContext = formularz;
                this.Show();
            }
        }
        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string msg2 = "Czy chcesz zapisać wprowadzone zmiany?";
            MessageBoxResult result = System.Windows.MessageBox.Show(msg2, "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";

                fileDialog.ShowDialog();
                string savePathXML = fileDialog.FileName;

                if (fileDialog.FileName != string.Empty)
                {
                    formularz[0].Uczelnia = Uczelnia_text.Text;
                    formularz[0].Profil = Profil_text.Text;
                    formularz[0].Kierunek = Kierunek_text.Text;
                    formularz[0].FormaStudiow = FormaStudiow_text.Text;
                    formularz[0].Zakres = Zakres_text.Text;
                    formularz[0].Poziom = Poziom_text.Text;
                    formularz[0].Student = Student_text.Text;
                    formularz[0].Indeks = Indeks_text.Text;
                    formularz[0].DataiPodpis = DataiPodpis_text.Text;
                    formularz[0].Tytul = Tytul_text.Text;
                    formularz[0].Angielski = Angielski_text.Text;
                    formularz[0].Input = Input_text.Text;
                    formularz[0].ZakresPracy = ZakresPracy_text.Text;
                    formularz[0].Termin = Termin_text.Text;
                    formularz[0].Promotor = Promotor_text.Text;
                    formularz[0].JednostkaPromotora = JednostkaPromotora_text.Text;
                    formularz[0].PodpisKierownika = PodpisKierownika_text.Text;
                    formularz[0].DataPodpisu = DataPodpisu_text.Text;
                    formularz[0].PodpisDziekana = PodpisDziekana_text.Text;


                    XmlSerializer save = new XmlSerializer(formularz.GetType());
                    TextWriter writer = new StreamWriter(savePathXML);
                    save.Serialize(writer, formularz);

                }
            }

            else if (result == MessageBoxResult.No)
            {
                this.Close();
            }

        }
    }
}