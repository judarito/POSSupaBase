using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Facturas
{
    public class DetalleFacturaSaveUIModel: DetalleFacturaSaveModel
    {
        public string? Name { get; set; }
        public decimal Subtotal { get; set; }
    }
}
