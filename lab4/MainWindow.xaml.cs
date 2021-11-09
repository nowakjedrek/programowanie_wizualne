using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.IO;
using System.Drawing.Imaging;


namespace lab4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BitmapImage Obrazek;
        
        public MainWindow()
        {
            InitializeComponent();


        }
        private bool myBool;

        public void OnButtonClick()
        {
            myBool = !myBool;
        }
        public Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {

            bitmapImage = (BitmapImage)Obraz.Source;


            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmapa = new Bitmap(outStream);

                return new Bitmap(bitmapa);
            }
        }

        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog Picture = new OpenFileDialog();

            Picture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";



            if (Picture.ShowDialog() == true)
            {
                
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Picture.FileName);
                bitmap.EndInit();
                Obraz.Source = bitmap;
            }


        }

        private void Odbicie_Click(object sender, RoutedEventArgs e)
        {

            Bitmap bitmapa = BitmapImage2Bitmap(Obrazek);


            bitmapa.RotateFlip(RotateFlipType.Rotate180FlipY);

            using (var memory = new MemoryStream())
            {
                bitmapa.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var OdbicieImage = new BitmapImage();
                OdbicieImage.BeginInit();
                OdbicieImage.StreamSource = memory;
                OdbicieImage.CacheOption = BitmapCacheOption.OnLoad;
                OdbicieImage.EndInit();
                OdbicieImage.Freeze();


                Obraz.Source = OdbicieImage;


         }


        }

        private void Obrot_Click(object sender, RoutedEventArgs e)
        {
            
            Bitmap bitmapa = BitmapImage2Bitmap(Obrazek);
            bitmapa.RotateFlip(RotateFlipType.Rotate90FlipNone);

            using (var memory = new MemoryStream())
            {
                bitmapa.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var ObrotImage = new BitmapImage();
                ObrotImage.BeginInit();
                ObrotImage.StreamSource = memory;
                ObrotImage.CacheOption = BitmapCacheOption.OnLoad;
                ObrotImage.EndInit();
                ObrotImage.Freeze();


                Obraz.Source = ObrotImage;


            }
        }
        private void Zielony_Click(object sender, RoutedEventArgs e)
        {
            Bitmap bitmapa = BitmapImage2Bitmap(Obrazek);
            var width = bitmapa.Width;
            var height = bitmapa.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    System.Drawing.Color p = bitmapa.GetPixel(x, y);

                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    if (r > 200)
                    {
                        bitmapa.SetPixel(x, y, System.Drawing.Color.Gray);
                    }
                    else if (g < 130)
                    {
                        bitmapa.SetPixel(x, y, System.Drawing.Color.DarkGray);
                    }
                    else if (b > 130)
                    {
                        bitmapa.SetPixel(x, y, System.Drawing.Color.Black);
                    }
                }
            }
            using (var memory = new MemoryStream())
            {
                bitmapa.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var ZielonyImage = new BitmapImage();
                ZielonyImage.BeginInit();
                ZielonyImage.StreamSource = memory;
                ZielonyImage.CacheOption = BitmapCacheOption.OnLoad;
                ZielonyImage.EndInit();
                ZielonyImage.Freeze();


                Obraz.Source = ZielonyImage;
            }
        }
        private void Negatyw_Click(object sender, RoutedEventArgs e)
        {
            Bitmap bitmapa = BitmapImage2Bitmap(Obrazek);
            var width = bitmapa.Width;
            var height = bitmapa.Height;


            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    System.Drawing.Color p = bitmapa.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;
                    bitmapa.SetPixel(x, y, System.Drawing.Color.FromArgb(a, r, g, b));
                }
            }

            using (var memory = new MemoryStream())
            {
                bitmapa.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var NegatywImage = new BitmapImage();
                NegatywImage.BeginInit();
                NegatywImage.StreamSource = memory;
                NegatywImage.CacheOption = BitmapCacheOption.OnLoad;
                NegatywImage.EndInit();
                NegatywImage.Freeze();


                Obraz.Source = NegatywImage;
            }
        }

        private void Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            Bitmap bitmapa = BitmapImage2Bitmap(Obrazek);
            var width = bitmapa.Width;
            var height = bitmapa.Height;
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    System.Drawing.Color p = bitmapa.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    a = 255;
                    r = 255 ;
                    g = 255 ;
                    b = 255 ;
                    bitmapa.SetPixel(x, y, System.Drawing.Color.FromArgb(a, r, g, b));
                }
            }

            using (var memory = new MemoryStream())
            {
                bitmapa.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var WyczyscImage = new BitmapImage();
                WyczyscImage.BeginInit();
                WyczyscImage.StreamSource = memory;
                WyczyscImage.CacheOption = BitmapCacheOption.OnLoad;
                WyczyscImage.EndInit();
                WyczyscImage.Freeze();


                Obraz.Source = WyczyscImage;
            }

        }
    }

    }





