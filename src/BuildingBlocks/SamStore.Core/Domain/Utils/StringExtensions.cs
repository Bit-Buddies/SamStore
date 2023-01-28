using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.Domain.Utils
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value); 
        }

        public static string OnlyNumbers(this string value)
        {
            return new string(value.Where(char.IsDigit).ToArray());
        }
    }
}
