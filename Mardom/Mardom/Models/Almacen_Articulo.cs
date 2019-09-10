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
    using PagedList;
    using Mardom.Utilidades;

    public partial class Almacen_Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Almacen_Articulo()
        {
            Movimientos = new HashSet<Movimientos>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArticuloId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlmacenId { get; set; }

        public int Cantidad { get; set; }

        public virtual Almacen Almacen { get; set; }

        public virtual Articulo Articulo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimientos> Movimientos { get; set; }

        public List<Almacen_Articulo> Listar()
        {

            var almArt = new List<Almacen_Articulo>();

            try
            {
                using (var ctx = new MardomContext())
                {
                    almArt = ctx.Almacen_Articulo.Include(x => x.Articulo)
                                                 .Include(x => x.Almacen).ToList();
                }
            }
            catch
            {
                throw;
            }

            return almArt;
        }

        public List<Almacen_Articulo> Obtener(int id)
        {

            var almArt = new List<Almacen_Articulo>();

            try
            {
                using (var ctx = new MardomContext())
                {
                    almArt = ctx.Almacen_Articulo.Include(x => x.Articulo)
                                                 .Include(x => x.Almacen)
                                                 .Where(x => x.ArticuloId == id).ToList();
                }
            }
            catch
            {
                throw;
            }

            return almArt;
        }

        public Almacen_Articulo Obtener2(int id1, int id2)
        {

            var almArt = new Almacen_Articulo();

            try
            {
                using (var ctx = new MardomContext())
                {
                    almArt = ctx.Almacen_Articulo.Include(x => x.Articulo)
                                                 .Include(x => x.Almacen)
                                                 .Where(x => x.ArticuloId == id1 && x.AlmacenId == id2).SingleOrDefault();
                }
            }
            catch
            {
                throw;
            }

            return almArt;
        }

        public void Guardar()
        {
            var cantidadDB = 0;

            var cantidadArticulo = 0;

            var cantidad = 0;

            var cantidadTotal = 0;

            var capacidad = 0;

            try
            {
                using (var ctx = new MardomContext())
                {
                    cantidadDB = ctx.Database.SqlQuery<int>("select sum(Cantidad) from Almacen_Articulo where AlmacenId = @id group by AlmacenId",
                                                            new SqlParameter("id", this.AlmacenId)).FirstOrDefault();

                    cantidadArticulo = ctx.Database.SqlQuery<int>("SELECT Cantidad FROM Almacen_Articulo WHERE ArticuloId = @id AND AlmacenId = @id2",
                                                                 new SqlParameter("id", this.ArticuloId), new SqlParameter("id2", this.AlmacenId)).FirstOrDefault();

                    cantidad = this.Cantidad;

                    cantidadTotal = cantidad + cantidadDB;

                    this.Cantidad = cantidadArticulo + cantidad;

                    capacidad = ctx.Almacen.Where(x => x.Id == this.AlmacenId).SingleOrDefault().Capacidad;

                    if (cantidadTotal > capacidad)
                    {
                        throw new MiExcepcion("La cantidad ingresada (" + cantidad + ") excede a la capcidad ("+ capacidad +") del almacen ya que en el mismo" +
                            " hay ("+cantidadDB +") articulos, o el articulo ya esta asignado en este almacen");
                    }
                    else
                    {
                        ctx.Entry(this).State = EntityState.Added;

                        ctx.SaveChanges();
                    }

                }

            }
            catch
            {
                throw;
            }
        }


        public void Entrar()
        {

            var cantidadDB = 0;

            var cantidadArticulo = 0;

            var cantidad = 0;

            var cantidadTotal = 0;

            var capacidad = 0;

            try
            {
                using (var ctx = new MardomContext())
                {

                    //cantidadDB = ctx.Almacen_Articulo.Where(x => x.ArticuloId == this.ArticuloId && x.AlmacenId == this.AlmacenId).SingleOrDefault().Cantidad;

                    cantidadDB = ctx.Database.SqlQuery<int>("select sum(Cantidad) from Almacen_Articulo where AlmacenId = @id group by AlmacenId",
                                                             new SqlParameter("id", this.AlmacenId)).FirstOrDefault();

                    cantidadArticulo = ctx.Database.SqlQuery<int>("SELECT Cantidad FROM Almacen_Articulo WHERE ArticuloId = @id AND AlmacenId = @id2",
                                                                 new SqlParameter("id", this.ArticuloId), new SqlParameter("id2", this.AlmacenId)).FirstOrDefault();

                    cantidad = this.Cantidad;

                    cantidadTotal = cantidad + cantidadDB;

                    this.Cantidad = cantidadArticulo + cantidad;

                    capacidad = ctx.Almacen.Where(x => x.Id == this.AlmacenId).SingleOrDefault().Capacidad;

                    if (cantidadTotal > capacidad)
                    {

                        throw new MiExcepcion("La cantidad soportada por este almacen es " + capacidad + " articulos y este cuenta con "
                                            + cantidadDB + " articulos debe ingresar una cantidad menor" + cantidad);

                    }
                    else
                    {

                        ctx.Entry(this).State = EntityState.Modified;

                        ctx.SaveChanges();

                        ctx.Database.ExecuteSqlCommand("INSERT INTO Movimientos VALUES(@articuloId, @almacenId, @cantidad, @tipoMovimiento, @fecha)",
                                new SqlParameter("articuloId", this.ArticuloId),
                                new SqlParameter("almacenId", this.AlmacenId),
                                new SqlParameter("cantidad", cantidad),
                                new SqlParameter("tipoMovimiento", 1),
                                new SqlParameter("fecha", DateTime.Now));

                    }

                }

            }
            catch
            {
                throw;
            }
        }

        public void Sacar()
        {

            var cantidadDB = 0;

            var cantidadArticulo = 0;

            var cantidad = 0;

            var cantidadTotal = 0;

            try
            {
                using (var ctx = new MardomContext())
                {

                    //cantidadDB = ctx.Almacen_Articulo.Where(x => x.ArticuloId == this.ArticuloId && x.AlmacenId == this.AlmacenId).SingleOrDefault().Cantidad;

                    cantidadDB = ctx.Database.SqlQuery<int>("select sum(Cantidad) from Almacen_Articulo where AlmacenId = @id group by AlmacenId",
                                                             new SqlParameter("id", this.AlmacenId)).FirstOrDefault();

                    cantidadArticulo = ctx.Database.SqlQuery<int>("SELECT Cantidad FROM Almacen_Articulo WHERE ArticuloId = @id AND AlmacenId = @id2",
                                                                 new SqlParameter("id", this.ArticuloId), new SqlParameter("id2", this.AlmacenId)).FirstOrDefault();

                    cantidad = this.Cantidad;

                    cantidadTotal = cantidadDB - cantidad;

                    this.Cantidad = cantidadArticulo - cantidad;

                    if (cantidadTotal <= 0)
                    {

                        throw new MiExcepcion("La cantidad disponible en este almacen es " + cantidadDB + " Ingrese una cantidad Menor a" + cantidad);

                    }
                    else
                    {

                        ctx.Entry(this).State = EntityState.Modified;

                        ctx.SaveChanges();

                        ctx.Database.ExecuteSqlCommand("INSERT INTO Movimientos VALUES(@articuloId, @almacenId, @cantidad, @tipoMovimiento, @fecha)",
                                                        new SqlParameter("articuloId", this.ArticuloId),
                                                        new SqlParameter("almacenId", this.AlmacenId),
                                                        new SqlParameter("cantidad", cantidad),
                                                        new SqlParameter("tipoMovimiento", 2),
                                                        new SqlParameter("fecha", DateTime.Now));
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
