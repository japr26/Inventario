namespace Mardom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.SqlClient;
    using Mardom.Utilidades;

    [Table("Articulo")]
    public partial class Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulo()
        {
            Almacen_Articulo = new HashSet<Almacen_Articulo>();
            Marca = new HashSet<Marca>();
            Proveedor = new HashSet<Proveedor>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        public decimal PrecioCompra { get; set; }

        public int CategoriaId { get; set; }

        public int MarcaId { get; set; }

        public int ProveedorId { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? PrecioVenta1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Almacen_Articulo> Almacen_Articulo { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Marca> Marca { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor> Proveedor { get; set; }

        public List<Articulo> Listar()
        {
            var articulos = new List<Articulo>();

            try
            {
                using (var ctx = new MardomContext())
                {
                    articulos = ctx.Articulo.Include(x => x.Categoria)
                                            .Include(x => x.Marca)
                                            .Include(x => x.Proveedor)
                                            .ToList();
                }
            }
            catch
            {
                throw;
            }

            return articulos;
        }

        public Articulo Obtener(int id)
        {

            var articulo = new Articulo();

            try
            {
                using (var ctx = new MardomContext())
                {
                    articulo = ctx.Articulo.Include(x => x.Categoria)
                                           .Include(x => x.Marca)
                                           .Include(x => x.Proveedor)
                                           .Where(x => x.Id == id).SingleOrDefault();
                }
            }
            catch
            {
                throw;
            }

            return articulo;
        }

        public void Guardar()
        {

            try
            {
                using (var ctx = new MardomContext())
                {

                    if (this.Id > 0)
                    {
                        ctx.Entry(this).State = EntityState.Modified;

                        ctx.Database.ExecuteSqlCommand("DELETE FROM Marca_Articulo WHERE ArticuloId = @id", new SqlParameter("id", this.Id));
                        ctx.Database.ExecuteSqlCommand("INSERT INTO Marca_Articulo VALUES(@articuloId, @marcaId)", new SqlParameter("articuloId", this.Id), new
                                                       SqlParameter("marcaId", this.MarcaId));

                        ctx.Database.ExecuteSqlCommand("DELETE FROM Proveedor_Articulo WHERE ArticuloId = @id", new SqlParameter("id", this.Id));
                        ctx.Database.ExecuteSqlCommand("INSERT INTO Proveedor_Articulo VALUES(@articuloId, @ProveedorId)", new SqlParameter("articuloId", this.Id), new
                                                       SqlParameter("ProveedorId", this.ProveedorId));
                    }
                    else
                    {
                        ctx.Entry(this).State = EntityState.Added;

                        ctx.SaveChanges();

                        ctx.Database.ExecuteSqlCommand("INSERT INTO Marca_Articulo VALUES(@articuloId, @marcaId)", new SqlParameter("articuloId", this.Id), new
                                                       SqlParameter("marcaId", this.MarcaId));

                        ctx.Database.ExecuteSqlCommand("INSERT INTO Proveedor_Articulo VALUES(@articuloId, @ProveedorId)", new SqlParameter("articuloId", this.Id), new
                                                       SqlParameter("ProveedorId", this.ProveedorId));

                    }

                    ctx.SaveChanges();
                }

            }
            catch
            {
                throw;
            }
        }

        public void Eliminar()
        {

            var contar = 0;

            try
            {
                using (var ctx = new MardomContext())
                {
                    contar = ctx.Database.SqlQuery<int>("SELECT COUNT(ArticuloId) FROM Almacen_Articulo WHERE ArticuloId = @id",
                                                         new SqlParameter("id", this.Id)).FirstOrDefault();

                    if (contar <= 0)
                    {
                        ctx.Database.ExecuteSqlCommand("DELETE FROM Marca_Articulo WHERE ArticuloId = @id", new SqlParameter("id", this.Id));
                        ctx.Database.ExecuteSqlCommand("DELETE FROM Proveedor_Articulo WHERE ArticuloId = @id", new SqlParameter("id", this.Id));

                        ctx.SaveChanges();

                        ctx.Entry(this).State = EntityState.Deleted;

                        ctx.SaveChanges();
                    }
                    else
                    {
                        throw new MiExcepcion("Este articulo no es posible eliminarlo porque se ha sido registrado en algun(os) almacen(es)");
                    }

                }
            }
            catch
            {
                throw;
            }

        }
    }
}
