using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public DateTime AlteredAt { get; protected set; } = DateTime.Now;
        public bool Removed { get; protected set; } = false;

        public override string ToString()
        {
            return $"{GetType().Name} [Id {Id}]";
        }
    }
}
