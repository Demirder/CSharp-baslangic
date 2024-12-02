using System;
using System.Reflection;

namespace otomat
{
    internal class Program
    {

        TekraredenIslemler urunsecim = new TekraredenIslemler();

        // 4 ürün için diziler
        static string[] urunAdlari = { "Fanta", "Kola", "Çikolata", "Bisküvi", "Su" };
        static int[] urunFiyatlari = { 40, 40, 30, 20, 15 };



        static void Main(string[] args)
        {
            int urunSecimi;
            int fiyat = 0;
            int odeme = 0; // Ödemeyi burada başlatıyoruz
            int totalodeme = 0; //toplam yapılan harcamalar
            string[] orders = new string[1];




            static String baslangicSecim()
            {
                Console.WriteLine(" ");
                Console.WriteLine("Hoşgeldiniz.\n Ürün seçimi için a, Admin paneli için b' yi, çıkış için c'yi tuşlayınız.");
                String menuSecimi = Console.ReadLine();
                return menuSecimi;
            }

            String baslangic = baslangicSecim();

            while (true)
            {

                if (baslangic == "a")
                {
                    urunSecimi = TekraredenIslemler.YenidenSor(urunAdlari, urunFiyatlari);
                    Console.WriteLine(" ");

                    if (urunSecimi == -1)
                    {
                        continue;
                    }
                    Console.WriteLine("Ödeme yapmak için paranızı gösterilen yerden yatırınız.");
                    odeme = Convert.ToInt32(Console.ReadLine()); ; // İlk ödeme alındı
                    fiyat = urunFiyatlari[urunSecimi];
                    // Ödeme doğrulama ve durum kontrolü

                    if (odeme == fiyat)
                    {
                        Console.WriteLine("Afiyet olsun.");
                        baslangic = baslangicSecim();
                        Console.WriteLine(" ");

                    }

                    else if (odeme > fiyat)
                    {
                        int paraUstu = odeme - fiyat;
                        Console.WriteLine($"Afiyet olsun! Para üstünüz: {paraUstu} TL");
                        odeme = 0;
                        totalodeme += fiyat;

                        Array.Resize(ref orders, orders.Length + 1);
                        orders[orders.Length - 1] = urunAdlari[urunSecimi];
                        baslangic = baslangicSecim();

                    }
                    else
                    {
                        #region 1.yöntem
                        //Console.WriteLine("Yetersiz Bakiye.");
                        //Console.WriteLine("Para Ekle-1\nİade-2\nSeçiminiz:");
                        //int result = Convert.ToInt32(Console.ReadLine());
                        //if (result != 1)
                        //{
                        //    Console.WriteLine("Paranız:" + balance);
                        //    balance = 0;
                        //    Thread.Sleep(2000);
                        //    Console.Clear();
                        //    break;

                        //}
                        #endregion

                        #region 2.yöntem


                        double eksikPara = fiyat - odeme;
                        Console.WriteLine($"Ödeme yetersiz. Eksik para: {eksikPara} TL");
                        Console.WriteLine("Para eklemek için 1, para iadesi için 2 yi tuşlayınız.");
                        int secimIslem = int.Parse(Console.ReadLine()); // Kullanıcının işlemi seçmesi için

                        if (secimIslem == 1)
                        {

                            Console.WriteLine("Paranızı ekleyin.");

                            int eklenenPara = Convert.ToInt32(Console.ReadLine());
                            odeme += eklenenPara;

                            // Toplam ödemeyi ekrana yazdırıyoruz
                            Console.WriteLine($"Toplam ödemeniz: {odeme} TL");


                            if (odeme > fiyat)
                            {
                                int paraUstu = odeme - fiyat; // Fazla ödenen miktar
                                Console.WriteLine($"Fazla ödeme yaptınız! Para üstünüz: {paraUstu} TL");
                                Console.WriteLine("Afiyet olsun.");
                                baslangic = baslangicSecim();
                                break;
                            }
                            else if (odeme == fiyat)
                            {
                                // Eğer ödeme tam ise
                                Console.WriteLine("Tam ödeme yapıldı. Afiyet olsun.");
                                baslangic = baslangicSecim();
                            }
                            else
                            {
                                // Eğer ödeme hala eksikse
                                int eksikPara2 = fiyat - odeme;
                                Console.WriteLine($"Ödeme yetersiz. Eksik para: {eksikPara2} TL");
                            }
                            break;

                        }

                        else if (secimIslem == 2)
                        {

                            Console.WriteLine("Paranız iade ediliyor.");


                        }

                        #endregion

                    }

                }


                if (baslangic == "b")

                {

                    Console.WriteLine("Ürün Ekle-1\nÜrün Sil-2\nÜrün Güncelle-3\nÜrün Listele-4\nGün Sonu-5\nÇıkış 6\n Seçiminiz:");
                    int secim = Convert.ToInt32(Console.ReadLine());

                    if (secim < 1 || secim > 6)
                    {
                        Console.WriteLine("Hatalı Tuşlama!!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        continue;
                    }

                    else if (secim == 1) //ürün ekleme
                    {
                        Console.WriteLine(" ");
                        Array.Resize(ref urunAdlari, urunAdlari.Length + 1);
                        Console.WriteLine("Eklemek istediğiniz ürünün adı: ");
                        urunAdlari[urunAdlari.Length - 1] = Console.ReadLine();
                        Console.WriteLine(" ");


                        for (int i = 0; i < urunAdlari.Length; i++)
                        {
                            Console.WriteLine(urunAdlari[i]);
                        }

                        Console.WriteLine(" ");

                        Array.Resize(ref urunFiyatlari, urunFiyatlari.Length + 1);
                        Console.WriteLine("Eklemek istediğiniz ürünün fiyati: ");
                        urunFiyatlari[urunFiyatlari.Length - 1] = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(" ");

                        for (int i = 0; i < urunAdlari.Length && i < urunFiyatlari.Length; i++)
                        {
                            Console.WriteLine($"{urunAdlari[i]} - {urunFiyatlari[i]}");
                        }

                        Console.WriteLine(" ");
                    }

                    else if (secim == 2) //ürün sil
                    {

                        Console.WriteLine("Silmek istediğiniz ürünün numarası: ");
                        int numara = Convert.ToInt32(Console.ReadLine());
                        Array.Clear(urunAdlari, numara - 1, 1);
                        Array.Clear(urunFiyatlari, numara - 1, 1);


                        for (int i = 0; i < urunAdlari.Length; i++)
                        {
                            Console.Write(urunAdlari[i]);
                            Console.Write(urunFiyatlari[i]);
                            Console.WriteLine();
                        }
                        Console.WriteLine(" ");

                        

                    }

                    else if (secim == 3)  //ürün güncelleme
                    {


                        Console.WriteLine("İsim güncellemek için 1, fiyat güncellemek için 2 yazınız.");
                        int guncelleme2 = Convert.ToInt32(Console.ReadLine());
                        if (guncelleme2 == 1)
                        {
                            Console.WriteLine("Hangi ürünü güncellemek istiyorsunuz numarasını yazınız.");
                            for (int i = 0; i < urunAdlari.Length; i++)
                            {
                                Console.WriteLine(urunAdlari[i] + "\n");
                                
                            }


                            int num = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Ne ile değiştirilecek?");
                            String degisim = Console.ReadLine();
                            urunAdlari[num - 1] = degisim;

                        }
                        

                        

                    }

                    else if (secim == 4) //ürün listele
                    {

                        for (int i = 0; i < urunAdlari.Length; i++)
                        {
                            Console.WriteLine(urunAdlari[i]);
                        }

                        Console.WriteLine(" ");

                    }

                    else if (secim == 5) //gün sonu
                    {

                        Console.WriteLine($"\nGün Sonu Raporu: Toplam Harcamalar = {totalodeme} TL");
                        Console.WriteLine(" ");

                    }

                    else if (secim == 6) //çıkış
                    {

                        Console.WriteLine("Paranız iade ediliyor.");
                        baslangic = baslangicSecim();
                        Console.WriteLine(" ");

                    }


                }

                if (baslangic == "c")
                {

                    Console.WriteLine("Program sonlandırılıyor.");
                    break;

                }







            }
        }
    }
}