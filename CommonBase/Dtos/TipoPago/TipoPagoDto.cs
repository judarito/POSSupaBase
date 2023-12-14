using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.TipoPago
{
    public class TipoPagoDto:DtosBase
    {
       
        public string? Cardinalidad { get; set; }
        public string? Code { get; set; }
       
        public bool Active { get; set; }
    }
}
