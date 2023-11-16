using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.Tenant
{
    [Table("public.Tenant")]
    public class TenantModel: BaseModel
    {
        [PrimaryKey("idTenant")]
        public int idTenant { get; set; }
        [Column("Name")]
        public string Name { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Telephone")]
        public string Telephone { get; set; }


        [Column("Active")]
        public bool Active { get; set; }

        [Column("dt_Created")]
        public DateTime dt_Created { get; set; }
    }
}
