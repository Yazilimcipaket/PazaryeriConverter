using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter.XmlClasses
{
    [XmlRoot(ElementName = "Urun")]
    public class TekkartXmlClass
    {
        public TekkartXmlClass()
        {
            Varyantlar = new TekkartXmlClassVaryantlar();
        }
        [XmlElement(ElementName = "kategori")]
        public int Kategori { get; set; }
      
        [XmlElement(ElementName = "anaresim")]
        public string AnaResim { get; set; }
        [XmlElement(ElementName = "urunad")]
        public string UrunAd { get; set; }
        [XmlElement(ElementName = "urunkod")]
        public string Urunkod { get; set; }
        [XmlElement(ElementName = "aciklama")]
        public string Aciklama { get; set; }
        [XmlElement(ElementName = "marka")]
        public string Marka { get; set; }
        [XmlElement(ElementName = "kargolamatipi")]
        public int KargolamaTipi { get; set; }
        [XmlElement(ElementName = "kargolanmasuresi")]
        public int Kargolamasuresi { get; set; }
        [XmlElement(ElementName = "fiyat")]
        public decimal Fiyat { get; set; }
        [XmlElement(ElementName = "indirimlifiyat")]
        public decimal IndirimliFiyat { get; set; }
        [XmlElement(ElementName = "doviztip")]
        public int DovizTip { get; set; }
        [XmlElement(ElementName = "stok")]
        public int Stok { get; set; }
        [XmlElement(ElementName = "desi")]
        public string Desi { get; set; }
        [XmlElement(ElementName = "sonyayintarih")]
        public string SonYayinTarihi { get; set; }
        [XmlElement(ElementName = "resim1")]
        public string Resim1 { get; set; }
        [XmlElement(ElementName = "resim2")]
        public string Resim2 { get; set; }
        [XmlElement(ElementName = "resim3")]
        public string Resim3 { get; set; }
        [XmlElement(ElementName = "resim4")]
        public string Resim4 { get; set; }
        [XmlElement(ElementName = "resim5")]
        public string Resim5 { get; set; }
        [XmlElement(ElementName = "resim6")]
        public string Resim6 { get; set; }
       
     

        [XmlElement(ElementName = "varyantlar")]
        public TekkartXmlClassVaryantlar Varyantlar { get; set; }
    }
}
