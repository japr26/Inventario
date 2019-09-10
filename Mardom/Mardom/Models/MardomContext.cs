namespace Mardom.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MardomContext : DbContext
    {
        public MardomContext()
            : base("name=MardomContext")
        {
        }

        public virtual DbSet<Almacen> Almacen { get; set; }
        public virtual DbSet<Almacen_Articulo> Almacen_Articulo { get; set; }
        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen>()
                .HasMany(e => e.Almacen_Articulo)
                .WithRequired(e => e.Almacen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Almacen_Articulo>()
                .HasMany(e => e.Movimientos)
                .WithRequired(e => e.Almacen_Articulo)
                .HasForeignKey(e => new { e.ArticuloId, e.AlmacenId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.PrecioCompra)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.PrecioVenta1)
                .HasPrecision(12, 3);

            modelBuilder.Entity<Articulo>()
                .HasMany(e => e.Almacen_Articulo)
                .WithRequired(e => e.Articulo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Articulo>()
                .HasMany(e => e.Marca)
                .WithMany(e => e.Articulo)
                .Map(m => m.ToTable("Marca_Articulo").MapLeftKey("ArticuloId").MapRightKey("MarcaId"));

            modelBuilder.Entity<Articulo>()
                .HasMany(e => e.Proveedor)
                .WithMany(e => e.Articulo)
                .Map(m => m.ToTable("Proveedor_Articulo").MapLeftKey("ArticuloId").MapRightKey("ProveedorId"));

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Articulo)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoMovimiento>()
                .HasMany(e => e.Movimientos)
                .WithRequired(e => e.TipoMovimiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);
        }
    }
}
