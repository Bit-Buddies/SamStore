using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.ShoppingCart.Application.Models
{
    public record ShoppingCartDTO
    {
        public Guid Id { get; set; }
        public Guid CostumerId { get; set; }
        public decimal Total { get; set; }
        public List<ShoppingCartItemDTO> Items { get; set; } 
    }
}
