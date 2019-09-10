namespace Mardom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Transacciones
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public string Descripcion { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Almacen { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cantidad { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Movimiento { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime Fecha { get; set; }

        public List<Transacciones> Listar()
        {
            var transacciones = new List<Transacciones>();

            try
            {
                using (var ctx = new MardomContext())
                {
                    transacciones = ctx.Transacciones.ToList();
                }
            }
            catch
            {
                throw;
            }

            return transacciones;
        }
    }

}
