using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Facturas
{
    public class FacturasModel
    {
        public List<FacturaModel>? facturas { get; set; }
        public int rowcount { get; set; }
    }
}
