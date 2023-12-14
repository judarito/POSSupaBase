using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Facturas
{
    public class DetalleFacturaModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal PVP { get; set; }
    }
}
