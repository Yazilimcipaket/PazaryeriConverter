namespace ZorePazaryeriConverter.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XmlProduct")]
    public partial class XmlProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XmlProduct()
        {
            XmlImage = new HashSet<XmlImage>();
            XmlSubProduct = new HashSet<XmlSubProduct>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Ws_code { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        [StringLength(50)]
        public string Supplier_code { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Product_link { get; set; }

        [StringLength(50)]
        public string Cat1name { get; set; }

        [StringLength(50)]
        public string Cat1code { get; set; }

        [StringLength(50)]
        public string Cat2name { get; set; }

        [StringLength(50)]
        public string Cat2code { get; set; }

        [StringLength(250)]
        public string Category_path { get; set; }

        [StringLength(50)]
        public string Stock { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        [StringLength(50)]
        public string Price_list { get; set; }

        [StringLength(50)]
        public string Price_list_campaign { get; set; }

        [StringLength(50)]
        public string Price_special_vat_included { get; set; }

        [StringLength(50)]
        public string Price_special { get; set; }

        [StringLength(50)]
        public string Price_special_rate { get; set; }

        [StringLength(50)]
        public string Min_order_quantity { get; set; }

        [StringLength(50)]
        public string Price_credit_card { get; set; }

        [StringLength(50)]
        public string Currency { get; set; }

        [StringLength(50)]
        public string Vat { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Desi { get; set; }

        [StringLength(50)]
        public string Width { get; set; }

        [StringLength(50)]
        public string Height { get; set; }

        [StringLength(50)]
        public string Deep { get; set; }

        [StringLength(150)]
        public string Weight { get; set; }

        public string Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XmlImage> XmlImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XmlSubProduct> XmlSubProduct { get; set; }
    }
}
