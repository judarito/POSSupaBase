using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Terceros
{
    public class TercerosDto:DtosBase
    {
        public string? Type { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public decimal Cupo { get; set; }
        public bool Active { get; set; }
    }
}
