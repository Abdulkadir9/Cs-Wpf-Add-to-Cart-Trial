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
    /// Interaction logic for ProfilPage.xaml
    /// </summary>
    public partial class ProfilPage : Page
    {
        Uri cookieUri = new Uri(@"C:\Users\Kadir\Desktop");
        bool girisYapildi = false;
        int kullaniciId;

        public ProfilPage()
        {
            InitializeComponent();
            btnGoKayitOl.Click += BtnGoKayitOl_Click;
            btnGirisYap.Click += BtnGirisYap_Click;
            
            try
            {
                kullaniciId = int.Parse(Application.GetCookie(cookieUri));                
                girisYapPanel.Visibility = Visibility.Hidden;
                cikisYapPanel.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                girisYapPanel.Visibility = Visibility.Visible;
                cikisYapPanel.Visibility = Visibility.Hidden;
            }

            btnCikisYap.Click += BtnCikisYap_Click;
        }

        private void BtnCikisYap_Click(object sender, RoutedEventArgs e)
        {
            Application.SetCookie(cookieUri, "");
            NavigationService.Navigate(new ProfilPage());
        }

        private void BtnGirisYap_Click(object sender, RoutedEventArgs e)
        {
            if ((!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrWhiteSpace(txtEmail.Text)) &&
                (!String.IsNullOrEmpty(pbSifre.Password) && !String.IsNullOrWhiteSpace(pbSifre.Password)))
            {
                foreach (var k in Data.db.Kullanicis)
                {
                    if (txtEmail.Text == k.Kullanici_Email && pbSifre.Password == k.Kullanici_Sifre)
                    {
                        girisYapildi = true;
                        kullaniciId = k.Kullanici_ID;
                    }
                }

                if (girisYapildi == true)
                {
                    MessageBox.Show("Giriş yapıldı.");
                    Application.SetCookie(cookieUri, kullaniciId.ToString());
                    NavigationService.Navigate(new UrunPage());
                }
                else if (txtEmail.Text == "admin" && pbSifre.Password == "admin")
                {
                    MessageBox.Show("Hoş geldiniz admin beys.");
                    NavigationService.Navigate(new AdminPage());
                }
                else
                {
                    MessageBox.Show("Sistemde kayıt değil.");
                    txtEmail.Clear();
                    pbSifre.Clear();
                    txtEmail.Focus();
                }

            }
            else
            {
                MessageBox.Show("Tüm alanları doldurduğunuzdan emin olun.");

                txtEmail.Clear();
                pbSifre.Clear();

                txtEmail.Focus();
            }
        }

        private void BtnGoKayitOl_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KayitOl());
        }
    }
}
