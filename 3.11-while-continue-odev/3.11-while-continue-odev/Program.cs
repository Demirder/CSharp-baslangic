using System;

class Program
{
    static void Main()
    {
        double toplam = 0; // Toplamı tutacak değişken
        double sayi; // Kullanıcının girdiği sayı
        double sayiAdeti = 0; // Girilen pozitif sayıların sayısını tutacak değişken

        while (true) // Sonsuz döngü
        {
            Console.WriteLine("Pozitif bir sayı giriniz:");
            sayi = Convert.ToInt32(Console.ReadLine());

            // Kullanıcı 0 girerse, döngüden çık
            if (sayi == 0)
            {
                // Eğer hiç pozitif sayı girilmemişse, tekrar sayı iste
                if (sayiAdeti == 0)
                {
                    Console.WriteLine("Lütfen pozitif bir sayı giriniz!"); /* Eğer kullanıcı ilk defa 0 girmişse (yani sayiSayisi 0'dır), bir hata mesajı verilir ve döngü tekrar başlatılır. Bu durumda kullanıcıdan tekrar pozitif bir sayı girmesi istenir */
                    continue; // Döngünün başına dön
                }
                break; // 0 girilirse döngüden çık
            }

            // Negatif sayı kontrolü
            if (sayi < 0)
            {
                Console.WriteLine("Lütfen pozitif bir sayı giriniz!!"); /* negatif bir sayı girildiğinde geçerli olmayan bir değer olduğu için döngü continue ile başa döner. */
                continue; // Geçersiz girdiği için döngünün başına dön
            }

            // Pozitif sayıyı toplama ekle
            toplam += sayi;
            sayiAdeti++; // Pozitif sayı sayısını artır
        }

        // Ortalama hesapla ve yazdır
        if (sayiAdeti > 0)
        {
            double ortalama = (double)toplam / sayiAdeti; // Ortalama hesapla
            Console.WriteLine("Girilen pozitif sayıların toplamı: " + toplam);
            Console.WriteLine("Girilen pozitif sayıların ortalaması: " + ortalama);
        }
        else
        {
            Console.WriteLine("Hiç pozitif sayı girilmedi.");
        }
    }
}
