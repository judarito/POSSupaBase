﻿using CommonBase.Models;
using Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.ProductCategory
{
    public class ProductCategoryDto: DtosBase
    {
        public bool Active { get; set; }
        
    }

}
