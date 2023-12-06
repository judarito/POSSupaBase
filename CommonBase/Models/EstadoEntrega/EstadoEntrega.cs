using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.EstadoEntrega
{
    [Table("public.EstadoEntrega")]
    public class EstadoEntrega:BaseModelApp
    {
        [Column("Code")]
        public string? Cardinalidad { get; set; }

        [Column("Active")]
        public bool Active { get; set; }
    }
}
