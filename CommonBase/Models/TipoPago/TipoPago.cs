using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.TipoPago
{
    [Table("public.TipoPago")]
    public class TipoPago:BaseModelApp
    {
        [Column("Code")]
        public string? Cardinalidad { get; set; }

        [Column("Active")]
        public bool Active { get; set; }
    }
}
