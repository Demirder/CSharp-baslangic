using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ToptanciUrunSistemi;

namespace ToptanciUrunSistemi
{
    // Ürün sınıfı
    internal class ToptanciUrun
    {
        public string Ad { get; set; }
        public int Fiyat { get; set; }
        public int Kilogram { get; set; }
        public string Kategori { get; set; }

        public ToptanciUrun(string ad, string kategori, int kilogram, int fiyat)
        {
            Ad = ad;
            Kilogram = kilogram;
            Fiyat = fiyat;
            Kategori = kategori;
        }
    }

    // Toptancı sınıfı
    internal class Toptanci
    {
        public List<ToptanciUrun> Urunler { get; private set; } // Ana ürünler listesi

        public Toptanci()
        {
            Urunler = new List<ToptanciUrun>(); // Ana ürünler listesi başlatılıyor
            UrunleriYukle(); // Ürünleri yükleme
        }

        private void UrunleriYukle()
        {
            // Sebzeler 
            string[] sebze = { "brokoli", "karnıbahar", "patlıcan", "domates", "biber" };
            int[] sebzeKg = { 100, 200, 500, 1000, 1000 };
            int[] sebzeFiyatlari = { 30, 30, 20, 25, 30 };
            

            // Sebzeleri ekle
            for (int i = 0; i < sebze.Length; i++)
            {
                Urunler.Add(new ToptanciUrun(sebze[i], "Sebze", sebzeKg[i], sebzeFiyatlari[i])); // "Sebze" kategorisini belirtiyoruz
            }

            // Meyveler
            string[] meyve = { "yeşil elma", "armut", "muz", "vişne", "çilek" };
            int[] meyveKg = { 200, 250, 300, 400, 400 };
            int[] meyveFiyatlari = { 15, 20, 20, 30, 50 };
            

            // Meyveleri ekle
            for (int i = 0; i < meyve.Length; i++)
            {
                Urunler.Add(new ToptanciUrun(meyve[i], "Meyve", meyveKg[i], meyveFiyatlari[i] )); // "Meyve" kategorisini belirtiyoruz
            }
        }

        public List<ToptanciUrun> GuncelUrunler()
        {
            return Urunler;
        }

        public void UrunleriListele()
        {
            Console.WriteLine("Toptancının Ürün Listesi:");
            foreach (var urun in Urunler)
            {
                Console.WriteLine($"{urun.Ad} - {urun.Kilogram} - {urun.Fiyat} TL");
            }
        }



    }
}

internal class halSecim()
{

    public void haleHosgeldiniz()
    { 

    Console.WriteLine("Hale Hoşgeldiniz. Meyve için M, Sebze için S tuşuna basınız, eğer meyve veya sebze kategorisine gitmeyecekseniz herhangi bir tuşa basınız.");
    

    }
}

internal class Manav
{
    public List<ToptanciUrun> AlinanUrunler { get; private set; } // Manav'ın aldığı ürünleri tutacak liste

    public Manav()
    {
        AlinanUrunler = new List<ToptanciUrun>(); // Listeyi başlatıyoruz
    }

    // Ürün ekleme metodu
    public void UrunEkle(ToptanciUrun urun)
    {
        AlinanUrunler.Add(urun); // Manav'ın listesine ürünü ekliyoruz
        Console.WriteLine($"{urun.Ad} ürününü aldınız.");
    }
}

internal class Musterisepeti
{
    

}

