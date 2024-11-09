namespace _3._11_odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             kullanıcıdan alınan cinsiyet bilgisine göre 
            -> erkek ise
            yaşı 60 ve üstü ise maaşın 10 katı kadar ikramiye alarak emekli edilecek, yaş 60 ın altında ise çalıştığı gün sayısına göre eğer 6000 ve üstü ise maaşının 11 katı kadar ikramiye alarak emekli edilecek, 6000 altında ise emekli edilmeyecek bilgisi kullanıcıya gösterilecek.
            ->kadın ise 
            yaşı 58 ve üstü ise maaşının 10 katı kadar ikramiye alarak emekli edilecek, yaş 58 in altında ise çalıştığı gün sayısına göre eğer 3600 ve üstü ise maaşının 11 katı kadar ikramiye alarak emekli edilecek, 3600 altında ise emekli edilmeyecek bilgisi kullanıcıya gösterilecek
            ->cinsiyet bilgisi switch-case ile sorgulanacak.
             */

            
            string cinsiyetTuru = null;
            int hak = 3; //kullanıcıya verilen yanlış girme sayısı.

            while (hak>0)
            {
                Console.WriteLine("Cinsiyetiniz Nedir?");
                Console.WriteLine("1-Erkek\n2-Kadın");
                Console.WriteLine("Seçiminiz?");
                cinsiyetTuru = Console.ReadLine();



                if (cinsiyetTuru == "1" || cinsiyetTuru == "2") // İşlemlerden önce geçersiz giriş kontrolü yapılır. veya ifadesi kullanılır çünkü ikisinden biri doğru seçim olmalı.
                {
                    Console.WriteLine("Doğru tuşlama yaptınız..");
                    break; // Döngüden çık.
                }

                else
                {

                    hak--;
                    Console.WriteLine($"Geçersiz cinsiyet girişi. Lütfen '1' veya '2' yi seçiniz. Kalan yanlış girme hakkınız: {hak}");

                }

            }

            if (hak == 0)
            {
                Console.WriteLine("Tüm haklarınızı kullandınız. Programdan çıkılıyor.");
                return;
            }


            Console.WriteLine("Yaşınızı Giriniz.");
            int yas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Çalıştığınız Gün Sayısını Giriniz.");
            int calisilanGun = Convert.ToInt32(Console.ReadLine());


            int maas = 17000; //bir değer girilmeli ki üzerinde işlem yapılabilsin.
            int ikramiye = 0; // 0 dan başlatılacak.

            switch (cinsiyetTuru)
            {

                case "1": //Cinsiyet erkek seçildi.

                    if (yas >= 60)
                    {

                        ikramiye = maas * 10;
                        Console.WriteLine("Erkek emekli edildi. İkramiye: " + ikramiye);

                    }

                    else if (yas >= 60)
                    {

                        if (calisilanGun >= 6000)
                        {
                            ikramiye += maas * 11;
                        }

                        else
                        {
                            Console.WriteLine("Üzgünüz, 6000 gün çalışma sayısını doldurmadığınız için emekli olamıyorsunuz.");
                        }

                    }

                break;

                case "2": //Cinsiyet kadın seçildi.

                    if (yas >= 58)
                    {

                        ikramiye = maas * 10;
                        Console.WriteLine("Erkek emekli edildi. İkramiye: " + ikramiye);

                    }

                    else
                    {

                        if (calisilanGun >= 3600)
                        {
                            ikramiye += maas * 11;
                        }

                        else
                        {
                            Console.WriteLine("Üzgünüz, 6000 gün çalışma sayısını doldurmadığınız için emekli olamıyorsunuz.");
                        }

                    }

                break;

                default:
                    Console.WriteLine("Geçersiz cinsiyet girişi. Lütfen '1' veya '2' yi seçiniz.");
                    break;

            }


        }
    }
}
