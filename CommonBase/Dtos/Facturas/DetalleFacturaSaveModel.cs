using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Facturas
{
    public class DetalleFacturaSaveModel
    {
        public decimal cantidad { get; set; }
        public decimal costo { get; set; }
        public decimal pvp { get; set; }
        public int idproducto { get; set; }

    }
}
