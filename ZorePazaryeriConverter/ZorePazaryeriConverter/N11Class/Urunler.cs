using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZorePazaryeriConverter.Static;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "Urunler")]
    public class Urunler
    {
        public Urunler()
        {
            Urun = new List<Urun>();
        }
        [XmlElement(ElementName = "Urun")]
        public List<Urun> Urun { get; set; }
        public void  CreateXml()
        {
            var xml = new XmlSerializer(typeof(Urunler));
            string yol= string.Format(@"{0}:\{1}.xml", N11ConvertEkAyarlar.DosyaYolu, N11ConvertEkAyarlar.DosyaIsmi);
            using ( StreamWriter sw = new StreamWriter(yol))
            {
                xml.Serialize(sw, this);
            }
        }
        public void  CreateXml(string DosyaYolu,string DosyaIsmi)
        {
            var xml = new XmlSerializer(typeof(Urunler));
            string yol= string.Format(@"{0}:\{1}.xml",DosyaYolu,DosyaIsmi);
            using ( StreamWriter sw = new StreamWriter(yol))
            {
                xml.Serialize(sw, this);
            }
        }
    }
}
