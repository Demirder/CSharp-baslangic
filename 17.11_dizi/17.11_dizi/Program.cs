namespace _17._11_dizi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] ogrenciler = { "Safiye", "Eymen", "Safiye", "Bekir", "Rümeysa", "Safiye", "Berat", "Safiye" };

            //Yukarıdaki dizinin içinde bulunan SAFİYE isimlerinin Index değerlerini ekrana bir döngü yardımı ile yazdırınız.

            //Düşününki dizi içinde 1Milyon isim olabilir. Oluşturulan döngü tek tek kontrol ederek 1 Milyon tur atmasın. Kodun başarılı olması en az tur da bütün indexleri yazdırmalısınız.


            string[] ogrenciler = { "Safiye", "Eymen", "Safiye", "Bekir", "Rümeysa", "Safiye", "Berat", "Safiye" };

            Console.WriteLine("Safiye isminin indexlerini yazdırınız.");
            int turSayisi =0; //turu sıfırdan başlatıyoruz.

            for (int i = 0; i < ogrenciler.Length; i++) // dizinin uzunluğunu algılamak için lenght kullandım.
            {
                turSayisi++;  // Her bir kontrol için tur sayısını artırıyoruz.

                if (ogrenciler[i] == "Safiye")
                {
                    Console.WriteLine(i);
                 }

            }

            Console.WriteLine("Toplam " + turSayisi + " tur atıldı."); //total tur sayısını öğrenmek için de işlemi yapıyoruz.

        }
    }
}
