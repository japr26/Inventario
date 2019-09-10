namespace Mardom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;
    using Mardom.Utilidades;

    [Table("Almacen")]
    public partial class Almacen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Almacen()
        {
            Almacen_Articulo = new HashSet<Almacen_Articulo>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(300)]
        public string Ubicacion { get; set; }

        public int Capacidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Almacen_Articulo> Almacen_Articulo { get; set; }

        public List<Almacen> Listar()
        {
            var alamacenes = new List<Almacen>();

            try
            {
                using (var ctx = new MardomContext())
                {
                    alamacenes = ctx.Almacen.ToList();
                }
            }
            catch
            {
                throw;
            }

            return alamacenes;
        }

        public Almacen Obtener(int id)
        {

            var almacen = new Almacen();

            try
            {
                using (var ctx = new MardomContext())
                {
                    almacen = ctx.Almacen.Where(x => x.Id == id).SingleOrDefault();
                }
            }
            catch
            {
                throw;
            }

            return almacen;
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
                    contar = ctx.Database.SqlQuery<int>("SELECT COUNT(AlmacenId) FROM Almacen_Articulo WHERE AlmacenId = @id",
                                     new SqlParameter("id", this.Id)).FirstOrDefault();

                    if (contar <= 0)
                    {

                        ctx.Entry(this).State = EntityState.Deleted;

                        ctx.SaveChanges();
                    }
                    else
                    {
                        throw new MiExcepcion("Este almacen no es posible eliminarlo porque hay articulos en el");
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
