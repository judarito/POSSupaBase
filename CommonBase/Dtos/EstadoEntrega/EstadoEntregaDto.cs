using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.EstadoEntrega
{
    public class EstadoEntregaDto:DtosBase
    {
        public string? Cardinalidad { get; set; }
        public bool Active { get; set; }
    }
}
