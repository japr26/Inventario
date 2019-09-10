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

    [Table("Proveedor")]
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            Articulo = new HashSet<Articulo>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Articulo> Articulo { get; set; }

        public List<Proveedor> Listar()
        {
            var proveedores = new List<Proveedor>();

            try
            {
                using (var ctx = new MardomContext())
                {
                    proveedores = ctx.Proveedor.ToList();
                }
            }
            catch
            {
                throw;
            }

            return proveedores;
        }

        public Proveedor Obtener(int id)
        {

            var proveedor = new Proveedor();

            try
            {
                using (var ctx = new MardomContext())
                {
                    proveedor = ctx.Proveedor.Where(x => x.Id == id).SingleOrDefault();
                }
            }
            catch
            {
                throw;
            }

            return proveedor;
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
                    }
                    else
                    {
                        ctx.Entry(this).State = EntityState.Added;
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

                    contar = ctx.Database.SqlQuery<int>("SELECT COUNT(ProveedorId) FROM Articulo WHERE ProveedorId = @id",
                                                        new SqlParameter("id", this.Id)).FirstOrDefault();

                    if (contar <= 0)
                    {

                        ctx.Entry(this).State = EntityState.Deleted;

                        ctx.SaveChanges();
                    }
                    else
                    {
                        throw new MiExcepcion("Este Proveedor no es posible eliminarlo porque hay articulos con el");
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
