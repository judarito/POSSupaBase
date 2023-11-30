using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.UnidadMedida
{
    public class UnidadMedidaDto : DtosBase
    {
        public string? Code { get; set; }

        public bool Active { get; set; }
    }
}
