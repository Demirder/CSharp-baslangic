using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ogrenci_not_ort
{
    internal class Program
    {

        ogrenci_bilgileri ogrenciBilgileri = new ogrenci_bilgileri("Demir Derin", 1, OgretimDuzeyi.Lise);
        ogretim ogretim = new ogretim("Açıktan Eğitim", 0, 0);
        lisans lisans = new lisans("Açıktan Eğitim", 0, 0);

        static void Main(string[] args)
        {

            // Öğrenci bilgilerini saklamak için ArrayList tanımlanır
            ArrayList ogrenciListesi = new ArrayList();


            string adSoyad = OgrenciAdikontrolEt();

            int okulNumarasi = OgrenciNumarasikontrolEt();

            // Öğrencinin öğretim düzeyini alalım
            int ogretimDuzeyiSecimi = 0;
            while (true)
            {

                Console.WriteLine("Öğrencinin Öğretim Düzeyini Girin (1=IlkOgretim, 2=OrtaOgretim, 3=Lise, 4=Lisans): ");
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out ogretimDuzeyiSecimi) && ogretimDuzeyiSecimi >= 1 && ogretimDuzeyiSecimi <= 4)
                {
                    if (ogretimDuzeyiSecimi == 4)  // Lisans ise okul adı ve notlar
                    {
                        Console.WriteLine("Okul Adını Giriniz:");
                        string fakulteAdi = Console.ReadLine();

                        double vize = 0, final = 0;
                        Console.WriteLine("Vize Notunu Giriniz (0-100):");
                        vize = Convert.ToDouble(Console.ReadLine());
                       

                        Console.WriteLine("Final Notunu Giriniz (0-100):");
                        final = Convert.ToDouble(Console.ReadLine());

                        lisans ogrenciLisans = new lisans(fakulteAdi, vize, final);
                        ogrenciLisans._Vize = vize;
                        ogrenciLisans._Final = final;
                        ogrenciListesi.Add(ogrenciLisans);
                        ogrenciLisans.NotHesapla();
                    }
                    else  // Diğer öğretim düzeyleri için
                    {
                        Console.WriteLine("Not1'i Giriniz (0-100):");
                        double not1 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Not2'yi Giriniz (0-100):");
                        double not2 = Convert.ToDouble(Console.ReadLine());

                        // Diğer düzeylerde öğrenciyi oluşturma
                        ogretim ogrenci1 = new ogretim("Lise Okulu", not1, not2);
                        ogrenci1._Not = not1; // Not1'e değer atama
                        ogrenci1._Not2 = not2; // Not2'ye değer atama
                        ogrenciListesi.Add(ogrenci1);
                        ogrenci1.NotHesapla(); // Not hesaplama
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Geçerli bir öğretim düzeyi seçin (1-4 arası).");
                }
            }



            // Öğrencinin öğretim düzeyini enum'a dönüştürme
            OgretimDuzeyi ogretimDuzeyi = (OgretimDuzeyi)(ogretimDuzeyiSecimi - 1);

            // Yeni öğrenci nesnesi oluşturuluyor
            ogrenci_bilgileri ogrenci = new ogrenci_bilgileri("Demir Derin", 1, OgretimDuzeyi.Lise) //Nesne Başlatma (Object Initializer) yöntemi, özellikle nesne özelliklerini tek bir satırda başlatmak ve daha esnek bir yapı kurmak için kullanışlı, constructor metoduna koyulmuş olan isimleri ana classtaki değişkenlere atıyorum
            {
                Adsoyad = adSoyad,
                Okulnumarasi = okulNumarasi,
                OgretimDuzeyi = ogretimDuzeyi
                
            };

           
            // Öğrenciyi listeye ekliyoruz
            ogrenciListesi.Add(ogrenci);

            // Öğrencilerin bilgilerini yazdırma
            Console.WriteLine("\nÖğrencilerin Bilgileri:");
            foreach (ogrenci_bilgileri o in ogrenciListesi)
            {
                Console.WriteLine("Ad Soyad: " + o.Adsoyad);
                Console.WriteLine("Okul Numarası: " + o.Okulnumarasi);
                Console.WriteLine("Okul Adı: " + o.OkulAdi); // Varsayılan olarak "Açıktan Eğitim"
                Console.WriteLine("Öğretim Düzeyi: " + o.OgretimDuzeyi);

            }


        }


        static string OgrenciAdikontrolEt()
        {

            // Kullanıcıdan veri alalım (Ad Soyad)
            string adSoyad = "";

            // Kullanıcıdan doğru ad soyad girişi alana kadar devam et
            while (true)
            {
                Console.WriteLine("Öğrencinin Ad Soyadını Giriniz: ");
                adSoyad = Console.ReadLine();

                // Ad Soyad boş olamaz
                if (string.IsNullOrWhiteSpace(adSoyad))
                {
                    Console.WriteLine("Ad Soyad boş olamaz. Lütfen tekrar girin.");
                    continue;
                }

                // Ad Soyad yalnızca harfler ve boşluklardan oluşmalı
                string pattern = @"^[A-Za-z\s]+$"; // Harf ve boşluklar için regex
                bool result = Regex.IsMatch(adSoyad, pattern);
                if (!result)
                {
                    Console.WriteLine("Ad Soyad yalnızca harfler ve boşluklardan oluşabilir. Lütfen tekrar girin.");
                    continue;
                }

                // Ad Soyad 2 kelimeden oluşmalı (ad ve soyad)
                string[] adSoyadArray = adSoyad.Split(' '); // Boşluktan ayırarak kelimelere bölelim
                if (adSoyadArray.Length < 2)
                {
                    Console.WriteLine("Ad Soyad en az iki kelimeden oluşmalı. Lütfen tekrar girin.");
                    continue;
                }

                // Eğer tüm kontroller geçildiyse, döngüden çıkalım
                break;
            }

            return adSoyad; // Geri döndürüyoruz

        }

        static int OgrenciNumarasikontrolEt()
        {

            // Öğrencinin okul numarasını alalım
            int okulNumarasi;
            while (true)
            {
                Console.WriteLine("Öğrencinin Okul Numarasını Giriniz: ");
                string okulNumarasiGirin = Console.ReadLine();

                if (int.TryParse(okulNumarasiGirin, out okulNumarasi))
                {
                    break; // Eğer geçerli bir okul numarası girildiyse çıkıyoruz
                }
                else
                {
                    Console.WriteLine("Geçerli bir okul numarası girin.");
                }
            }

            return okulNumarasi;

        }

        

    }
}
