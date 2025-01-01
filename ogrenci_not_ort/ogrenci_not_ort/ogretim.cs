using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogrenci_not_ort
{
    internal class ogretim : ogrenci_bilgileri
    {

        // Öğrenci sınıfı için özellikler (properties)
        public string OkulAdi { get; set; }
        public double Not1 { get; set; }
        public double Not2 { get; set; }

        public ogretim(string OkulAdi, double not1, double not2) : base("Demir Derin", 1, OgretimDuzeyi.Lise)
        {

            this.OkulAdi = OkulAdi;
            Not1 = not1;
            Not2 = not2;

        }

        // Notları Hesaplama ve Derecelendirme
        public void NotHesapla()
        {
            double ortalama = (Not1 + Not2) / 2; // Vizenin %40'ı ve Finalin %60'ı hesaplanıyor
            string derece = "";

            // Derecelendirme
            if (ortalama >= 85)
                derece = "Pek İyi";
            else if (ortalama >= 70)
                derece = "İyi";
            else if (ortalama >= 60)
                derece = "Orta";
            else if (ortalama >= 50)
                derece = "Geçer";
            else 
                derece = "Tekrar";
            

            // Sonuçları ekrana yazdır
            Console.WriteLine($"Not1: {Not1}, Not2: {Not2}");
            Console.WriteLine($"Ortalama: {ortalama}, Derece: {derece}");
        }

        public double _Not
        {
            get { return Not1; }
            set
            {
                if (value >= 0 && value < 101)
                {
                    Not1 = value;
                }
                else
                {
                   
                        Console.WriteLine("Hatalı!!");

                     
                }
            }
        }
        public double _Not2
        {
            get { return Not2; }
            set
            {
                if (value >= 0 && value < 101)
                {
                    Not2 = value;
                }
                else
                {
                   
                        Console.WriteLine("Hatalı!!");

                        
                 
                }
            }

        }

    }
}
