namespace ZorePazaryeriConverter.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JsonProduct")]
    public partial class JsonProduct
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string SIRA { get; set; }

        [StringLength(50)]
        public string STOKKODU { get; set; }

        [StringLength(150)]
        public string MALINCINSI { get; set; }

        [StringLength(50)]
        public string KOD1 { get; set; }

        [StringLength(50)]
        public string KOD2 { get; set; }

        [StringLength(50)]
        public string KOD3 { get; set; }

        [StringLength(50)]
        public string KOD4 { get; set; }

        [StringLength(50)]
        public string KOD5 { get; set; }

        [StringLength(50)]
        public string KOD6 { get; set; }

        [StringLength(50)]
        public string KOD7 { get; set; }

        [StringLength(50)]
        public string KOD8 { get; set; }

        [StringLength(50)]
        public string KOD9 { get; set; }

        [StringLength(50)]
        public string KOD10 { get; set; }

        [StringLength(50)]
        public string KOD11 { get; set; }

        [StringLength(50)]
        public string KOD12 { get; set; }

        [StringLength(50)]
        public string KOD13 { get; set; }

        [StringLength(50)]
        public string KOD14 { get; set; }

        [StringLength(50)]
        public string KOD15 { get; set; }

        [StringLength(50)]
        public string KOD16 { get; set; }

        [StringLength(50)]
        public string KOD17 { get; set; }

        [StringLength(50)]
        public string KOD18 { get; set; }

        [StringLength(50)]
        public string KOD19 { get; set; }

        [StringLength(50)]
        public string KOD20 { get; set; }

        [StringLength(50)]
        public string SATISFIYATI1 { get; set; }

        [StringLength(50)]
        public string SATISFIYATI2 { get; set; }

        [StringLength(50)]
        public string SATISFIYATI3 { get; set; }

        [StringLength(50)]
        public string SATISFIYATI4 { get; set; }

        [StringLength(50)]
        public string SATISFIYATI5 { get; set; }

        [StringLength(50)]
        public string SATISFIYATI6 { get; set; }

        [StringLength(50)]
        public string BARCODE { get; set; }

        public decimal? ENVANTER { get; set; }
    }
}
