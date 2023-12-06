using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.TipoMovimiento
{
    [Table("public.TipoMovimiento")]
    public class TipoMovimiento: BaseModelApp
    {

        [Column("Cardinalidad")]
        public int Cardinalidad { get; set; }

        [Column("Active")]
        public bool Active { get; set; }
    }
}
