namespace WebFacturacionPApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ventas
    {
        public int id { get; set; }

        public int? FkIdProducto { get; set; }

        public int? cantidadProducto { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaVenta { get; set; }

        public int? FkIdCliente { get; set; }

        public virtual clientes clientes { get; set; }

        public virtual productos productos { get; set; }
    }
}
