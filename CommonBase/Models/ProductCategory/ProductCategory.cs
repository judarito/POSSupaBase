﻿using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Models.ProductCategory
{
    [Table("public.ProductCategory")]
    public class ProductCategory : BaseModelApp
    {

        [Column("Active")]
        public bool Active { get; set; }

        

    }
}
