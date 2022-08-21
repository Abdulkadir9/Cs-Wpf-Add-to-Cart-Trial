using SepeteEkleme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Interaction logic for KayitOl.xaml
    /// </summary>
    public partial class KayitOl : Page
    {
        public KayitOl()
        {
            InitializeComponent();
            btnKayitOl.Click += BtnKayitOl_Click;
            btnGoGirisYap.Click += BtnGoGirisYap_Click;
        }

        private void BtnKayitOl_Click(object sender, RoutedEventArgs e)
        {
            if ((!String.IsNullOrEmpty(txtAdSoyad.Text) && !String.IsNullOrWhiteSpace(txtAdSoyad.Text))
                && (!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrWhiteSpace(txtEmail.Text)) &&
                (!String.IsNullOrEmpty(pbSifre.Password) && !String.IsNullOrWhiteSpace(pbSifre.Password)))
            {

                foreach (var k in Data.db.Kullanicis)
                {
                    if (k.Kullanici_Email != txtEmail.Text)
                    {
                        Data.db.Kullanicis.Add(new Kullanici()
                        {
                            Kullanici_AdiSoyadi = txtAdSoyad.Text,
                            Kullanici_Email = txtEmail.Text,
                            Kullanici_Sifre = pbSifre.Password,
                        });
                        Data.db.SaveChanges();
                        MessageBox.Show("Kayıl olundu,\nGiriş yapma sayfasına yönlendiriliyorsun.");
                        NavigationService.Navigate(new ProfilPage());
                    }
                    else
                    {
                        MessageBox.Show("Sistemde zaten böyle bir Email var.");
                        txtEmail.Clear();
                        txtEmail.Focus();
                    }
                }

            }
            else
            {
                MessageBox.Show("Tüm alanları doldurduğunuzdan emin olun.");

                txtAdSoyad.Clear();
                txtEmail.Clear();
                pbSifre.Clear();

                txtAdSoyad.Focus();
            }
        }



        private void BtnGoGirisYap_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilPage());
        }
    }
}
