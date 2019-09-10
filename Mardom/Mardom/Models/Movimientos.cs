namespace Mardom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movimientos
    {
        public int Id { get; set; }

        public int ArticuloId { get; set; }

        public int AlmacenId { get; set; }

        public int Cantidad { get; set; }

        public int TipoMovimientoId { get; set; }

        public DateTime Fecha { get; set; }

        public virtual Almacen_Articulo Almacen_Articulo { get; set; }

        public virtual TipoMovimiento TipoMovimiento { get; set; }
    }
}
