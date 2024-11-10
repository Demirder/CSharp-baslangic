
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random r = new Random();
            int rast = r.Next(1, 100);
            int sayac = 5;


            while (sayac>0)
            {

                Console.WriteLine("1 ile 100 arası sayıyı tahmin et");
                int tahminet = Convert.ToInt32(Console.ReadLine());

                if (rast==tahminet)
                {
                    Console.WriteLine("OK");
                    break;
                }
                else if (tahminet > rast)
                {
                    Console.WriteLine("Tahmin küçült");
                }
                else 
                {
                    Console.WriteLine("Tahmin büyült");
                }

                sayac--;
            }

        }
    }
}