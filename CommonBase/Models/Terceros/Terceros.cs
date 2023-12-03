using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.Terceros
{
    [Table("public.Terceros")]
    public class Terceros: BaseModelApp
    {
        [Column("Type")]
        public string Type { get; set; }

        [Column("Telefono")]
        public string Telefono { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Cupo")]
        public decimal Cupo { get; set; }

        [Column("Active")]
        public bool Active { get; set; }
    }
}
