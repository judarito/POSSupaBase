using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.DetalleFactura
{
    [Table("public.DetalleFactura")]
    public class DetalleFactura: BaseModel
    {
        [PrimaryKey("Id")]
        public int Id { get; set; }

        [Column("Cantidad")]
        public decimal Cantidad { get; set; }
       
        [Column("Costo")]
        public decimal Costo { get; set; }
        
        [Column("PvP")]
        public decimal PvP { get; set; }
       
        [Column("IdCabeceraFactura")]
        public int IdCabeceraFactura { get; set; }

        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [Column("IdTenant")]
        public int IdTenant { get; set; }

        [Column("dt_Created")]
        public DateTime? dt_Created { get; set; }
    }
}
