namespace WebFacturacionPApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("inventario")]
    public partial class inventario
    {
        public int id { get; set; }

        public int? FkIdProducuto { get; set; }

        public int? unidades { get; set; }

        public virtual productos productos { get; set; }
    }
}
