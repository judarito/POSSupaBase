using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.Productos
{
    [Table("public.Productos")]
    public class Productos : BaseModelApp
    {

        [Column("Code")]
        public string? Code { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("MinQuantity")]
        public int MinQuantity { get; set; }

        [Column("UseStok")]
        public bool UseStok { get; set; }

        [Column("ImagePath")]
        public string? ImagePath { get; set; }

        [Column("IdUnidadMedida")]
        public int IdUnidadMedida { get; set; }

        [Column("IdProductCategory")]
        public int IdProductCategory { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [Column("Cantidad")]
        public decimal Cantidad { get; set; }

        [Column("PvP")]
        public decimal PvP { get; set; }

        [Column("Costo")]
        public decimal Costo { get; set; }
    }
}
