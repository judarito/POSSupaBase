using CommonBase.Dtos.EstadoEntrega;
using CommonBase.Dtos.Productos;
using CommonBase.Dtos.Terceros;
using CommonBase.Dtos.TipoMovimiento;
using CommonBase.Dtos.TipoPago;
using CommonBase.Models.TipoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Facturas
{
    public class DatosAdicionalesFactura
    {
        public List<TercerosDto>? Terceros { get; set; }
        public List<TipoPagoDto>? TiposPago { get; set; }
        public List<EstadoEntregaDto>? Estados { get; set; }
        public List<ProductosFacturaDto>? Productos { get; set; }
        public List<TipoMovimientoDto>? TipoMov { get; set; }
    }
}
