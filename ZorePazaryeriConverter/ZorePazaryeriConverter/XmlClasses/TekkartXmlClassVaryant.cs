using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter.XmlClasses
{
    [XmlRoot(ElementName = "Varyant")]
    public  class TekkartXmlClassVaryant
    {
        [XmlElement(ElementName = "grup")]
        public string Grup { get; set; }
        [XmlElement(ElementName = "ad")]
        public string Ad{ get; set; }
        [XmlElement(ElementName = "stok")]
        public int Stok { get; set; }
        [XmlElement(ElementName = "fiyat")]
        public decimal Fiyat { get; set; }
    }
}
