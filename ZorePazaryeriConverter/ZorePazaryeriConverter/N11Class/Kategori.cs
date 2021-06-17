using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "Kategori")]
    public class Kategori
    {
        [XmlElement(ElementName = "Ozellikler")]
        public Ozellikler Ozellikler { get; set; }
        [XmlAttribute(AttributeName = "no")]
        public string No { get; set; }
        [XmlAttribute(AttributeName = "isim")]
        public string Isim { get; set; }
    }
}
