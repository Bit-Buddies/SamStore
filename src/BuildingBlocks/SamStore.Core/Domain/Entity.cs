using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
        public DateTime AlteredAt { get; set; } = DateTime.MinValue;
        public bool Removed { get; set; } = false;

        public override string ToString()
        {
            return $"{GetType().Name} [Id {Id}]";
        }
    }
}
