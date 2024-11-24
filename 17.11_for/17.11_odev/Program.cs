namespace _17._11_odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for ile yapılmıştır.
            //for (int i = 1; i < 3; i++)

            #region PASCAL ÜÇGENİ
            /*
            
            *
            **
            ***
            ****
            *****
            ******
            
             */


            //Console.WriteLine("*");

            //for (int i = 1; i < 3; i++)
            //{

            //    Console.Write("*");

            //}

            //Console.WriteLine("");

            //for (int i = 1; i < 4; i++)
            //{

            //    Console.Write("*");

            //}

            //Console.WriteLine("");


            //for (int i = 1; i < 5; i++)
            //{

            //    Console.Write("*");
            //}

            //Console.WriteLine("");


            //for (int i = 1; i < 6; i++)
            //{

            //    Console.Write("*");
            //}

            //Console.WriteLine("");

            //for (int i = 1; i < 7; i++)
            //{

            //    Console.Write("*");
            //}

            //Console.WriteLine("");


            // veya şu şekilde de yapılabilir.

            /*
            
            *
            **
            ***
            ****
            *****
            ******
            
             

            //for (int i = 1; i < 7; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write("*"); //çalıştıktan sonra imleç aynı satırda kalır.
            //    }
            //    Console.WriteLine();
            //}



            */


            #endregion


            #region #region KARE
            /*

            *********
            *       *
            *       *
            *       *
            *       *
            *       *
            *********

             */

            //for (int i = 1; i < 10; i++)
            //{

            //    Console.Write("*");

            //}


            //Console.WriteLine();

            //for (int i = 1; i <= 5; i++)
            //{

            //    Console.Write("*"); // burada write kullanıyoruz çünkü amacımız alt alta yazmak olarak görünse de yan yana yazmak ama yıldızlar arası boşluk olması gerektiği için for içine for yazıp boşluk veriyoruz.

            //    for (int a = 1; a <= 7; a++)
            //    {  // Ortada 7 boşluk olacak
            //        Console.Write(" ");
            //    }

            //    Console.WriteLine("*");  // Son yıldız ve alt satıra geç

            //}

            //for (int i = 1; i < 10; i++)
            //{

            //    Console.Write("*");

            //}

            //Console.WriteLine();

            //veya şu şekilde de yapılır

            /*
             
            *********
            *       *
            *       *
            *       *
            *       *
            *       *
            *********
            
            //for (int i = 1; i < 8; i++)
            //{
            //    if(i==1 || i == 7)
            //    {
            //        Console.WriteLine("***********");
            //    }
            //    else
            //    {
            //        Console.Write("*");
            //        for (int j = 0; j < 9; j++)
            //        {
            //            Console.Write(" ");
            //        }
            //        Console.WriteLine("*");
            //    }
            //}
            
            
             
            */

            #endregion


            #region Yılbaşı Ağacı
            /*

                    *
                   ***
                  *****
                 *******
                *********
               ***********

             */


            //int bosluk = 5;

            //for (int i = 1; i < 12; i+=2)
            //{
            //    for (int j = bosluk; j >0; j--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int k = i; k >0; k--)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //    bosluk -= 1;
            //}




            #endregion

            #region Çarpım Tablosu

            /*
             
            1*1=1  2*1=2 3*1=3 ...
            1*2=2
            1*3=3
            
             */

            //for (int i = 1; i < 11; i++)
            //{
            //    for (int j = 1; j < 11; j++)
            //    {
            //        Console.Write($"{j}x{i}={i*j}\t");
            //    }
            //    Console.WriteLine();
            //}

            #endregion



        }
    }
}
