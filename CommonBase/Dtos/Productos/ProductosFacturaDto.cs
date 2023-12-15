using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Productos
{
    public class ProductosFacturaDto
    {
        public ProductosFacturaDto() {
            this.PvP = 0;
            this.Cantidad = 0;
            this.Id = 0;
            this.Name = "";
            this.UseStok = true;
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PvP { get; set; }

        public bool? UseStok { get; set; }

    }
}
