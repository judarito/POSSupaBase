using CommonBase.Dtos.CabeceraFactura;
using CommonBase.Dtos.DetalleFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos
{
    public class FacturaDto
    {
        public CabeceraFacturaDto? CabeceraFactura { get; set; }
        public List<DetalleFacturaDto>? DetalleFactura { get; set; }
    }
}
