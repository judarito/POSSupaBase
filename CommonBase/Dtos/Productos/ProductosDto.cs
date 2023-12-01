using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Productos
{
    public class ProductosDto : DtosBase
    {

        public string? Code { get; set; }
        public string? Description { get; set; }
        public int MinQuantity { get; set; }
        public bool UseStok { get; set; }
        public string? ImagePath { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdProductCategory { get; set; }
        public bool Active { get; set; }
    }
}
