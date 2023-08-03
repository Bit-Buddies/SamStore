using SamStore.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SamStore.Core.Extensions
{
    public static class StringExtensions
    {
        public static string GetOnlyNumbers(this string str) 
        {
            return Regex.Replace(str, @"[^\d]", "");
        }
    }
}
