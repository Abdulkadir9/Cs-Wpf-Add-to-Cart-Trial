using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepeteEkleme.Models
{
    public class Sepet
    {
        [Key]
        public int Sepet_ID { get; set; }

        public int Sepet_KullaniciID { get; set; }
        public Kullanici Kullanicis { get; set; }

        public int Sepet_UrunID { get; set; }
        public Urun Uruns { get; set; }
        
    }
}
