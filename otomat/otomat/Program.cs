namespace otomat
{
    internal class Program
    {

        

        static void Main(string[] args)
        {



            int fiyat = 0;
            int odeme = 0; // Ödemeyi burada başlatıyoruz

            // 4 ürün için diziler
            string[] urunAdlari = { "Fanta", "Kola", "Çikolata", "Bisküvi", "Su" };
            int[] urunFiyatlari = { 40, 40, 30, 20, 15 };

  

            int hak = 0;

            while (hak < 3)
            {

                // Kullanıcıdan ürün seçimi
                int secim;
                Console.Write("Ürün numarasını tuşlayınız. 1-2-3-4-5: ");
                secim = int.Parse(Console.ReadLine());


                // Geçersiz seçim yapılırsa hak sayısı azalır
                if (secim < 1 || secim > 5)
                {
                    hak++; // Yanlış seçimde hak azaltılır

                    Console.WriteLine($"Kalan hakkınız: {3 - hak}");

                    // Eğer hak bitti ise program sonlanır
                    if (hak == 3)
                    {
                        Console.WriteLine("Geçersiz tuşlama, seçim hakkınız bitti. Program sonlandırılıyor.");
                        return; // Program sonlandırılır
                    }

                    continue; // Döngü başa döner
                }

                // Seçilen ürünün fiyatını 'fiyat' değişkenine atıyoruz
                fiyat = urunFiyatlari[secim - 1];

                Console.WriteLine($"Seçtiğiniz ürün: {urunAdlari[secim - 1]}, Fiyat: {urunFiyatlari[secim - 1]}");
                break;


            }

            Console.WriteLine("Ödeme yapmak için paranızı gösterilen yerden yatırınız.");
            odeme = Convert.ToInt32(Console.ReadLine()); ; // İlk ödeme alındı

            // Ödeme doğrulama ve durum kontrolü

            if (odeme == fiyat)
            {

                Console.WriteLine("Afiyet olsun.");

            }

            else if (odeme > fiyat)
            {
                double paraUstu = odeme - fiyat;
                Console.WriteLine($"Afiyet olsun! Para üstünüz: {paraUstu} TL");

            }
            else
            {
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
                        double paraUstu = odeme - fiyat; // Fazla ödenen miktar
                        Console.WriteLine($"Fazla ödeme yaptınız! Para üstünüz: {paraUstu} TL");
                        Console.WriteLine("Afiyet olsun.");
                    }
                    else if (odeme == fiyat)
                    {
                        // Eğer ödeme tam ise
                        Console.WriteLine("Tam ödeme yapıldı. Afiyet olsun.");
                    }
                    else
                    {
                        // Eğer ödeme hala eksikse
                        double eksikPara2 = fiyat - odeme;
                        Console.WriteLine($"Ödeme yetersiz. Eksik para: {eksikPara2} TL");
                    }

                }

                else if (secimIslem == 2)
                {

                    Console.WriteLine("Paranız iade ediliyor.");

                }

            }
            Console.WriteLine("Eklemek istediğiniz ürünün adı: ");
            urunAdlari[urunAdlari.Length - 1] = Console.ReadLine();



            for (int i = 0; i < urunAdlari.Length; i++)
            {
                Console.WriteLine(urunAdlari[i] + "\n");
            }


            Console.WriteLine("İsim güncellemek için 1, fiyat güncellemek için 2 yazınız.");
            int guncelleme = Convert.ToInt32(Console.ReadLine());
            if (guncelleme == 1)
            {
                Console.WriteLine("Hangi ürünü güncellemek istiyorsunuz numarasını yazınız.");
                for (int i = 0; i < urunAdlari.Length; i++)
                {
                    Console.WriteLine(urunAdlari[i] + "\n");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ne ile değiştirilecek?");
                    String degisim = Console.ReadLine();
                    urunAdlari[num - 1] = degisim;
                }

            }

            Console.WriteLine("Güüncellemek istediğiniz ürünün adı: ");
            int numara = Convert.ToInt32(Console.ReadLine());
            Array.Clear(urunAdlari, numara - 1,1 );
            Array.Clear(urunFiyatlari, numara - 1,1 );
            

            for (int i = 0; i < urunAdlari.Length; i++)
            {
                Console.Write(urunAdlari[i]);
                Console.Write(urunFiyatlari[i]);
                Console.WriteLine();
            }

            //Gün sonu toplam satış

        }
    }
}