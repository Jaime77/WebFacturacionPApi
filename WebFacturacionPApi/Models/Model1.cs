namespace WebFacturacionPApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<inventario> inventario { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<ventas> ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<clientes>()
                .Property(e => e.identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .HasMany(e => e.ventas)
                .WithOptional(e => e.clientes)
                .HasForeignKey(e => e.FkIdCliente);

            modelBuilder.Entity<productos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.referencia)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .HasMany(e => e.inventario)
                .WithOptional(e => e.productos)
                .HasForeignKey(e => e.FkIdProducuto);

            modelBuilder.Entity<productos>()
                .HasMany(e => e.ventas)
                .WithOptional(e => e.productos)
                .HasForeignKey(e => e.FkIdProducto);
        }
    }
}
