namespace Mardom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Inventario")]
    public partial class Inventario
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string Descripcion { get; set; }

        public int? Cantidad { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Almacen { get; set; }

        public int? Capacidad { get; set; }

        public List<Inventario> Listar()
        {
            var inventario = new List<Inventario>();

            try
            {
                using (var ctx = new MardomContext())
                {
                    inventario = ctx.Inventario.ToList();
                }
            }
            catch
            {
                throw;
            }

            return inventario;
        }
    }
}
