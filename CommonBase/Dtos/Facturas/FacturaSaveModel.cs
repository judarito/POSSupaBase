using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Facturas
{
    public class FacturaSaveModel
    {
        public int Id { get; set; }
        public string? FechaFactura { get; set; }
        public string? FechaVencimiento { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int IdTipoPago { get; set; }
        public int IdTercero { get; set; }
        public int IdEstadoEntrega { get; set; }
        public int DiasVencimiento { get; set; }
        public List<DetalleFacturaSaveModel>? Detalle { get; set; }

        
    }
}
