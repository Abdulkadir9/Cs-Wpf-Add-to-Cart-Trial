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
    /// Interaction logic for UrunPage.xaml
    /// </summary>
    public partial class UrunPage : Page
    {
        Uri cookieUri = new Uri(@"C:\Users\Kadir\Desktop");
        int kullaniciId;
        public UrunPage()
        {
            InitializeComponent();            

            lbUruns.ItemsSource = Data.db.Uruns.ToList();            
        }

        private void btnSepeteEkle_Click(object sender, RoutedEventArgs e)
        {            
            Button btn = new Button();
            btn = sender as Button;

            try
            {
                kullaniciId = int.Parse(Application.GetCookie(cookieUri));

                Data.db.Sepets.Add(new Sepet()
                {
                    Sepet_KullaniciID = kullaniciId,
                    Sepet_UrunID = int.Parse(btn.Tag.ToString()),
                });
                Data.db.SaveChanges();
                MessageBox.Show("Ürün eklendi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Ürünü eklemek için giriş yapmalısın.");
                NavigationService.Content = new ProfilPage();
            }

        }
    }
}
