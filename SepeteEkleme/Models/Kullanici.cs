using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepeteEkleme.Models
{
    public class Kullanici
    {
        [Key]
        public int Kullanici_ID { get; set; }
        public string Kullanici_AdiSoyadi { get; set; }
        public string Kullanici_Email { get; set; }
        public string Kullanici_Sifre { get; set; }

        public List<Sepet> Sepets { get; set; }
    }
}
