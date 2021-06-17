namespace ZorePazaryeriConverter.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XmlImage")]
    public partial class XmlImage
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Img_item { get; set; }

        public int? ProductID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public virtual XmlProduct XmlProduct { get; set; }
    }
}
