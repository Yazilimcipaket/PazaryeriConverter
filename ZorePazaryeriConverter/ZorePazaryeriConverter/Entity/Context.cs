namespace ZorePazaryeriConverter.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context3")
        {
        }

        public virtual DbSet<JsonProduct> JsonProduct { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Toplu> Toplu { get; set; }
        public virtual DbSet<XmlImage> XmlImage { get; set; }
        public virtual DbSet<XmlProduct> XmlProduct { get; set; }
        public virtual DbSet<XmlSubProduct> XmlSubProduct { get; set; }
        public virtual DbSet<ZoreWeb> ZoreWeb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JsonProduct>()
                .Property(e => e.ENVANTER)
                .HasPrecision(18, 3);

            modelBuilder.Entity<XmlProduct>()
                .HasMany(e => e.XmlImage)
                .WithOptional(e => e.XmlProduct)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<XmlProduct>()
                .HasMany(e => e.XmlSubProduct)
                .WithOptional(e => e.XmlProduct)
                .HasForeignKey(e => e.ProductID);
        }
    }
}
