using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.Infrastructure.Data.Extensions
{
    public static class DefaultTableConfigurations
    {
        public static void UseDefaultTableConfiguration(this ModelBuilder modelBuilder) {
            var properties = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties());

            foreach (var prop in properties.Where(p => p.ClrType == typeof(string)))
            {
                prop.SetColumnType("VARCHAR(100)");
            }

            foreach (var prop in properties.Where(p => p.ClrType == typeof(decimal)))
            {
                prop.SetColumnType("DECIMAL(65,2)");
            }

            foreach (var prop in properties.Where(p => p.ClrType == typeof(DateTime)))
            {
                prop.SetColumnType("DATETIME");
            }
        }

        public static void UseDefaultContextConfiguration(this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}
