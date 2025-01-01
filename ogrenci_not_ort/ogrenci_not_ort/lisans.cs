using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogrenci_not_ort
{
    internal class lisans : ogrenci_bilgileri
    {

        // Öğrenci sınıfı için özellikler (properties)
        public string FakulteAdi { get; set; }
        public double Vize { get; set; }
        public double Final { get; set; }

        public lisans(string FakulteAdi, double vize, double final) : base("Demir Derin", 1, OgretimDuzeyi.Lisans)
        {

            this.FakulteAdi = FakulteAdi;
            Vize = vize;
            Final = final;


        }

        // Notları Hesaplama ve Derecelendirme
        public void NotHesapla()
        {
            double ortalama = (Vize * 0.4) + (Final * 0.6); // Vizenin %40'ı ve Finalin %60'ı hesaplanıyor
            string derece = "";

            // Derecelendirme
            if (ortalama >= 85)
                derece = "A";
            else if (ortalama >= 70)
                derece = "B";
            else if (ortalama >= 60)
                derece = "C";
            else if (ortalama >= 50)
                derece = "D";
            else if (ortalama >= 45)
                derece = "E";
            else
                derece = "F";

            // Sonuçları ekrana yazdır
            Console.WriteLine($"Vize Notu: {Vize}, Final Notu: {Final}");
            Console.WriteLine($"Ortalama: {ortalama}, Derece: {derece}");
        }

        public double _Vize
        {
            get { return Vize; }
            set
            {
                if (value >= 0 && value < 101)
                {
                    Vize = value;
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Hatalı!!");

                        Console.WriteLine("Vize notunuz:");
                        double vize = Convert.ToInt32(Console.ReadLine());

                        if (vize >= 0 && vize < 101)
                        {
                            Vize = vize;
                            break;
                        }
                    }
                }
            }
        }
        public double _Final
        {
            get { return Final; }
            set
            {
                if (value >= 0 && value < 101)
                {
                    Final = value;
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Hatalı!!");

                        Console.WriteLine("Final notunuz:");
                        double final = Convert.ToInt32(Console.ReadLine());

                        if (final >= 0 && final < 101)
                        {
                            Final = final;
                            break;
                        }
                    }
                }
            }

        }
    }
}