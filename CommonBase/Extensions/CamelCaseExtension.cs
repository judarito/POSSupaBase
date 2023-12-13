using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Extensions
{
    public static class CamelCaseExtension
    {
        public static string ToCamelCase(this string str) =>
           char.ToLowerInvariant(str[0]) + str[1..];
    }
}
