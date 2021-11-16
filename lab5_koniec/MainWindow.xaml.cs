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

namespace lab5
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public int count;
        public string Seq;
        Dictionary<string, int> dict = new Dictionary<string, int>();
        public string richtekst;
        public int counter;


        public MainWindow()
        {
            InitializeComponent();

        }

        public int PatternCount(string text, string pattern)
        {
            for (int i = 0; i < (text.Length - pattern.Length); i++)
            {
                if (text.Substring(i, pattern.Length) == pattern)
                {
                    count++;
                }
            }

            return count;
        }




        private void Znajdz_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Seq.Length - 4; i++)
            {
                string pattern = Seq.Substring(i, 4);
                dict[pattern] = PatternCount(Seq, pattern);
            }
            TextRange textRange = new TextRange(Rich.Document.ContentStart, Rich.Document.ContentEnd);
            string textBoxText = textRange.Text;
            textBoxText = Seq;
            Wzorce.Text = "";
            Combo_box.Items.Clear();
            foreach (KeyValuePair<string, int> row in dict.OrderByDescending(key => key.Value))
            {
                Regex regex = new Regex(row.Key);
                int count_MatchFound = Regex.Matches(textBoxText, regex.ToString()).Count;
                if(count_MatchFound > 0)
                {
                    count_MatchFound++ ;
                }
                counter = count_MatchFound -1;
                {
                    Wzorce.Text += row.Key + " występuje " + counter +  " razy" + "\n";
                    Combo_box.Items.Add(row.Key);
                }
            }

        }


        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Tekst = new OpenFileDialog();

            Tekst.Filter = "Text files|*.txt;*.fasta;|All files|*.*";



            if (Tekst.ShowDialog() == true)
            {
                string filename = Tekst.FileName;
                
                Run nuc =new Run(File.ReadAllText(filename));
                Paragraph paragraf = new Paragraph(nuc);

                Rich.Document.Blocks.Add(paragraf);
                Seq = nuc.Text;
             
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            richtekst = Combo_box.SelectedItem.ToString();
            TextRange textRange = new TextRange(Rich.Document.ContentStart, Rich.Document.ContentEnd);
            textRange.ClearAllProperties();
            
            
            for (TextPointer startPointer = Rich.Document.ContentStart;
                        startPointer.CompareTo(Rich.Document.ContentEnd) <= 0;
                            startPointer = startPointer.GetNextContextPosition(LogicalDirection.Forward))
            {
                
                if (startPointer.CompareTo(Rich.Document.ContentEnd) == 0)
                {
                    break;
                }

                
                string parsedString = startPointer.GetTextInRun(LogicalDirection.Forward);
                int indexOfParseString = parsedString.IndexOf(richtekst);

                if (indexOfParseString >= 0) 
                {
                   
                    startPointer = startPointer.GetPositionAtOffset(indexOfParseString);

                    if (startPointer != null)
                    {
               
                        TextPointer nextPointer = startPointer.GetPositionAtOffset(richtekst.Length);
                        TextRange searchedTextRange = new TextRange(startPointer, nextPointer);
                         searchedTextRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Red));


                    }
                }
            }
        }


    }

    }

