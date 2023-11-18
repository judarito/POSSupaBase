using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.ProductCategory
{
    [Table("public.ProductCategory")]
    public class ProductCategoryModel2: BaseModel
    {
        [PrimaryKey("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [Column("IdTenant")]
        public int IdTenant { get; set; }

        [Column("dt_Created")]
        public DateTime dt_Created { get; set; }
    }
}
