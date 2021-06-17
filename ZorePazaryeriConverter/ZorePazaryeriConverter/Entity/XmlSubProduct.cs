namespace ZorePazaryeriConverter.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XmlSubProduct")]
    public partial class XmlSubProduct
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string VaryantGroupID { get; set; }

        [StringLength(250)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Ws_code { get; set; }

        [StringLength(250)]
        public string Type1 { get; set; }

        [StringLength(250)]
        public string Type2 { get; set; }

        [StringLength(250)]
        public string Barcode { get; set; }

        [StringLength(250)]
        public string Stock { get; set; }

        [StringLength(250)]
        public string Desi { get; set; }

        [StringLength(250)]
        public string Price_list { get; set; }

        [StringLength(250)]
        public string Price_list_discount { get; set; }

        [StringLength(250)]
        public string Price_special { get; set; }

        [StringLength(250)]
        public string Supplier_code { get; set; }

        public int? ProductID { get; set; }

        public virtual XmlProduct XmlProduct { get; set; }
    }
}
