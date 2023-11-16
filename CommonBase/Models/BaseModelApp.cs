using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models
{
    public class BaseModelApp: BaseModel
    {
        [Column("dt_Created")]
        public DateTime? dt_Created { get; set; }
    }
}
