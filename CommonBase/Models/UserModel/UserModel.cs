using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.UserModel
{
    [Table("public.User")]
    public class UserModel : BaseModelApp
    {
        [PrimaryKey("idUser")]
        public int idUser { get; set; }
        [Column("DisplayName")]
        public string DisplayName { get; set; }
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("idTenant")]
        public int idTenant { get; set; }
        [Column("Active")]
        public bool Active { get; set; }
        [Column("IdUserSupabase")]
        public Guid IdUserSupabase { get; set; }

    }
}
