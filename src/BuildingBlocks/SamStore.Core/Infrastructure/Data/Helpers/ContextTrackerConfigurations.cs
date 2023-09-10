using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SamStore.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.Infrastructure.Data.Helpers
{
    public static class ContextTrackerConfigurations
    {
        public static void MapChanges(ChangeTracker changeTracker)
        {
            var entries = changeTracker.Entries<Entity>();

            foreach (EntityEntry<Entity> entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Detached: break;
                    case EntityState.Unchanged: break;
                    case EntityState.Deleted:
                        entry.Entity.Removed = true;
                        entry.Entity.AlteredAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.AlteredAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.AlteredAt = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
