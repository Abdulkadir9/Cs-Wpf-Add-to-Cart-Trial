using SepeteEkleme.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SepeteEkleme.Views
{
    /// <summary>
    /// Interaction logic for SepetPage.xaml
    /// </summary>
    public partial class SepetPage : Page
    {
        Uri cookieUri = new Uri(@"C:\Users\Kadir\Desktop");
        int kullaniciId;       
        
        public SepetPage()
        {
            InitializeComponent();

            try
            {
                kullaniciId = int.Parse(Application.GetCookie(cookieUri));

                foreach (var k in Data.db.Sepets)
                {
                    if (k.Sepet_KullaniciID == kullaniciId)
                    {
                        lbSepetims.Items.Add(Data.db.Uruns.Where(x => x.Urun_ID == k.Sepet_UrunID).ToList());                        
                    }
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Sepetini görmek için giriş yapmalısın.");                
            }
        }
    }
}
