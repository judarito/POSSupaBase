using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Productos
{
    public class ProductosFullDataDto: ProductosDto
    {
        public decimal? Cantidad { get; set; }
        public decimal? PvP { get; set;}
    }
}
