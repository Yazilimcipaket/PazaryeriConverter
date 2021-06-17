namespace ZorePazaryeriConverter.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ZoreWeb")]
    public partial class ZoreWeb
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        public string Image { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public string Detail { get; set; }

        [StringLength(50)]
        public string Type1 { get; set; }

        [StringLength(500)]
        public string Name { get; set; }
    }
}
