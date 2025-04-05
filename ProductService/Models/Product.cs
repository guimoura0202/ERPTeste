using Google.Cloud.Firestore;

namespace ProductService.Models
{
    [FirestoreData]
    public class Product
    {
        [FirestoreDocumentId]
        public string? Id { get; set; }
        [FirestoreProperty]
        public string? Name { get; set; }
        [FirestoreProperty]
        public double Price { get; set; }
        [FirestoreProperty]
        public int StockQuantity { get; set; }
        [FirestoreProperty]
        public string[]? ProviderId { get; set; }
        [FirestoreProperty]
        public string? Description { get; set; }
        [FirestoreProperty]
        public string? ImageUrl { get; set; }
    }
}