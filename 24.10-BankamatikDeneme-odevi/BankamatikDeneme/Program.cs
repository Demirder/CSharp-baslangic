using System;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata;

class Program
{
    static void Main()
    {
        decimal money = 25000; // Kullanıcının mevcut parası
        string pass = "ab18"; // Kullanıcının şifresi
        int sayac = 0; // Hatalı giriş sayacı

        Console.WriteLine("Hoşgeldiniz.");
        Console.WriteLine("Kartlı İşlem için 1\nKartsız İşlem için 2");
        string islemTuru = Console.ReadLine();

        switch (islemTuru)
        {
            case "1": // Kartlı işlem
                // Şifre kontrolü yapılır
                while (sayac < 3)
                {
                    Console.Write("Lütfen şifrenizi giriniz: ");
                    string girilenSifre = Console.ReadLine();

                    if (girilenSifre != pass)
                    {
                        sayac++;
                        Console.WriteLine($"Hatalı şifre! Kalan deneme hakkınız: {3 - sayac}");

                        if (sayac == 3)
                        {
                            Console.WriteLine("3 kez hatalı giriş yaptınız. Program sonlandırılıyor.\nKartınıza ATM tarafından el konulmuştur, kartınızı almak için lütfen bankaya başvurun.");
                            return; // Programdan çık
                        }
                    }
                    else
                    {
                        bool devam1 = true; // Ana menü döngüsü için kontrol

                        while (devam1)
                        {
                            Console.WriteLine("Para Çekmek için 1\r\nPara Yatırmak için 2\r\nPara Transferleri için 3\r\nEğitim Ödemeleri için 4\r\nÖdemeler için 5\r\nBilgi Güncelleme için 6");
                            string option = Console.ReadLine();

                            switch (option) // Ana menü içeriği
                            {
                                case "1": //Para Çekme işlemi
                                    Console.WriteLine("Para Çekme işlemi seçildi.");
                                    Console.WriteLine("Ne kadar para çekmek istiyorsunuz? Mevcut paranız: " + money);
                                    int cekilenMiktar;

                                    if (int.TryParse(Console.ReadLine(), out cekilenMiktar))
                                    {
                                        if (cekilenMiktar < 0)
                                        {
                                            Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                        }
                                        else if (cekilenMiktar <= money)
                                        {
                                            money -= cekilenMiktar;
                                            Console.WriteLine($"{cekilenMiktar} Lira para çekim işlemi gerçekleşti. Yeni Miktar: {money}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz miktar.");
                                    }
                                    break;

                                case "2"://Para Yatırma işlemi
                                    Console.WriteLine("Para Yatırma işlemi seçildi.");
                                    Console.WriteLine("Ne kadar para yatırmak istiyorsunuz?");
                                    int yatirilanMiktar;

                                    if (int.TryParse(Console.ReadLine(), out yatirilanMiktar) && yatirilanMiktar > 0)
                                    {
                                        money += yatirilanMiktar;
                                        Console.WriteLine($"{yatirilanMiktar} Lira yatırıldı. Yeni Miktar: {money}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz miktar.");
                                    }
                                    break;

                                case "3": //Para Transfer işlemi
                                    Console.WriteLine("Para Transfer işlemi seçildi.");
                                    Console.WriteLine("Yapacağınız işlemi seçiniz.\nKredi kartına 1\nKendi hesabınıza para yatırmak için 2\nBaşka hesaba para aktarmak için 3");
                                    string transferOption = Console.ReadLine();

                                    switch (transferOption)
                                    {
                                        case "1": //Para Transfer işleminde Kredi kartı Seçeneği
                                            Console.WriteLine("Kredi kartına para transferi seçildi.");
                                            Console.WriteLine("Lütfen 12 haneli kredi kartı numaranızı giriniz:");
                                            string kartNumarasi = Console.ReadLine(); //ilk kart numarasıyla işlem yapılması istendiği için kart numarası işlemini burada yaptırırz.

                                            // Kredi kartı numarasının uzunluğunu kontrol et
                                            if (kartNumarasi.Length >= 12 && kartNumarasi.All(char.IsDigit))
                                            {
                                                Console.WriteLine("Ne kadar para transfer etmek istiyorsunuz?");
                                                int krediKartinaMiktar; //bu kısmın buraya yazılmasının sebebi kredi kartına işlemlerin bu kısmında havale gerçekleştirilecek olmasıdır.

                                                if (int.TryParse(Console.ReadLine(), out krediKartinaMiktar) && krediKartinaMiktar > 0)
                                                {
                                                    // Burada kredi kartına para transferi ile ilgili işlemler yapılabilir.
                                                    Console.WriteLine($"{krediKartinaMiktar} Lira kredi kartına transfer edildi.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Geçersiz miktar.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Geçersiz kredi kartı numarası. Lütfen 12 haneli bir kart numarası giriniz.");
                                            }
                                            break;

                                        case "2": //Para Transfer işleminde Kendi Hesabına Para Yatırma Seçeneği
                                            Console.WriteLine("Kendi hesabınıza para yatırma işlemi seçildi.");
                                            Console.WriteLine("Ne kadar para yatırmak istiyorsunuz?");
                                            int kendiHesabınaMiktar;

                                            if (int.TryParse(Console.ReadLine(), out kendiHesabınaMiktar) && kendiHesabınaMiktar > 0)
                                            {
                                                // Burada kendi hesabınıza para yatırma ile ilgili işlemler yapılabilir.
                                                money += kendiHesabınaMiktar; // Örneğin, mevcut bakiyeye ekleyelim
                                                Console.WriteLine($"{kendiHesabınaMiktar} Lira kendi hesabınıza yatırıldı. Yeni bakiye: {money}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Geçersiz miktar.");
                                            }
                                            break;

                                        case "3": //Para Transfer işleminde Başkasının Hesabına Para Yatırma Seçeneği

                                            Console.WriteLine("Başka hesaba para trasferi seçeneği seçildi.");
                                            Console.WriteLine("EFT ile para göndermek için 1\nHavale ile para göndermek için 2.");
                                            string transferOptions = Console.ReadLine();

                                            switch (transferOptions)
                                            {

                                                case "1": //Para Transfer işleminde Başkasının Hesabına EFT ile Para Yatırma Seçeneği
                                                    Console.WriteLine("EFT ile para gönderme seçeneği seçildi.");
                                                    Console.WriteLine("Lütfen 12 haneli TR ile başlayan hesap numaranızı giriniz:");
                                                    string eftHesapNumarasi = Console.ReadLine();

                                                    // EFT hesap numarasının doğrulaması
                                                    if (eftHesapNumarasi.Length == 14 && eftHesapNumarasi.Substring(0, 2).ToUpper() == "TR" && eftHesapNumarasi.Substring(2).All(char.IsDigit))
                                                    {
                                                        Console.WriteLine("Ne kadar para göndermek istiyorsunuz?");
                                                        int eftMiktari;

                                                        if (int.TryParse(Console.ReadLine(), out eftMiktari) && eftMiktari > 0)
                                                        {
                                                            Console.WriteLine($"{eftMiktari} Lira EFT ile gönderildi.");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Geçersiz miktar.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Geçersiz EFT hesap numarası. Lütfen TR ile başlayan 12 haneli bir hesap numarası giriniz.");
                                                    }
                                                    break;

                                                case "2": //Para Transfer işleminde Başkasının Hesabına Havale ile Para Yatırma Seçeneği
                                                    Console.WriteLine("Havale ile para gönderme seçeneği seçildi.");
                                                    string havaleHesapNumarasi = Console.ReadLine();

                                                    // Havale hesap numarasının doğrulaması
                                                    if (havaleHesapNumarasi.Length == 11 && havaleHesapNumarasi.All(char.IsDigit))
                                                    {
                                                        Console.WriteLine("Ne kadar para göndermek istiyorsunuz?");
                                                        int havaleMiktari;

                                                        if (int.TryParse(Console.ReadLine(), out havaleMiktari) && havaleMiktari > 0)
                                                        {
                                                            Console.WriteLine($"{havaleMiktari} Lira havale ile gönderildi.");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Geçersiz miktar.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Geçersiz havale hesap numarası. Lütfen 11 haneli bir hesap numarası giriniz.");
                                                    }
                                                    break;


                                                default:
                                                    Console.WriteLine("Geçersiz işlem. Lütfen 1, 2 veya 3'ü seçiniz.");
                                                    break;
                                            }
                                            break;
                                    }
                                    break;

                                case "4":  //Eğitim Ödemesi işlemi
                                    Console.WriteLine("Eğitim Ödemesi işlemi seçildi.");
                                    Console.WriteLine("Şu an işleminizi gerçekleştiremiyoruz.\nLütfen daha sonra tekrar deneyin ya da yakınlarda başka atm varsa oradan işleminizi gerçekleştirebilirsiniz.");
                                    break;

                                case "5": // Ödeme işlemleri
                                    Console.WriteLine("Ödeme işlemi seçildi.");
                                    Console.WriteLine("Yapacağınız işlemi seçiniz.\nElektrik Faturası Ödemesi için 1\nTelefon Faturası Ödemesi için 2\nİnternet Faturası Ödemesi için 3\nSu Faturası Ödemesi için 4\nOGS Ödemeleri için 5");
                                    string paymentoption = Console.ReadLine();

                                    switch (paymentoption)
                                    {
                                        case "1":// Ödeme işlemlerinde Elektrik Faturası Ödeme İşlemi
                                            Console.WriteLine("Elektrik Faturası Ödeme işlemi seçildi.");
                                            Console.WriteLine("Fatura tutarı giriniz.");
                                            int faturaTutari;

                                            if (int.TryParse(Console.ReadLine(), out faturaTutari))
                                            {
                                                if (faturaTutari < 0)
                                                {
                                                    Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                                }
                                                else if (faturaTutari <= money)
                                                {
                                                    money -= faturaTutari;
                                                    Console.WriteLine($"{faturaTutari} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Geçersiz miktar.");
                                            }
                                            break;

                                        case "2": // Ödeme işlemlerinde Telefon Faturası Ödeme İşlemi
                                            Console.WriteLine("Telefon Faturası Ödeme işlemi seçildi.");
                                            Console.WriteLine("Fatura tutarı giriniz.");
                                            int TelefonfaturaTutari;

                                            if (int.TryParse(Console.ReadLine(), out TelefonfaturaTutari))
                                            {
                                                if (TelefonfaturaTutari < 0)
                                                {
                                                    Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                                }
                                                else if (TelefonfaturaTutari <= money)
                                                {
                                                    money -= TelefonfaturaTutari;
                                                    Console.WriteLine($"{TelefonfaturaTutari} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Geçersiz miktar.");
                                            }
                                            break;

                                        case "3": // Ödeme işlemlerinde İnternet Faturası Ödeme İşlemi
                                            Console.WriteLine("İnternet Faturası Ödeme işlemi seçildi.");
                                            Console.WriteLine("Fatura tutarı giriniz.");
                                            int InternetfaturaOdemesi;

                                            if (int.TryParse(Console.ReadLine(), out InternetfaturaOdemesi))
                                            {
                                                if (InternetfaturaOdemesi < 0)
                                                {
                                                    Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                                }
                                                else if (InternetfaturaOdemesi <= money)
                                                {
                                                    money -= InternetfaturaOdemesi;
                                                    Console.WriteLine($"{InternetfaturaOdemesi} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Geçersiz miktar.");
                                            }
                                            break;

                                        case "4": // Ödeme işlemlerinde Su Faturası Ödeme İşlemi
                                            Console.WriteLine("Su Faturası Ödeme işlemi seçildi.");
                                            Console.WriteLine("Fatura tutarı giriniz.");
                                            int SufaturaOdemesi;

                                            if (int.TryParse(Console.ReadLine(), out SufaturaOdemesi))
                                            {
                                                if (SufaturaOdemesi < 0)
                                                {
                                                    Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                                }
                                                else if (SufaturaOdemesi <= money)
                                                {
                                                    money -= SufaturaOdemesi;
                                                    Console.WriteLine($"{SufaturaOdemesi} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Geçersiz miktar.");
                                            }
                                            break;

                                        case "5": // Ödeme işlemlerinde OGS Ödeme İşlemi
                                            Console.WriteLine("OGS Ödemeleri işlemi seçildi.");
                                            Console.WriteLine("Fatura tutarı giriniz.");
                                            int OGSodemeleri;

                                            if (int.TryParse(Console.ReadLine(), out OGSodemeleri))
                                            {
                                                if (OGSodemeleri < 0)
                                                {
                                                    Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                                }
                                                else if (OGSodemeleri <= money)
                                                {
                                                    money -= OGSodemeleri;
                                                    Console.WriteLine($"{OGSodemeleri} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Geçersiz miktar.");
                                            }
                                            break;
                                    }

                                    break;

                                case "6": // Bilgi Güncelleme İşlemi
                                    Console.WriteLine("Bilgi Güncelleme işlemi seçildi.");
                                    Console.WriteLine("Yeni şifrenizi giriniz.");
                                    string yeniSifre = Console.ReadLine();
                                    Console.WriteLine("Yeni şifrenizi tekrar giriniz.");
                                    string yeniSifre2 = Console.ReadLine();

                                   if (yeniSifre != yeniSifre2)
                                     {
                                          Console.WriteLine("Yeni şifreler uyuşmuyor! Lütfen şifreyi doğru giriniz.");
                                     }

                                  // 4 haneli şifre kontrolü
                                    else if (yeniSifre.Length == 4 && yeniSifre.All(char.IsDigit))
                                    {
                                        Console.WriteLine("Şifre başarıyla güncellendi.");
                                        // Burada şifreyi güncelleme işlemi yapılabilir.
                                        // Örneğin: pass = yeniSifre;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz işlem! Lütfen 4 haneli rakamlardan oluşan bir şifre giriniz.");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Geçersiz işlem.");
                                    break;
                            }

                            // Ana menüye dönmek veya çıkmak için seçenekler
                            Console.WriteLine("Ana menüye dönmek için 9'a\nÇıkmak için 0'a basın.");
                            string secim = Console.ReadLine();

                            if (secim == "0")
                            {
                                devam1 = false; // Programdan çık
                            }
                            else if (secim == "9")
                            {
                                Console.WriteLine("Ana menüye dönülüyor...");
                                // Ana menü döngüsü devam etmekte.
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz seçim, ana menüye dönülüyor...");
                            }
                        }
                        break; // Şifre doğru girildiği için dıştaki while döngüsünden çıkıyoruz.
                    }
                }
                break;

            case "2": // Kartsız işlem
                Console.WriteLine("Kartsız işlem seçildi.");

                bool devam2 = true; // Ana menü döngüsü için kontrol

                while (devam2)
                {
                    Console.WriteLine("CepBank Para Çekmek için 1\r\nPara Yatırmak için 2\r\nKredi Kartı Ödemesi için 3\r\nEğitim Ödemeleri için 4\r\nÖdemeler için 5");
                    string options = Console.ReadLine();

                    switch (options)
                    {
                        case "1": // Kartsız işlemlerde CepBank Para Çekme İşlemi
                            Console.WriteLine("CepBank Para Çekme İşlemini Seçtiniz.");
                            Console.WriteLine("Lütfen 11 haneli TC kimlik numaranızı ya da cep telefonu numaranızı giriniz:");
                            string kimlikVeyaTelefon = Console.ReadLine();

                            if (kimlikVeyaTelefon.Length != 11 || !long.TryParse(kimlikVeyaTelefon, out _))
                            {
                                Console.WriteLine("Geçersiz kimlik veya telefon numarası girdiniz.");
                                break;
                            }

                            Console.WriteLine("Çekmek istediğiniz tutarı giriniz:");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal cekilenMiktar) || cekilenMiktar <= 0)
                            {
                                Console.WriteLine("Geçersiz bir tutar girdiniz.");
                                break;
                            }

                            // Maksimum çekim miktarı kontrolü
                            if (cekilenMiktar > 1000)
                            {
                                Console.WriteLine("Sadece 1000 TL veya daha az tutarda çekim yapabilirsiniz.");
                            }
                            else if (cekilenMiktar > money)
                            {
                                Console.WriteLine("Yetersiz bakiye! Mevcut bakiye: " + money + " TL");
                            }
                            else
                            {
                                money -= cekilenMiktar;
                                Console.WriteLine("İşlem başarılı! Çekilen tutar: " + cekilenMiktar + " TL");
                                Console.WriteLine("Kalan bakiye: " + money + " TL");
                            }
                            break;

                        case "2": // Kartsız işlemlerde Kredi Kartı Borç Ödeme İşlemi
                            Console.WriteLine("Kredi Kartı Ödemesi İşlemini Seçtiniz.");
                            Console.WriteLine("Nakit Ödeme için 1\nHesaptan Ödeme için 2 yi seçiniz.");
                            string kartsizparaOdeme = Console.ReadLine();

                            switch (kartsizparaOdeme)
                                {
                                case "1": // Kartsız işlemlerde Kredi Kartı Borç Ödeme İşleminde Nakit Ödeme Seçeneği
                                    Console.WriteLine("Kredi kartına nakit ödeme yapmak için 12 haneli kart numarasını giriniz:");
                                    string kartNumarasi = Console.ReadLine();

                                    // Kart numarasının 12 haneli olup olmadığını kontrol et
                                    if (kartNumarasi.Length != 12 || !long.TryParse(kartNumarasi, out _))
                                    {
                                        Console.WriteLine("Geçersiz kart numarası girdiniz.");
                                        break;
                                    }

                                    Console.WriteLine("Lütfen 11 haneli TC kimlik numaranızı giriniz:");
                                    string tcKimlikNumarasi = Console.ReadLine();

                                    // TC kimlik numarasının 11 haneli olup olmadığını kontrol et
                                    if (tcKimlikNumarasi.Length != 11 || !long.TryParse(tcKimlikNumarasi, out _))
                                    {
                                        Console.WriteLine("Geçersiz TC kimlik numarası girdiniz.");
                                        break;
                                    }

                                    Console.WriteLine("Ödeme yapmak istediğiniz tutarı giriniz:");
                                    if (!decimal.TryParse(Console.ReadLine(), out decimal odemeTutari) || odemeTutari <= 0)
                                    {
                                        Console.WriteLine("Geçersiz bir tutar girdiniz.");
                                        break;
                                    }

                                    // Ödeme işlemi başarılı mesajı
                                    Console.WriteLine("İşlem başarılı! Kredi kartınıza " + odemeTutari + " TL ödeme yapılmıştır.");
                                    break;

                                case "2": // Kartsız işlemlerde Kredi Kartı Borç Ödeme İşleminde Hesaptan Ödeme Seçeneği
                                    Console.WriteLine("Hesaptan hesaba para atmak için 12 haneli kart numarasını ve 16 haneli hesap numarasını giriniz:");
                                    Console.WriteLine("Lütfen 12 haneli kart numaranızı giriniz:");
                                    string kartNumarasi2 = Console.ReadLine();

                                    // Kart numarasının 12 haneli olup olmadığını kontrol et
                                    if (kartNumarasi2.Length != 12 || !long.TryParse(kartNumarasi2, out _))
                                    {
                                        Console.WriteLine("Geçersiz kart numarası girdiniz.");
                                        break;
                                    }

                                    // 16 haneli hesap numarasını al
                                    Console.WriteLine("Lütfen 11 haneli hedef hesap numarasını giriniz:");
                                    string hesapNumarasi = Console.ReadLine();

                                    // Hesap numarasının 11 haneli olup olmadığını kontrol et
                                    if (hesapNumarasi.Length != 11 || !long.TryParse(hesapNumarasi, out _))
                                    {
                                        Console.WriteLine("Geçersiz hesap numarası girdiniz.");
                                        break;
                                    }

                                    // Gönderilecek miktarı al
                                    Console.WriteLine("Göndermek istediğiniz tutarı giriniz:");
                                    if (!decimal.TryParse(Console.ReadLine(), out decimal gonderilenMiktar) || gonderilenMiktar <= 0)
                                    {
                                        Console.WriteLine("Geçersiz bir tutar girdiniz.");
                                        break;
                                    }

                                    // Bakiyeyi kontrol et
                                    if (gonderilenMiktar > money)
                                    {
                                        Console.WriteLine("Yetersiz bakiye! Mevcut bakiye: " + money + " TL");
                                    }
                                    else
                                    {
                                        money -= gonderilenMiktar;
                                        Console.WriteLine("İşlem başarılı! Gönderilen tutar: " + gonderilenMiktar + " TL");
                                        Console.WriteLine("Kalan bakiye: " + money + " TL");
                                    }
                                    
                                    break;

                            }
                            break;

                        case "3": //Para Yatırma İşlemi
                            Console.WriteLine("Para yatırma işlemini seçtiniz.");
                            Console.WriteLine("Başka hesaba EFT için 1\nBaşka hesaba havale için 2 yi seçiniz.");
                            string kartsizparaYatirma = Console.ReadLine();

                            switch (kartsizparaYatirma)
                            {
                                case "1": //Para Yatırma İşleminde EFT ile Para Yatırma Seçeneği
                                    Console.WriteLine("EFT ile para yatırma seçeneği seçildi.");
                                    Console.WriteLine("Lütfen 12 haneli TR ile başlayan hesap numaranızı giriniz:");
                                    string eftHesapNumarasi = Console.ReadLine();

                                    // EFT hesap numarasının doğrulaması
                                    if (eftHesapNumarasi.Length == 14 && eftHesapNumarasi.Substring(0, 2).ToUpper() == "TR" && eftHesapNumarasi.Substring(2).All(char.IsDigit))
                                    {
                                        Console.WriteLine("Ne kadar para göndermek istiyorsunuz?");
                                        int eftMiktari;

                                        if (int.TryParse(Console.ReadLine(), out eftMiktari) && eftMiktari > 0)
                                        {
                                            Console.WriteLine($"{eftMiktari} Lira EFT ile gönderildi.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Geçersiz miktar.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz EFT hesap numarası. Lütfen TR ile başlayan 12 haneli bir hesap numarası giriniz.");
                                    }
                                    break;

                                case "2": //Para Yatırma İşleminde Havale ile Para Yatırma Seçeneği
                                    Console.WriteLine("Havale ile para yatırma seçeneği seçildi.");
                                    string havaleHesapNumarasi = Console.ReadLine();

                                    // Havale hesap numarasının doğrulaması
                                    if (havaleHesapNumarasi.Length == 11 && havaleHesapNumarasi.All(char.IsDigit))
                                    {
                                        Console.WriteLine("Ne kadar para göndermek istiyorsunuz?");
                                        int havaleMiktari;

                                        if (int.TryParse(Console.ReadLine(), out havaleMiktari) && havaleMiktari > 0)
                                        {
                                            Console.WriteLine($"{havaleMiktari} Lira havale ile gönderildi.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Geçersiz miktar.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz havale hesap numarası. Lütfen 11 haneli bir hesap numarası giriniz.");
                                    }
                                    break;
                                
                            }
                            break;
                            

                        case "4": //Eğitim Ödemesi İşlemi
                            Console.WriteLine("Eğitim Ödemesi İşlemini Seçtiniz.");
                            Console.WriteLine("Şu an işleminizi gerçekleştiremiyoruz.\nLütfen daha sonra tekrar deneyin ya da yakınlarda başka atm varsa oradan işleminizi gerçekleştirebilirsiniz.");
                            break;
                             
                        case "5": //Ödeme İşlemleri
                            Console.WriteLine("Ödeme İşlemi Seçtiniz.");
                            Console.WriteLine("Yapacağınız işlemi seçiniz.\nElektrik Faturası Ödemesi için 1\nTelefon Faturası Ödemesi için 2\nİnternet Faturası Ödemesi için 3\nSu Faturası Ödemesi için 4\nOGS Ödemeleri için 5");
                            string Cardlesspaymentoption = Console.ReadLine();

                            switch (Cardlesspaymentoption)
                            {
                                case "1": //Ödeme İşlemlerinde Elektrik Faturası Ödeme Seçeneği
                                    Console.WriteLine("Elektrik Faturası Ödeme işlemi seçildi.");
                                    Console.WriteLine("Fatura tutarı giriniz.");
                                    int faturaTutari;

                                    if (int.TryParse(Console.ReadLine(), out faturaTutari))
                                    {
                                        if (faturaTutari < 0)
                                        {
                                            Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                        }
                                        else if (faturaTutari <= money)
                                        {
                                            money -= faturaTutari;
                                            Console.WriteLine($"{faturaTutari} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz miktar.");
                                    }
                                    break;

                                case "2": //Ödeme İşlemlerinde Telefon Faturası Ödeme Seçeneği
                                    Console.WriteLine("Telefon Faturası Ödeme işlemi seçildi.");
                                    Console.WriteLine("Fatura tutarı giriniz.");
                                    int TelefonfaturaTutari;

                                    if (int.TryParse(Console.ReadLine(), out TelefonfaturaTutari))
                                    {
                                        if (TelefonfaturaTutari < 0)
                                        {
                                            Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                        }
                                        else if (TelefonfaturaTutari <= money)
                                        {
                                            money -= TelefonfaturaTutari;
                                            Console.WriteLine($"{TelefonfaturaTutari} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz miktar.");
                                    }
                                    break;

                                case "3": //Ödeme İşlemlerinde İnternet Faturası Ödeme Seçeneği
                                    Console.WriteLine("İnternet Faturası Ödeme işlemi seçildi.");
                                    Console.WriteLine("Fatura tutarı giriniz.");
                                    int InternetfaturaOdemesi;

                                    if (int.TryParse(Console.ReadLine(), out InternetfaturaOdemesi))
                                    {
                                        if (InternetfaturaOdemesi < 0)
                                        {
                                            Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                        }
                                        else if (InternetfaturaOdemesi <= money)
                                        {
                                            money -= InternetfaturaOdemesi;
                                            Console.WriteLine($"{InternetfaturaOdemesi} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz miktar.");
                                    }
                                    break;

                                case "4": //Ödeme İşlemlerinde Su Faturası Ödeme Seçeneği
                                    Console.WriteLine("Su Faturası Ödeme işlemi seçildi.");
                                    Console.WriteLine("Fatura tutarı giriniz.");
                                    int SufaturaOdemesi;

                                    if (int.TryParse(Console.ReadLine(), out SufaturaOdemesi))
                                    {
                                        if (SufaturaOdemesi < 0)
                                        {
                                            Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                        }
                                        else if (SufaturaOdemesi <= money)
                                        {
                                            money -= SufaturaOdemesi;
                                            Console.WriteLine($"{SufaturaOdemesi} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz miktar.");
                                    }
                                    break;

                                case "5": //Ödeme İşlemlerinde OGS Ödemeleri Seçeneği
                                    Console.WriteLine("OGS Ödemeleri işlemi seçildi.");
                                    Console.WriteLine("Fatura tutarı giriniz.");
                                    int OGSodemeleri;

                                    if (int.TryParse(Console.ReadLine(), out OGSodemeleri))
                                    {
                                        if (OGSodemeleri < 0)
                                        {
                                            Console.WriteLine("İşlem gerçekleştirilemez. Lütfen geçerli bir tutar giriniz.");
                                        }
                                        else if (OGSodemeleri <= money)
                                        {
                                            money -= OGSodemeleri;
                                            Console.WriteLine($"{OGSodemeleri} Ödeme işlemi gerçekleştirilmiştir. Güncel bakiyeniz: {money}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Yetersiz bakiye, geçerli bir tutar giriniz.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz miktar.");
                                    }
                                    break;
                            }
                            break;

                        default:
                            Console.WriteLine("Geçersiz seçenek! Lütfen 1, 2, 3, 4 veya 5'i tuşlayınız.");
                            break; // default case'den çık
                    }

                    // Ana menüye dönmek veya çıkmak için seçenekler
                    Console.WriteLine("Ana menüye dönmek için 9'a\nÇıkmak için 0'a basın.");
                    string secim = Console.ReadLine();

                    if (secim == "0")
                    {
                        devam2 = false; // Programdan çık
                    }
                    else if (secim == "9")
                    {
                        Console.WriteLine("Ana menüye dönülüyor...");
                        // Ana menü döngüsü devam eder
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim, ana menüye dönülüyor...");
                    }
                }
                break; // Kartsız işlem durumunun sonu
        }
    }        
}



