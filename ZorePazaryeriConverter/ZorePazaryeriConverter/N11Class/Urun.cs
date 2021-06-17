using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "Urun")]
    public class Urun
    {
        [XmlElement(ElementName = "UrunKodu")]
        public string UrunKodu { get; set; }
        [XmlElement(ElementName = "Kod")]
        public string Kod { get; set; }
        [XmlElement(ElementName = "Baslik")]
        public string Baslik { get; set; }
        [XmlElement(ElementName = "AltBaslik")]
        public string AltBaslik { get; set; }
        [XmlElement(ElementName = "Aciklama")]
        public string Aciklama { get; set; }
        [XmlElement(ElementName = "UrunOnayi")]
        public string UrunOnayi { get; set; }
        [XmlElement(ElementName = "HazirlamaSuresi")]
        public string HazirlamaSuresi { get; set; }
        [XmlElement(ElementName = "Kategori")]
        public Kategori Kategori { get; set; }
        [XmlElement(ElementName = "Fiyat")]
        public string Fiyat { get; set; }
        [XmlElement(ElementName = "UretimTarihi")]
        public string UretimTarihi { get; set; }
        [XmlElement(ElementName = "SonTuketimTarihi")]
        public string SonTuketimTarihi { get; set; }
        [XmlElement(ElementName = "SatisBaslangicTarihi")]
        public string SatisBaslangicTarihi { get; set; }
        [XmlElement(ElementName = "SatisBitisTarihi")]
        public string SatisBitisTarihi { get; set; }
        [XmlElement(ElementName = "Stoklar")]
        public Stoklar Stoklar { get; set; }
        [XmlElement(ElementName = "Resimler")]
        public Resimler Resimler { get; set; }
        [XmlElement(ElementName = "IndirimTuru")]
        public string IndirimTuru { get; set; }
        [XmlElement(ElementName = "IndirimTutari")]
        public string IndirimTutari { get; set; }
        [XmlElement(ElementName = "IndirimBaslangicTarihi")]
        public string IndirimBaslangicTarihi { get; set; }
        [XmlElement(ElementName = "IndirimBitisTarihi")]
        public string IndirimBitisTarihi { get; set; }
        [XmlElement(ElementName = "TeslimatSablonu")]
        public string TeslimatSablonu { get; set; }
        [XmlElement(ElementName = "YerliUretim")]
        public string YerliUretim { get; set; }
        [XmlElement(ElementName = "ParaBirimi")]
        public string ParaBirimi { get; set; }
        [XmlElement(ElementName = "GroupAttribute")]
        public string GroupAttribute { get; set; }
        [XmlElement(ElementName = "GroupItemCode")]
        public string GroupItemCode { get; set; }
        [XmlElement(ElementName = "ItemName")]
        public string ItemName { get; set; }
    }
}
