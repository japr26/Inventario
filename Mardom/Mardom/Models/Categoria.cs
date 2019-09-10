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

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Articulo = new HashSet<Articulo>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Articulo> Articulo { get; set; }

        public List<Categoria> Listar()
        {
            var categorias = new List<Categoria>();

            try
            {
                using (var ctx = new MardomContext())
                {
                    categorias = ctx.Categoria.ToList();
                }
            }
            catch
            {
                throw;
            }

            return categorias;
        }

        public Categoria Obtener(int id)
        {

            var categoria = new Categoria();

            try
            {
                using (var ctx = new MardomContext())
                {
                    categoria = ctx.Categoria.Where(x => x.Id == id).SingleOrDefault();
                }
            }
            catch
            {
                throw;
            }

            return categoria;
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

                    contar = ctx.Database.SqlQuery<int>("SELECT COUNT(CategoriaId) FROM Articulo WHERE CategoriaId = @id",
                                                        new SqlParameter("id", this.Id)).FirstOrDefault();

                    if (contar <= 0)
                    {

                        ctx.Entry(this).State = EntityState.Deleted;

                        ctx.SaveChanges();
                    }
                    else
                    {
                        throw new MiExcepcion("Este Categoria no es posible eliminarla porque hay articulos con ella");
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
