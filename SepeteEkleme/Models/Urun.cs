using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SepeteEkleme.Models
{
    public class Urun
    {
        [Key]
        public int Urun_ID { get; set; }
        public string Urun_Ad { get; set; }
        public double Urun_Fiyat { get; set; }

        #region Resim / Byte Dizisi Dönüştürme
        [NotMapped] //Bu bilgiyi Veritabanı'na eklememek için kullanılır
        public BitmapSource Urun_Resim { get; set; }

        public byte[] ResimByte
        {
            get
            {
                byte[] byteDizisi;
                if (Urun_Resim == null)
                {
                    byteDizisi = new byte[0];
                }
                else
                {
                    using (var stream = new MemoryStream())
                    {
                        var kodlayıcı = new PngBitmapEncoder();
                        kodlayıcı.Frames.Add(BitmapFrame.Create(Urun_Resim));
                        kodlayıcı.Save(stream);
                        byteDizisi = stream.ToArray();
                    }
                }
                return byteDizisi;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    using (var stream = new MemoryStream(value))
                    {
                        var kodÇözücü = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        Urun_Resim = kodÇözücü.Frames[0];
                    }
                }
            }
        }
        #endregion

        public List<Sepet> Sepets { get; set; }

    }
}
