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
        //public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<detail_bill> detail_bill { get; set; }
        public virtual DbSet<type_user> type_user { get; set; }
        public virtual DbSet<product> products { get; set; }
        //public virtual DbSet<provider> providers { get; set; }
        public virtual DbSet<type_product> type_product { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<buy> buy { get; set; }
        public virtual DbSet<detail_buy> detail_buy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<type_user>()
                .Property(e => e.TYPE_USER)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.NAME_PRODUCT)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.ACTIVE);

            //modelBuilder.Entity<provider>()
            //    .Property(e => e.NAME_PROVIDER)
            //    .IsUnicode(false);

            //modelBuilder.Entity<provider>()
            //    .Property(e => e.ACTIVE);

            modelBuilder.Entity<type_product>()
                .Property(e => e.NAME_TYPE_PRODUCT)
                .IsUnicode(false);

            modelBuilder.Entity<type_product>()
                .Property(e => e.ACTIVE);

            modelBuilder.Entity<users>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.PASS)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.USERS)
                .IsUnicode(false);

            //modelBuilder.Entity<users>()
            //    .Property(e => e.CHARGE)
            //    .IsUnicode(false);
        }
    }
}
