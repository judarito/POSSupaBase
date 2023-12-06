using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.CabeceraFactura
{
    public class CabeceraFacturaDto
    {
        public int Id { get; set; }
        public DateTime? FechaFactura { get; set; }
        public int IdTipoMovimiento { get; set; }
        public string? NombreMovimiento { get; set; }
        public int IdTipoPago { get; set; }
        public string? NombreTipoPago { get; set; }
        public int IdTercero { get; set; }
        public string? NombreTercero { get; set; }
        public int IdEstadoEntrega { get; set; }
        public bool Active { get; set; }
        public int IdTenant { get; set; }
        public DateTime? dt_Created { get; set; }
    }
}
