using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.UnidadMedida
{
    [Table("UnidadMedida")]
    public class UnidadMedida: BaseModelApp
    {
        [Column("Code")]
        public string? Code { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

    }
}
