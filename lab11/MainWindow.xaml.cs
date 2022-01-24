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
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;


namespace lab11
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly CspParameters _cspp = new CspParameters();
        RSACryptoServiceProvider _rsa;
        public string lines;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ukryj_Click(object sender, RoutedEventArgs e)
        {
            _cspp.KeyContainerName = Klucz.Text;
            _rsa = new RSACryptoServiceProvider(_cspp)
            {
                PersistKeyInCsp = true
            };
            Aes aes = Aes.Create();
            ICryptoTransform transform = aes.CreateEncryptor();

           
            byte[] keyEncrypted = _rsa.Encrypt(aes.Key, false);

           
            int lKey = keyEncrypted.Length;
            byte[] LenK = BitConverter.GetBytes(lKey);
            int lIV = aes.IV.Length;
            byte[] LenIV = BitConverter.GetBytes(lIV);
            MemoryStream enc_stream = new MemoryStream();
            CryptoStream outStreamEncrypted =
            new CryptoStream(enc_stream, transform, CryptoStreamMode.Write);
            byte[] bytes = new UTF8Encoding(false).GetBytes(Tekst.Text);
            outStreamEncrypted.Write(bytes, 0, bytes.Length);
            outStreamEncrypted.FlushFinalBlock();
            outStreamEncrypted.Close();
            byte[] encrypted = enc_stream.ToArray();
            Hash.Text = encrypted.ToString();

        }



            

            private void Zapisz_Click(object sender, RoutedEventArgs e)
            {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".txt";
            if (fileDialog.ShowDialog() ?? true)
            {
                StreamWriter streamWriter = new StreamWriter(fileDialog.FileName);
                StreamWriter sw = streamWriter;


                sw.WriteLine(Hash.Text);
                
            }
            else
            {
                MessageBox.Show("Zapisywanie nie powiodło się!");
            }
        }
        }
    }
