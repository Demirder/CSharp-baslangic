using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant2
{
    internal class masa
    {

        // Masa No özelliği
        public int MasaNo { get; set; }

        // Durum özelliği
        public string Durum { get; set; }


        // Constructor (yapıcı metot)
        public masa(int masaNo, string durum = "Boş")
        {
            MasaNo = masaNo;
            Durum = durum;

        }

    }
}
