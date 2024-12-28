using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_otomasyon
{internal class siparis
{
    // Yiyeceklerin isimleri ve fiyatlarını tutacak diziler
    public string[] corbalar { get; set; }
    public int[] corbaFiyatlari { get; set; }

    public string[] araSicaklar { get; set; }
    public int[] araSicakfiyatlari { get; set; }

    // İçeceklerin isimleri ve fiyatlarını tutacak diziler
    public string[] icecekler { get; set; }
    public int[] icecekFiyatlari { get; set; }

    // Kullanıcının verdiği siparişlerin listesi
    public List<string> Siparisler { get; set; }

    // Sayaç dizileri
    public int[] CorbaSayaç { get; set; }
    public int[] AraSicakSayaç { get; set; }
    public int[] IcecekSayaç { get; set; }

    // Sipariş sınıfının constructor'ı
    public siparis()
    {
        Siparisler = new List<string>(); // Siparişler listesi başlatılıyor

        // Yiyecekler ve fiyatlarını tanımlıyoruz
        corbalar = new string[]
        {
            "Mercimek Çorbası", "Tavuk Suyu Çorbası", "Lahana Çorbası", "Tarhana Çorbası", "Ezogelin Çorbası"
        };

        corbaFiyatlari = new int[] { 30, 30, 30, 50, 40 };

        araSicaklar = new string[]
        {
            "Nohut", "Kuru Fasulye", "Tavuk Sote", "Ciğer", "Fırında Köfte Patates"
        };

        araSicakfiyatlari = new int[] { 60, 50, 80, 60, 70 };

        // İçecekler ve fiyatlarını tanımlıyoruz
        icecekler = new string[] { "Su", "Ayran", "Kola", "Fanta" };
        icecekFiyatlari = new int[] { 10, 15, 20, 20 };

        // Sayaç dizilerini başlatıyoruz (her ürün için bir sayaç)
        CorbaSayaç = new int[corbalar.Length];  // çorba ürününün uzunluğu kadar ürünleri tutar ve seçilenlere göre sayaç tutar.
        AraSicakSayaç = new int[araSicaklar.Length];  // her ara sıcak için sayaç
        IcecekSayaç = new int[icecekler.Length];  // her içecek için sayaç
    }

    // Sipariş edilen ürünlerin ek detaylarını gösteren fonksiyon
    public void SiparisGoster()
    {
        // Yiyecekleri ve fiyatlarını yazdırma
        Console.WriteLine("Çorbalar ve Fiyatları:");
        for (int i = 0; i < corbalar.Length; i++)
        {
            Console.WriteLine($"{corbalar[i]} - {corbaFiyatlari[i]} TL");
        }

        // Ara sıcakları ve fiyatlarını yazdırma
        Console.WriteLine("\nAra sıcaklar ve Fiyatları:");
        for (int i = 0; i < araSicaklar.Length; i++)
        {
            Console.WriteLine($"{araSicaklar[i]} - {araSicakfiyatlari[i]} TL");
        }

        // İçecekleri ve fiyatlarını yazdırma
        Console.WriteLine("\nİçecekler ve Fiyatları:");
        for (int i = 0; i < icecekler.Length; i++)
        {
            Console.WriteLine($"{icecekler[i]} - {icecekFiyatlari[i]} TL");
        }

        // Kullanıcının siparişlerini yazdırma
        Console.WriteLine("\nSipariş edilenler:");
        foreach (var item in Siparisler)
        {
            Console.WriteLine(item);
        }
    }

    // Sipariş verilerini sayaçlarla güncelleme
    public void SiparisAl(string corba, string araSicak, string icecek)
    {
        // Siparişleri eklerken, sayaçları da güncelle
        Siparisler.Add($"Çorba: {corba}, Ara Sıcak: {araSicak}, İçecek: {icecek}");

        // Sayaçları güncelle
        int corbaIndex = Array.IndexOf(corbalar, corba);
        if (corbaIndex != -1)
            CorbaSayaç[corbaIndex]++;

        int araSicakIndex = Array.IndexOf(araSicaklar, araSicak);
        if (araSicakIndex != -1)
            AraSicakSayaç[araSicakIndex]++;

        int icecekIndex = Array.IndexOf(icecekler, icecek);
        if (icecekIndex != -1)
            IcecekSayaç[icecekIndex]++;
    }

    // Z raporu ve en çok tercih edilen ürünleri gösteren fonksiyon
    public void ZRaporu()
    {
        Console.WriteLine("\nZ Raporu: En çok tercih edilen ürünler");

        // Çorbaların en çok tercih edileni
        Console.WriteLine("\nÇorbalar:");
        for (int i = 0; i < CorbaSayaç.Length; i++)
        {
            Console.WriteLine($"{corbalar[i]}: {CorbaSayaç[i]} kez tercih edildi.");
        }

        // Ara sıcakların en çok tercih edileni
        Console.WriteLine("\nAra Sıcaklar:");
        for (int i = 0; i < AraSicakSayaç.Length; i++)
        {
            Console.WriteLine($"{araSicaklar[i]}: {AraSicakSayaç[i]} kez tercih edildi.");
        }

        // İçeceklerin en çok tercih edileni
        Console.WriteLine("\nİçecekler:");
        for (int i = 0; i < IcecekSayaç.Length; i++)
        {
            Console.WriteLine($"{icecekler[i]}: {IcecekSayaç[i]} kez tercih edildi.");
        }

        // En çok tercih edilen ürünü belirleme
        int maxCorba = CorbaSayaç.Max();
        int maxAraSicak = AraSicakSayaç.Max();
        int maxIcecek = IcecekSayaç.Max();

        Console.WriteLine("\nEn çok tercih edilen ürünler:");
        Console.WriteLine($"En çok tercih edilen çorba: {corbalar[Array.IndexOf(CorbaSayaç, maxCorba)]} : {corbaFiyatlari[Array.IndexOf(CorbaSayaç, maxCorba)]} - {maxCorba} kez");
        Console.WriteLine($"En çok tercih edilen ara sıcak: {araSicaklar[Array.IndexOf(AraSicakSayaç, maxAraSicak)]} : {araSicakfiyatlari[Array.IndexOf(AraSicakSayaç, maxAraSicak)]} - {maxAraSicak} kez");
        Console.WriteLine($"En çok tercih edilen içecek: {icecekler[Array.IndexOf(IcecekSayaç, maxIcecek)]} : {icecekFiyatlari[Array.IndexOf(IcecekSayaç, maxIcecek)]} - {maxIcecek} kez");
    }
}
}
