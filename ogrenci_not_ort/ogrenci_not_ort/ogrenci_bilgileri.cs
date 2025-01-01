using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogrenci_not_ort
{
    internal class ogrenci_bilgileri
    {

        public string Adsoyad { get; set; }
        public string OkulAdi { get; set; } = "Açıktan Eğitim";
        public int Okulnumarasi { get; set; }
        public OgretimDuzeyi OgretimDuzeyi { get; set; }

        public ogrenci_bilgileri(string adsoyad, int okulnumarasi, OgretimDuzeyi ogretimDuzeyi)
        {
            Adsoyad = adsoyad;
            Okulnumarasi = okulnumarasi;
            OgretimDuzeyi = ogretimDuzeyi;
        }
    }

    public enum OgretimDuzeyi
    {
        IlkOgretim,
        OrtaOgretim,
        Lise,
        Lisans
    }
}
