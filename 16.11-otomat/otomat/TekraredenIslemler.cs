using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace otomat
{
    internal class TekraredenIslemler
    {
        internal static int YenidenSor(string[] urunler, int[] fiyatlar)
        {
            int hak = 0;
            int secim = -1;
            while (hak < 3)
            {
                for (int i = 0; i < urunler.Length; i++)
                {
                    Console.WriteLine($"{i + 1}-{urunler[i]}:{fiyatlar[i]}");
                }
               
                Console.Write("Ürün seçiniz.");
                secim = int.Parse(Console.ReadLine())-1;

                // Geçersiz seçim yapılırsa hak sayısı azalır
                if (secim < 0 || secim >= urunler.Length)
                {
                    hak++; // Yanlış seçimde hak azaltılır

                    Console.WriteLine($"Kalan hakkınız: {3 - hak}");

                    // Eğer hak bitti ise program sonlanır
                    if (hak == 3)
                    {
                        Console.WriteLine("Geçersiz tuşlama, seçim hakkınız bitti. Program sonlandırılıyor.");
                        return secim;
                    }

                    continue; // Döngü başa döner

                }
                Console.WriteLine($"Seçtiğiniz ürün: {urunler[secim]}, Fiyat: {fiyatlar[secim]}");
                break;
            }

            Console.WriteLine(" ");
            return secim;
        }
    }

}

