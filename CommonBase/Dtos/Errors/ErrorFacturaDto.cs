using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Dtos.Errors
{
    public class ErrorFacturaDto
    {
        public string? code {  get; set; }
        public string? message { get; set; }
       public string? details { get; set; }
        public string? hint { get; set; }
    }
}
