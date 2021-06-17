using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "Stok")]
    public class Stok
    {
        public Stok()
        {
            Ozellik = new List<Ozellik>();
        }
        [XmlElement(ElementName = "Ozellik")]
        public List<Ozellik> Ozellik { get; set; }
        [XmlElement(ElementName = "Miktar")]
        public string Miktar { get; set; }
        [XmlElement(ElementName = "StokKodu")]
        public string StokKodu { get; set; }
        [XmlElement(ElementName = "StokFiyati")]
        public string StokFiyati { get; set; }
        [XmlElement(ElementName = "Gtin")]
        public string Gtin { get; set; }
        [XmlElement(ElementName = "Mpn")]
        public string Mpn { get; set; }
        [XmlElement(ElementName = "Bundle")]
        public string Bundle { get; set; }
        [XmlElement(ElementName = "N11KatalogId")]
        public string N11KatalogId { get; set; }
    }
}
