namespace ZorePazaryeriConverter.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Toplu")]
    public partial class Toplu
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Marka { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(150)]
        public string Kod1 { get; set; }

        [StringLength(150)]
        public string Kod2 { get; set; }

        [StringLength(50)]
        public string Kod12 { get; set; }

        [StringLength(50)]
        public string Renk { get; set; }

        [StringLength(500)]
        public string Resim { get; set; }

        [StringLength(50)]
        public string Stok { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public string Detail { get; set; }
        public string Supplier_code { get; set; }
    }
}
