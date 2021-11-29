﻿using Microsoft.Win32;
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

namespace lab7
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int numer_id;
        class Czytelnik
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public int ID { get; set; }

        }
        class Ksiazka
        {
            public string Tytul { get; set; }
            public string Autor { get; set; }
            public int ID_k { get; set; }
            public string Wyp { get; set; }

        }
        bool data_saved;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dodaj_czytelnika_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string CSV_InputPath = fileDialog.FileName;
            Lv_czytelnik.Items.Clear();

            string[] lines = File.ReadAllLines(CSV_InputPath);
            Random rand = new Random();


            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                Lv_czytelnik.Items.Add(new Czytelnik() { Imie = data[0], Nazwisko = data[1], ID = rand.Next(1, 50) });
            }
        }

        private void Dodaj_ksiazke_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string CSV_InputPath = fileDialog.FileName;
            Lv_czytelnik.Items.Clear();

            string[] lines = File.ReadAllLines(CSV_InputPath);
            Random rand = new Random();


            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                Lv_czytelnik.Items.Add(new Ksiazka() { Tytul = data[0], Autor = data[1], ID_k = rand.Next(51, 100) });
            }
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
                    FileDialog fileDialog = new OpenFileDialog();
                    if (fileDialog.ShowDialog() ?? true)
                    {
                        StreamWriter streamWriter = new StreamWriter(fileDialog.FileName);
                        StreamWriter sw = streamWriter;
                        foreach (Czytelnik item in Lv_czytelnik.Items)
                        {
                            sw.WriteLine("{0},{1},{2}", item.Imie, item.Nazwisko, item.ID);

                        }

                        StreamWriter streamWriter2 = new StreamWriter(fileDialog.FileName);
                        StreamWriter sw2 = streamWriter2;
                        foreach (Ksiazka item in Lv_ksiazka.Items)
                        {
                            sw2.WriteLine("{0},{1},{2},{3}", item.Tytul, item.Autor, item.ID_k, item.Wyp);
                        }
                    }
                }
            }
        }
    }
}
