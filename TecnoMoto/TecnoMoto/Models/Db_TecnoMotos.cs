namespace TecnoMoto.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Db_TecnoMotos : DbContext
    {
        public Db_TecnoMotos()
            : base("name=Db_TecnoMotos")
        {
        }

        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<detail_bill> detail_bill { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<provider> providers { get; set; }
        public virtual DbSet<stock> stocks { get; set; }
        public virtual DbSet<type_product> type_product { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<client>()
                .Property(e => e.DOCUMENT)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.TYPE_DOCUMENT)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.NAME_CLIENT)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.NAME_PRODUCT)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.ACTIVE)
                .IsUnicode(false);

            modelBuilder.Entity<provider>()
                .Property(e => e.NAME_PROVIDER)
                .IsUnicode(false);

            modelBuilder.Entity<provider>()
                .Property(e => e.ACTIVE)
                .IsUnicode(false);

            modelBuilder.Entity<type_product>()
                .Property(e => e.NAME_TYE_PRODUCT)
                .IsUnicode(false);

            modelBuilder.Entity<type_product>()
                .Property(e => e.ACTIVE)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.PASS)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.USERS)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.CARGO)
                .IsUnicode(false);
        }
    }
}
