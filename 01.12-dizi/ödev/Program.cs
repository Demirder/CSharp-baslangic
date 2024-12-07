namespace ödev
{
    internal class Program
    {

        
        static HashSet<int> benzersizSayilar = new HashSet<int>();
        static int[] sayilar = new int[10];

        static void Main(string[] args)
        {
            //klavyeden girilen değerler arasında rastgele sayı üreten  ve bu değerleri 10 elemanlı bir diziye atayan SayiUret() isimli bir metot yazın.
            //Bu dizinin elemanlarını yazan DiziYazdır() isimli bir metot daha yazarak elemanları listeleyin.
            //Daha sonra bu dizi içerisinde EnBuyukDeger() adında bir metot ile dizinin en büyük değerini bulan,
            //en küçük değerinin bulan EnKucukDeger() adından başka bir metot daha yazınız.
            //EnBuyukDeger ve EnKucukDeger metotlarında dönen değerleri ekranda gösteren programı yazınız
            //kullanıcının bütün hataları kontrol altına alınmalı



            /* 
            1- klavyeden değer girdir
            2- değerler arasında rastegele sayılar üretsin
            3- rastgele sayılardan 10 elemanlı diziye atayan SayiUret() metot yaz
            4- DiziYazdır() metoduyla elemanları listele
            5- EnKucukDeger() adında küçük değerleri sıralayan metot yaz
            6- EnBuyukDeger() adında büyük değerleri sıralayan metot yaz
            7-EnBuyukDeger ve EnKucukDeger metotlarında dönen değerleri ekranda gösteren programı yaz
            8- kullanıcının hataları sayılmalı
            */

            Console.WriteLine("Birinci değeri giriniz.");
            int deger1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("İkinci değeri giriniz.");
            int deger2 = Convert.ToInt32(Console.ReadLine());

            if (deger1 >= deger2)
            {
                Console.WriteLine("Birinci değer ikinci değerden küçük olmalıdır. Program sonlandırılıyor.");
                return;
            }

            if (deger2 - deger1 + 1 < 10) //deger2 - deger1 ifadesi sadece aradaki farkı gösterir; o aralıktaki öğe sayısını göstermez. +1 eklemek, aralığın başındaki sayıyı da dahil etmeyi sağlar..
            {
                Console.WriteLine("Girilen aralık, 10 benzersiz sayı oluşturmak için yeterli değil. Program sonlandırılıyor.");
                return;
            }



            Random r = new Random();
            int sayi = r.Next(deger1, deger2);

            // Benzersiz 10 sayı üret
            while (benzersizSayilar.Count < 10) // count özelliği, koleksiyonun içindeki eleman sayısını döndürür.
            {
                sayi = r.Next(deger1, deger2 + 1); // Rastgele sayı üret, deger2 değerini de sayı üretirken dahil et
                benzersizSayilar.Add(sayi);           // Benzersizse ekler
            }

            SayiUret();
            DiziYazdır();
            EnbuyukDeger();
            EnkucukDeger();

        }

        static void SayiUret()
        {

            // HashSet'teki benzersiz sayıları bir diziye aktar
            
            benzersizSayilar.CopyTo(sayilar);

            

        }

        static void DiziYazdır()

        {

            // Sayıları ekrana yazdır
            Console.WriteLine("Oluşturulan Benzersiz Rastgele Sayılar:");
            foreach (int sayi1 in sayilar)
            {
                Console.WriteLine(sayi1);
            }

        }

        static void EnbuyukDeger()

        {

            int enBuyuk = sayilar.Max();
            Console.WriteLine($"En büyük sayı: {enBuyuk}");

        }

        static void EnkucukDeger()

        {

            int enKucuk = sayilar.Min();
            Console.WriteLine($"En küçük sayı: {enKucuk}");

        }
    }
}
