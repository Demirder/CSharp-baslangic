namespace _17._11_dizi
{
    internal class Program
    {
        static void Main(string[] args)
        {
           


            string[] ogrenciler = { "Eymen", "Eymen", "Eymen", "Eymen", "Safiye", "Eymen", "Eymen", "Eymen", "Eymen", "Safiye", "Bekir", "Eymen", "Eymen", "Eymen", "Rümeysa", "Safiye", "Berat", "Eymen", "Eymen", "Eymen", "Eymen", "Eymen", "Eymen", "Eymen", "Eymen", "Eymen", "Safiye" };

            //Yukarıdaki dizinin içinde bulunan SAFİYE isimlerinin Index değerlerini ekrana bir döngü yardımı ile yazdırınız.

            //Düşününki dizi içinde 1Milyon isim olabilir.Oluşturulan döngü tek tek kontrol ederek 1 Milyon tur atmasın.Kodun başarılı olması en az tur da bütün indexleri yazdırmalısınız.

            int count = 0;

            int index = -1;
            while (index < ogrenciler.Length)
            {
                count++;
                index = Array.IndexOf(ogrenciler, "Safiye", index + 1);
                if (index == -1)
                {
                    break;
                }
                Console.WriteLine(index);
            }

            Console.WriteLine("Tur sayısı:" + count);

        }
    }
}
