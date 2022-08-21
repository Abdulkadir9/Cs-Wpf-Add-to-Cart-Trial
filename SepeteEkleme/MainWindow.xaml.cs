using SepeteEkleme.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace SepeteEkleme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button btn = new Button();
        
        public MainWindow()
        {
            InitializeComponent();
            btn.Click += Btn_Click;
            btnAnasayfa.Click += Btn_Click;
            btnProfil.Click += Btn_Click;
            btnSepet.Click += Btn_Click;

            frm.Content = new UrunPage();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            btn = sender as Button;
            switch (btn.Name)
            {
                case "btnAnasayfa":
                    frm.Content = new UrunPage();
                    break;
                case "btnProfil":
                    frm.Navigate(new ProfilPage());
                    break;
                case "btnSepet":
                    frm.Content = new SepetPage();
                    break;
            }
        }
    }
}
