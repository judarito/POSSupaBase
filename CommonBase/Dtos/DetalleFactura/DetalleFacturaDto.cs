using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.DetalleFactura
{
    public class DetalleFacturaDto
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal PvP { get; set; }
        public int IdCabeceraFactura { get; set; }
        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public bool Active { get; set; }
        public int IdTenant { get; set; }
        public DateTime? dt_Created { get; set; }
    }
}
