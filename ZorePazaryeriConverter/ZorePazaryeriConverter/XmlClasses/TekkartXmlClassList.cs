using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter.XmlClasses
{
    [XmlRoot(ElementName = "Urunler")]
    public class TekkartXmlClassList
    {
        public TekkartXmlClassList()
        {
            Urunler = new List<TekkartXmlClass>();
        }
        [XmlElement(ElementName = "Urun")]
        public List<TekkartXmlClass> Urunler { get; set; }
        public void CreateXml(string DosyaYolu, string DosyaIsmi)
        {
            var xml = new XmlSerializer(typeof(TekkartXmlClassList));
            string yol = string.Format(@"{0}:\{1}.xml", DosyaYolu, DosyaIsmi);
            using (StreamWriter sw = new StreamWriter(yol))
            {
                xml.Serialize(sw, this);
            }
        }
    }
}
