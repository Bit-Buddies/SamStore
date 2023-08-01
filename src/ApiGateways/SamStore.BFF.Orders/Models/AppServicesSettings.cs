namespace SamStore.BFF.Orders.Models
{
    public class AppServicesSettingsDTO
    {
        public string CatalogBaseURL { get; set; }
        public string ProductBaseURL { get; set; }
        public string OrderBaseURL { get; set; }
        public string ShoppingCartBaseURL { get; set; }
        public string PaymentBaseURL { get; set; }
    }
}
