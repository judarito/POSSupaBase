using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.TipoMovimiento
{
    public class TipoMovimientoDto:DtosBase
    {
        public int Cardinalidad { get; set; }

        public string? Code { get; set; }

        public bool Active { get; set; }
    }
}
