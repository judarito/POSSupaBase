using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.CabeceraFactura
{
    [Table("public.CabeceraFactura")]
    public class CabeceraFactura: BaseModel
    {

        [PrimaryKey("Id")]
        public int Id { get; set; }

        [Column("FechaFactura")]
        public DateTime? FechaFactura { get; set; }

        [Column("IdTipoMovimiento")]
        public int IdTipoMovimiento { get; set; }


        [Column("IdTipoPago")]
        public int IdTipoPago { get; set; }

        [Column("IdTercero")]
        public int IdTercero { get; set; }

        [Column("IdEstadoEntrega")]
        public int IdEstadoEntrega { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [Column("IdTenant")]
        public int IdTenant { get; set; }

        [Column("dt_Created")]
        public DateTime? dt_Created { get; set; }
    }
}
