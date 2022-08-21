using Microsoft.Win32;
using SepeteEkleme.Models;
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

namespace SepeteEkleme.Views
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        double urunFiyat;

        public AdminPage()
        {
            InitializeComponent();
            btnResimSec.Click += BtnResimSec_Click;
            btnUrunEkle.Click += BtnUrunEkle_Click;
            txtUrunFiyat.TextChanged += TxtUrunFiyat_TextChanged;
        }

        private void TxtUrunFiyat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(txtUrunFiyat.Text, out urunFiyat))
            {
                txtUrunFiyat.Clear();
                txtUrunFiyat.Focus();
                txtUrunFiyat.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                txtUrunFiyat.BorderBrush = new SolidColorBrush(Colors.LightGray);
            }
        }

        private void BtnUrunEkle_Click(object sender, RoutedEventArgs e)
        {
            if ((!String.IsNullOrEmpty(txtUrunAd.Text) && !String.IsNullOrWhiteSpace(txtUrunAd.Text))&&
                (!String.IsNullOrEmpty(txtUrunFiyat.Text) && !String.IsNullOrWhiteSpace(txtUrunFiyat.Text))&&
                urunImg.Source!=null)
            {

                Data.db.Uruns.Add(new Urun()
                {
                    Urun_Ad = txtUrunAd.Text,
                    Urun_Fiyat = urunFiyat,
                    Urun_Resim = (BitmapImage)urunImg.Source
                });
                Data.db.SaveChanges();
                MessageBox.Show("Ürün eklendi.");
                NavigationService.Navigate(new UrunPage());

            }
            else
            {
                MessageBox.Show("Boş yerler var.");
                txtUrunAd.Clear();
                txtUrunFiyat.Clear();
                txtUrunAd.Focus();
            }
        }

        private void BtnResimSec_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg";
            ofd.ShowDialog();
            try
            {
                urunImg.Source = new BitmapImage(new Uri(ofd.FileName));
            }
            catch (Exception)
            {
                MessageBox.Show("Resim seçmek zorunludur.");
            }
        }
    }
}
