using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZorePazaryeriConverter.Static
{
   public static class N11ConvertEkAyarlar
    {
        private static string urunKodu;
        public static string UrunKodu {
            get
            {
                if (urunKodu == null)
                    urunKodu = "389786";
                return urunKodu;
            }
            set
            {
                
                urunKodu = value;
            }
        }
        private static string indirimliFiyat;
        public static string IndirimliFiyat {
            get
            {
                if (indirimliFiyat == null)
                    indirimliFiyat = "0";
                return indirimliFiyat;
            }
            set
            {
                
                indirimliFiyat = value;
            }
        }private static string dosyaIsmi;
        public static string DosyaIsmi {
            get
            {
                if (dosyaIsmi == null)
                    dosyaIsmi = "Demo";
                return dosyaIsmi;
            }
            set
            {
                
                dosyaIsmi = value;
            }
        }private static string dosyaYolu;
        public static string DosyaYolu {
            get
            {
                if (dosyaYolu == null)
                    dosyaYolu = "E";
                return dosyaYolu;
            }
            set
            {
                
                dosyaYolu = value;
            }
        }
    }
}
