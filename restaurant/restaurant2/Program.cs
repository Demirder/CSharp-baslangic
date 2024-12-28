using restaurant2;
using System.Collections.Generic;

namespace restaurant_otomasyon
{
    internal class Program
    {



        static void Main(string[] args)
        {
            masa masa1 = new masa(1, "Boş"); //ilk masa numarası ve durumu yazılı, yapıcı metot kullanıldığı için parametre yazılır.
            siparis siparis1 = new siparis();
            List<masa> masalar = new List<masa>();

            // 5 masa tanımlama

            for (int i = 1; i <= 5; i++)
            {
                masalar.Add(new masa(i, "Boş"));

            }

            Console.WriteLine("Restauranta Hoşgeldiniz.");

            while (true)
            {


                bosMasalar(masalar);

                int secilenMasa;
                int kisiSayisi;

                // Programın bitmemesi için kullanıcıdan bir tuşa basılmasını bekliyoruz
                Console.WriteLine("\nMasa seçiniz..");
                secilenMasa = int.Parse(Console.ReadLine());


                if (secilenMasa < 1 || secilenMasa > 5)

                {

                    Console.WriteLine("Yanlış seçim, bir daha deneyiniz.");

                }

                else

                {

                    // Masayı buluyoruz
                    masa secilenMasaObjesi = masalar.FirstOrDefault(m => m.MasaNo == secilenMasa); //masaların dolu boş olduğunu anlamamıza yarayan LINQ yöntemi

                    // Masa bulunmuş mu ve durumu boş mu kontrolü
                    if (secilenMasaObjesi != null && secilenMasaObjesi.Durum == "Boş")
                    {
                        Console.WriteLine("Kaç kişi olacaktınız?");
                        kisiSayisi = int.Parse(Console.ReadLine());

                        // Masanın durumunu "Dolu" olarak güncelliyoruz
                        secilenMasaObjesi.Durum = "Dolu";
                        Console.WriteLine($"{secilenMasaObjesi.MasaNo} numaralı masaya {kisiSayisi} kişi oturdu.");

                        // Her kişi için sipariş alıyoruz
                        for (int i = 0; i < kisiSayisi; i++)
                        {
                            Console.WriteLine($"\n{i + 1}. Kişi için seçim yapınız:");

                            // Çorba seçim ekranı
                            Console.WriteLine("\nÇorbalar ve Fiyatları:");
                            for (int j = 0; j < siparis1.corbalar.Length; j++)
                            {
                                Console.WriteLine($"{j + 1}. {siparis1.corbalar[j]} - {siparis1.corbaFiyatlari[j]} TL");
                            }
                            Console.Write("Bir çorba seçiniz (1-5) ya da '0' girin istemiyorsanız: ");
                            int corbaSecim = int.Parse(Console.ReadLine());

                            if (corbaSecim != 0)
                            {
                                siparis1.Siparisler.Add(siparis1.corbalar[corbaSecim - 1]);
                            }
                            else
                            {
                                siparis1.Siparisler.Add("Hiçbir çorba istemedi.");
                            }

                            // Ara sıcak seçim ekranı
                            Console.WriteLine("\nAra Sıcaklar ve Fiyatları:");
                            for (int j = 0; j < siparis1.araSicaklar.Length; j++)
                            {
                                Console.WriteLine($"{j + 1}. {siparis1.araSicaklar[j]} - {siparis1.araSicakfiyatlari[j]} TL");
                            }
                            Console.Write("Bir ara sıcak seçiniz (1-5) ya da '0' girin istemiyorsanız: ");
                            int araSicakSecim = int.Parse(Console.ReadLine());

                            if (araSicakSecim != 0)
                            {
                                siparis1.Siparisler.Add(siparis1.araSicaklar[araSicakSecim - 1]); // add seçilen ara sıcağı eklemek için kullanıldı.
                            }
                            else
                            {
                                siparis1.Siparisler.Add("Hiçbir ara sıcak istemedi.");
                            }

                            // İçecek seçim ekranı
                            Console.WriteLine("\nİçecekler ve Fiyatları:");
                            for (int j = 0; j < siparis1.icecekler.Length; j++)
                            {
                                Console.WriteLine($"{j + 1}. {siparis1.icecekler[j]} - {siparis1.icecekFiyatlari[j]} TL");
                            }
                            Console.Write("Bir içecek seçiniz (1-4) ya da '0' girin istemiyorsanız: ");
                            int icecekSecim = int.Parse(Console.ReadLine());

                            if (icecekSecim != 0)
                            {
                                siparis1.Siparisler.Add(siparis1.icecekler[icecekSecim - 1]);
                            }
                            else
                            {
                                siparis1.Siparisler.Add("Hiçbir içecek istemedi.");
                            }


                            bool devamEt = true;

                            while (devamEt)
                            {

                                Console.Write("Başka arzunuz var mı, V yi tuşlayınız, yoksa H'yi tuşlayınız.");
                                char secim_V_H = Char.ToUpper(Console.ReadKey().KeyChar); // kullanıcıdan harf al, büyüğe çevir ve işlemi gerçekleştir.
                                Console.WriteLine();

                                if (secim_V_H == 'V')
                                {

                                    Console.WriteLine("Menüye yönlendiriliyorsunuz.");
                                    siparisAl();


                                }

                                else if (secim_V_H == 'H')
                                {

                                    devamEt = false;

                                }

                                else
                                {

                                    Console.WriteLine("Geçerli tuşlama yapınız.");

                                }
                            }

                            Console.WriteLine();
                            // Siparişi gösteriyoruz
                            Console.WriteLine("\nSiparişler alındı:");
                            siparis1.SiparisGoster();

                            int hesapTutari = 0;
                            Console.WriteLine($"Hesabınız: {hesapTutari}");

                        }


                        Console.WriteLine("Yeni müşteri var mı, varsa e yi tuşlayınız, yoksa Z raporu gösterilecek ve en çok tercih edilen ürünler listelenecek. ");
                        char secim = Char.ToUpper(Console.ReadKey().KeyChar);

                        if (secim == 'E')
                        {
                            MasaSecimVeKisiSayisiAl(masalar, siparis1);
                        }

                        else

                        {

                            Console.WriteLine("Z raporu gösterilecek ve en çok tercih edilen ürünler listelenecek. ");

                            siparis1.ZRaporu();
                            break;
                        }

                    }

                    else if (secilenMasaObjesi != null && secilenMasaObjesi.Durum == "Dolu") //masa var mı ve dolu mu boş mu kontrolü
                    {
                        Console.WriteLine("Bu masa zaten dolu.");
                    }

                    else
                    {
                        Console.WriteLine("Geçersiz masa numarası.");
                    }

                }


            }


        }

        static void bosMasalar(List<masa> masalar)
        {

            // Masaları gösterme
            foreach (var masa in masalar)
            {
                Console.WriteLine($"Masa No: {masa.MasaNo}, Durum: {masa.Durum}");

            }

        }

        static void siparisAl()
        {

            siparis siparis1 = new siparis();


            // Çorba seçim ekranı
            Console.WriteLine("\nÇorbalar ve Fiyatları:");
            for (int j = 0; j < siparis1.corbalar.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {siparis1.corbalar[j]} - {siparis1.corbaFiyatlari[j]} TL");
            }
            Console.Write("Bir çorba seçiniz (1-5) ya da '0' girin istemiyorsanız: ");
            int corbaSecim = int.Parse(Console.ReadLine());

            if (corbaSecim != 0)
            {
                siparis1.Siparisler.Add(siparis1.corbalar[corbaSecim - 1]);
            }
            else
            {
                siparis1.Siparisler.Add("Hiçbir çorba istemedi.");
            }

            // Ara sıcak seçim ekranı
            Console.WriteLine("\nAra Sıcaklar ve Fiyatları:");
            for (int j = 0; j < siparis1.araSicaklar.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {siparis1.araSicaklar[j]} - {siparis1.araSicakfiyatlari[j]} TL");
            }
            Console.Write("Bir ara sıcak seçiniz (1-5) ya da '0' girin istemiyorsanız: ");
            int araSicakSecim = int.Parse(Console.ReadLine());

            if (araSicakSecim != 0)
            {
                siparis1.Siparisler.Add(siparis1.araSicaklar[araSicakSecim - 1]);
            }
            else
            {
                siparis1.Siparisler.Add("Hiçbir ara sıcak istemedi.");
            }

            // İçecek seçim ekranı
            Console.WriteLine("\nİçecekler ve Fiyatları:");
            for (int j = 0; j < siparis1.icecekler.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {siparis1.icecekler[j]} - {siparis1.icecekFiyatlari[j]} TL");
            }
            Console.Write("Bir içecek seçiniz (1-4) ya da '0' girin istemiyorsanız: ");
            int icecekSecim = int.Parse(Console.ReadLine());

            if (icecekSecim != 0)
            {
                siparis1.Siparisler.Add(siparis1.icecekler[icecekSecim - 1]);
            }
            else
            {
                siparis1.Siparisler.Add("Hiçbir içecek istemedi.");
            }



        }

        // Masa seçimi ve kişi sayısı alma işlemi
        static void MasaSecimVeKisiSayisiAl(List<masa> masalar, siparis siparis1)
        {
            int secilenMasa;
            int kisiSayisi;

            // Boş masaları listele
            bosMasalar(masalar);

            Console.WriteLine("\nMasa seçiniz..");
            secilenMasa = int.Parse(Console.ReadLine());

            if (secilenMasa < 1 || secilenMasa > 5)
            {
                Console.WriteLine("Yanlış seçim, bir daha deneyiniz.");
            }
            else
            {
                // Masayı buluyoruz
                masa secilenMasaObjesi = masalar.FirstOrDefault(m => m.MasaNo == secilenMasa);

                // Masa bulunmuş mu ve durumu boş mu kontrolü
                if (secilenMasaObjesi != null && secilenMasaObjesi.Durum == "Boş")
                {
                    Console.WriteLine("Kaç kişi olacaktınız?");
                    kisiSayisi = int.Parse(Console.ReadLine());

                    // Masanın durumunu "Dolu" olarak güncelliyoruz
                    secilenMasaObjesi.Durum = "Dolu";
                    Console.WriteLine($"{secilenMasaObjesi.MasaNo} numaralı masaya {kisiSayisi} kişi oturdu.");

                    // Her kişi için sipariş alıyoruz
                    for (int i = 0; i < kisiSayisi; i++)
                    {
                        Console.WriteLine($"\n{i + 1}. Kişi için seçim yapınız:");

                        // Çorba seçim ekranı
                        Console.WriteLine("\nÇorbalar ve Fiyatları:");
                        for (int j = 0; j < siparis1.corbalar.Length; j++)
                        {
                            Console.WriteLine($"{j + 1}. {siparis1.corbalar[j]} - {siparis1.corbaFiyatlari[j]} TL");
                        }
                        Console.Write("Bir çorba seçiniz (1-5) ya da '0' girin istemiyorsanız: ");
                        int corbaSecim = int.Parse(Console.ReadLine());

                        if (corbaSecim != 0)
                        {
                            siparis1.Siparisler.Add(siparis1.corbalar[corbaSecim - 1]);
                        }
                        else
                        {
                            siparis1.Siparisler.Add("Hiçbir çorba istemedi.");
                        }

                        // Ara sıcak seçim ekranı
                        Console.WriteLine("\nAra Sıcaklar ve Fiyatları:");
                        for (int j = 0; j < siparis1.araSicaklar.Length; j++)
                        {
                            Console.WriteLine($"{j + 1}. {siparis1.araSicaklar[j]} - {siparis1.araSicakfiyatlari[j]} TL");
                        }
                        Console.Write("Bir ara sıcak seçiniz (1-5) ya da '0' girin istemiyorsanız: ");
                        int araSicakSecim = int.Parse(Console.ReadLine());

                        if (araSicakSecim != 0)
                        {
                            siparis1.Siparisler.Add(siparis1.araSicaklar[araSicakSecim - 1]);
                        }
                        else
                        {
                            siparis1.Siparisler.Add("Hiçbir ara sıcak istemedi.");
                        }

                        // İçecek seçim ekranı
                        Console.WriteLine("\nİçecekler ve Fiyatları:");
                        for (int j = 0; j < siparis1.icecekler.Length; j++)
                        {
                            Console.WriteLine($"{j + 1}. {siparis1.icecekler[j]} - {siparis1.icecekFiyatlari[j]} TL");
                        }
                        Console.Write("Bir içecek seçiniz (1-4) ya da '0' girin istemiyorsanız: ");
                        int icecekSecim = int.Parse(Console.ReadLine());

                        if (icecekSecim != 0)
                        {
                            siparis1.Siparisler.Add(siparis1.icecekler[icecekSecim - 1]);
                        }
                        else
                        {
                            siparis1.Siparisler.Add("Hiçbir içecek istemedi.");
                        }

                        bool devamEt = true;
                        while (devamEt)
                        {
                            Console.Write("Başka arzunuz var mı, V'yi tuşlayınız, yoksa H'yi tuşlayınız.");
                            char secim_V_H = Char.ToUpper(Console.ReadKey().KeyChar);
                            Console.WriteLine();

                            if (secim_V_H == 'V')
                            {
                                Console.WriteLine("Menüye yönlendiriliyorsunuz.");
                                siparisAl(); // Menüyü yeniden göstermek için fonksiyon çağrısı
                            }
                            else if (secim_V_H == 'H')
                            {
                                devamEt = false;
                            }
                            else
                            {
                                Console.WriteLine("Geçerli tuşlama yapınız.");
                            }
                        }

                        Console.WriteLine();
                        // Siparişi gösteriyoruz
                        Console.WriteLine("\nSiparişler alındı:");
                        siparis1.SiparisGoster();

                        int hesapTutari = 0;
                        Console.WriteLine($"Hesabınız: {hesapTutari}");
                    }
                }
                else
                {
                    Console.WriteLine("Seçilen masa dolu veya geçersiz. Lütfen başka bir masa seçin.");
                }
            }
        }

    }


}
