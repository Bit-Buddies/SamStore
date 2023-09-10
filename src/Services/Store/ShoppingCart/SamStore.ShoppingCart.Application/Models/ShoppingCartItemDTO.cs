﻿namespace SamStore.ShoppingCart.Application.Models
{
    public record ShoppingCartItemDTO
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
    }
}
