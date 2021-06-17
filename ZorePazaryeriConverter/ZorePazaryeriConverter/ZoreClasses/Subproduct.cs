using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "subproduct")]
    public class Subproduct
    {
        [XmlElement(ElementName = "VaryantGroupID")]
        public string VaryantGroupID { get; set; }
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "ws_code")]
        public string Ws_code { get; set; }
        [XmlElement(ElementName = "type1")]
        public string Type1 { get; set; }
        [XmlElement(ElementName = "type2")]
        public string Type2 { get; set; }
        [XmlElement(ElementName = "barcode")]
        public string Barcode { get; set; }
        [XmlElement(ElementName = "stock")]
        public string Stock { get; set; }
        [XmlElement(ElementName = "desi")]
        public string Desi { get; set; }
        [XmlElement(ElementName = "price_list")]
        public string Price_list { get; set; }
        [XmlElement(ElementName = "price_list_discount")]
        public string Price_list_discount { get; set; }
        [XmlElement(ElementName = "price_special")]
        public string Price_special { get; set; }
        [XmlElement(ElementName = "supplier_code")]
        public string Supplier_code { get; set; }
        [XmlElement(ElementName = "images")]
        public Images Images { get; set; }
    }
}
