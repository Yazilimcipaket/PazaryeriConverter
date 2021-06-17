using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZorePazaryeriConverter
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "ws_code")]
        public string Ws_code { get; set; }
        [XmlElement(ElementName = "barcode")]
        public string Barcode { get; set; }
        [XmlElement(ElementName = "supplier_code")]
        public string Supplier_code { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "product_link")]
        public string Product_link { get; set; }
        [XmlElement(ElementName = "cat1name")]
        public string Cat1name { get; set; }
        [XmlElement(ElementName = "cat1code")]
        public string Cat1code { get; set; }
        [XmlElement(ElementName = "cat2name")]
        public string Cat2name { get; set; }
        [XmlElement(ElementName = "cat2code")]
        public string Cat2code { get; set; }
        [XmlElement(ElementName = "category_path")]
        public string Category_path { get; set; }
        [XmlElement(ElementName = "stock")]
        public string Stock { get; set; }
        [XmlElement(ElementName = "unit")]
        public string Unit { get; set; }
        [XmlElement(ElementName = "price_list")]
        public string Price_list { get; set; }
        [XmlElement(ElementName = "price_list_campaign")]
        public string Price_list_campaign { get; set; }
        [XmlElement(ElementName = "price_special_vat_included")]
        public string Price_special_vat_included { get; set; }
        [XmlElement(ElementName = "price_special")]
        public string Price_special { get; set; }
        [XmlElement(ElementName = "price_special_rate")]
        public string Price_special_rate { get; set; }
        [XmlElement(ElementName = "min_order_quantity")]
        public string Min_order_quantity { get; set; }
        [XmlElement(ElementName = "price_credit_card")]
        public string Price_credit_card { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "vat")]
        public string Vat { get; set; }
        [XmlElement(ElementName = "brand")]
        public string Brand { get; set; }
        [XmlElement(ElementName = "model")]
        public string Model { get; set; }
        [XmlElement(ElementName = "desi")]
        public string Desi { get; set; }
        [XmlElement(ElementName = "width")]
        public string Width { get; set; }
        [XmlElement(ElementName = "height")]
        public string Height { get; set; }
        [XmlElement(ElementName = "deep")]
        public string Deep { get; set; }
        [XmlElement(ElementName = "weight")]
        public string Weight { get; set; }
        [XmlElement(ElementName = "detail")]
        public string Detail { get; set; }
        [XmlElement(ElementName = "seo_title")]
        public string Seo_title { get; set; }
        [XmlElement(ElementName = "seo_description")]
        public string Seo_description { get; set; }
        [XmlElement(ElementName = "seo_keywords")]
        public string Seo_keywords { get; set; }
        [XmlElement(ElementName = "images")]
        public Images Images { get; set; }
        [XmlElement(ElementName = "subproducts")]
        public Subproducts Subproducts { get; set; }
    }
}
