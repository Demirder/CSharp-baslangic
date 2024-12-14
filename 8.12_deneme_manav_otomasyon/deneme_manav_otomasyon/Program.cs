using System.Collections.Generic;
using ToptanciUrunSistemi;

namespace deneme_manav_otomasyon
{
    internal class Program
    {

        static string[] seciniz = { "Manav", "Müşteri" };

        static void Main(string[] args)
        {

            Manav manavim = new Manav();
            halSecim hal = new halSecim();


            // Kullanıcı seçim döngüsü
            int secim;
            int musteriBakiye = 0;
            int manavBakiye = 0;

            while (true)
            {

                Console.WriteLine("Sisteme kim olarak girdiğinizi seçiniz.");

                for (int i = 0; i < seciniz.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {seciniz[i]}");
                }

                Console.Write("Seçiminiz (1-2): ");
                string giris = Console.ReadLine();
                Console.WriteLine(" ");

                // Geçerli bir sayı kontrolü
                if (int.TryParse(giris, out secim) && secim >= 1 && secim <= seciniz.Length)
                {
                    break; // Geçerli bir seçim yapıldığında döngüden çık

                }
                else
                {
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                }
            }

            // Seçim sonucu
            Console.WriteLine($"Seçiminiz: {seciniz[secim - 1]}");
            Console.WriteLine(" ");

            if (secim == 1)
            {

                while (true)
                {

                    hal.haleHosgeldiniz();
                    string Urunsecim = Console.ReadLine().ToUpper();


                    if (Urunsecim == "M")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Meyve kategorisine geldiniz. Ürünler Listeleniyor...");
                        Toptanci toptanci2 = new Toptanci(); // Toptanci class ını toptanci2 değişkenini kullanarak çağırıyorum

                        foreach (var urun in toptanci2.Urunler)
                        {
                            if (urun.Kategori == "Meyve")
                            {
                                Console.WriteLine($"{urun.Ad} - {urun.Kilogram} - {urun.Fiyat} TL");
                            }
                        }

                        meyveIslem();
                    }



                    else if (Urunsecim == "S")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Sebze kategorisine geldiniz. Ürünler Listeleniyor...");
                        Toptanci toptanci2 = new Toptanci(); // Toptanci class ını toptanci2 değişkenini kullanarak çağırıyorum

                        foreach (var urun in toptanci2.Urunler)
                        {
                            if (urun.Kategori == "Sebze")
                            {
                                Console.WriteLine($"{urun.Ad} - {urun.Kilogram} -{urun.Fiyat} TL");
                            }
                        }

                        sebzeIslem();

                    }


                    else
                    {

                        while (true)
                        {

                            Console.WriteLine("Başka bir isteğiniz var mı? Varsa evet için E, yoksa hayır için H yi, aldığınız ürünleri listelemek için L yi giriniz.");
                            string neyapcan = Console.ReadLine().ToUpper();

                            if (neyapcan == "H")
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Bizi tercih ettiğiniz için teşekkür ederiz, iyi günler.");
                                break;

                            }

                            else if (neyapcan == "E")
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");

                                hal.haleHosgeldiniz();

                                if (Urunsecim == "M")
                                {

                                    Console.WriteLine("Meyve kategorisine geldiniz. Ürünler Listeleniyor...");
                                    Toptanci toptanci2 = new Toptanci(); // Toptanci class ını toptanci2 değişkenini kullanarak çağırıyorum

                                    foreach (var urun in toptanci2.Urunler)
                                    {
                                        if (urun.Kategori == "Meyve")
                                        {
                                            Console.WriteLine($"{urun.Ad} - {urun.Kilogram} Kg - {urun.Fiyat} TL");
                                        }
                                    }

                                    meyveIslem();
                                }


                                else if (Urunsecim == "S")
                                {

                                    Console.WriteLine("Sebze kategorisine geldiniz. Ürünler Listeleniyor...");
                                    Toptanci toptanci2 = new Toptanci(); // Toptanci class ını toptanci2 değişkenini kullanarak çağırıyorum

                                    foreach (var urun in toptanci2.Urunler)
                                    {
                                        if (urun.Kategori == "Sebze")
                                        {
                                            Console.WriteLine($"{urun.Ad} - {urun.Kilogram} Kg - {urun.Fiyat} TL");
                                        }
                                    }

                                    sebzeIslem();

                                }

                                else if (Urunsecim == "L")
                                {

                                    Console.WriteLine("Aldığınız ürünler Listeleniyor...");

                                    // Burada manavim2 kullanmalısınız, çünkü manavim2'yi yeni oluşturduk
                                    if (manavim.AlinanUrunler.Count == 0)
                                    {
                                        Console.WriteLine("Henüz aldığınız ürün yok.");
                                    }
                                    else
                                    {
                                        for (int i = 0; i < manavim.AlinanUrunler.Count; i++)
                                        {
                                            var urun = manavim.AlinanUrunler[i];
                                            Console.WriteLine($"{urun.Ad} - {urun.Kilogram} Kg - {urun.Fiyat} TL");
                                        }
                                    }

                                    
                                }

                                else
                                {

                                    Console.WriteLine("Yanlış tuşlama yaptınız, lütfen tekrar deneyiniz.");

                                }
                            }
                        }
                    }

                }

            }




        }


        static void meyveIslem()
        {
            Toptanci toptanci = new Toptanci(); // Toptancı sınıfını başlatıyoruz
            Manav manavim = new Manav();
            Console.WriteLine(" ");
            Console.WriteLine("Almak istediğiniz meyveyi seçiniz.");
            Console.WriteLine(" ");

            // Urunler listesinde yer alan meyveleri seçmek için filtreleme yapıyoruz
            var meyveler = toptanci.Urunler.Where(u => u.Kategori == "Meyve").ToList(); // Kategorisi "Meyve" olanları alıyoruz


            int Meyvesecim = Convert.ToInt32(Console.ReadLine()) - 1; // Kullanıcıdan ürün seçimi al
            if (Meyvesecim < 0 || Meyvesecim >= meyveler.Count)
            {
                Console.WriteLine("Geçersiz seçim. Lütfen geçerli bir ürün numarası girin.");
            }
            else
            {
                var secilenUrun = meyveler[Meyvesecim];
                Console.WriteLine($"Seçtiğiniz ürün: {secilenUrun.Ad}, Fiyat: {secilenUrun.Fiyat} TL");

                while (true)
                {

                    Console.WriteLine("Kaç kilogram almak istersiniz?");
                    int kilogramSecim = 0;
                    string input = Console.ReadLine(); // Kullanıcıdan input al

                    bool validInput = int.TryParse(input, out kilogramSecim);

                    if (!validInput)
                    {
                        Console.WriteLine("Lütfen geçerli bir sayı girin.");
                    }
                    else
                    {
                        // Kullanıcı, toptancıdaki ürünün stok miktarını aşamaz
                        if (kilogramSecim > secilenUrun.Kilogram)
                        {
                            Console.WriteLine("Üzgünüz, stokta yeterli miktarda ürün yok.");
                        }
                        else
                        {
                            // Toplam fiyat hesaplama
                            int toplamFiyat = secilenUrun.Fiyat * kilogramSecim;
                            Console.WriteLine($"Toplam Tutar: {toplamFiyat} TL");

                            // Ürünü manavın listesine ekliyoruz
                            manavim.UrunEkle(secilenUrun);

                            // Yalnızca bu işlemde toptancıdaki ürünün kilogram miktarını güncelliyoruz
                            secilenUrun.Kilogram -= kilogramSecim;
                            Console.WriteLine($"Toptancıdaki {secilenUrun.Ad} ürününden {kilogramSecim} kilogram alındı.");
                            Console.WriteLine($"Kalan stok: {secilenUrun.Kilogram} kilogram.");
                            break;
                        }
                    }
                }
            }

        }

        static void sebzeIslem()
        {
            while (true)
            {
                Toptanci toptanci = new Toptanci(); // Toptancı sınıfını başlatıyoruz
                Manav manavim = new Manav();
                Console.WriteLine(" ");
                Console.WriteLine("Almak istediğiniz sebzeyi seçiniz.");
                Console.WriteLine(" ");

                // Urunler listesinde yer alan sebzeleri seçmek için filtreleme yapıyoruz
                var sebzeler = toptanci.Urunler.Where(u => u.Kategori == "Sebze").ToList(); // Kategorisi "Sebze" olanları alıyoruz

                int Sebzesecim = Convert.ToInt32(Console.ReadLine()) - 1; // Kullanıcıdan ürün seçimi al
                if (Sebzesecim < 0 || Sebzesecim >= sebzeler.Count)
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen geçerli bir ürün numarası girin.");
                }
                else
                {
                    var secilenUrun = sebzeler[Sebzesecim];
                    Console.WriteLine($"Seçtiğiniz ürün: {secilenUrun.Ad}, Fiyat: {secilenUrun.Fiyat} TL");

                    while (true)
                    {

                        Console.WriteLine("Kaç kilogram almak istersiniz?");
                        int kilogramSecim = 0;
                        string input = Console.ReadLine(); // Kullanıcıdan input al

                        bool validInput = int.TryParse(input, out kilogramSecim);

                        if (!validInput)
                        {
                            Console.WriteLine("Lütfen geçerli bir sayı girin.");
                        }
                        else
                        {
                            // Kullanıcı, toptancıdaki ürünün stok miktarını aşamaz
                            if (kilogramSecim > secilenUrun.Kilogram)
                            {
                                Console.WriteLine("Üzgünüz, stokta yeterli miktarda ürün yok.");
                            }
                            else
                            {
                                // Toplam fiyat hesaplama
                                int toplamFiyat = secilenUrun.Fiyat * kilogramSecim;
                                Console.WriteLine($"Toplam Tutar: {toplamFiyat} TL");

                                // Ürünü manavın listesine ekliyoruz
                                manavim.UrunEkle(secilenUrun);

                                // Yalnızca bu işlemde toptancıdaki ürünün kilogram miktarını güncelliyoruz
                                secilenUrun.Kilogram -= kilogramSecim;
                                Console.WriteLine($"Toptancıdaki {secilenUrun.Ad} ürününden {kilogramSecim} kilogram alındı.");
                                Console.WriteLine($"Kalan stok: {secilenUrun.Kilogram} kilogram.");
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}







