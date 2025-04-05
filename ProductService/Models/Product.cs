namespace ProductService.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int ProviderId { get; set; }
        public string? ProviderName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}