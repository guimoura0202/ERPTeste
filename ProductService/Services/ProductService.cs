using Google.Cloud.Firestore;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductRepository
    {
        private readonly FirestoreDb _db;
        private readonly CollectionReference _productsCollection;

        public ProductRepository(FirestoreDb db)
        {
            _db = db;
            _productsCollection = _db.Collection("products");
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            QuerySnapshot snapshot = await _productsCollection.GetSnapshotAsync();
            return snapshot.Documents.Select(doc => doc.ConvertTo<Product>());
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            DocumentReference docRef = _productsCollection.Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Product>();
            }
            return null;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            DocumentReference addedDoc = await _productsCollection.AddAsync(product);
            product.Id = addedDoc.Id;
            return product;
        }

        public async Task UpdateAsync(string id, Product product)
        {
            DocumentReference docRef = _productsCollection.Document(id);
            await docRef.SetAsync(product, SetOptions.Overwrite);
        }

        public async Task DeleteAsync(string id)
        {
            DocumentReference docRef = _productsCollection.Document(id);
            await docRef.DeleteAsync();
        }

        public async Task AdjustStockAsync(string id, int quantityChange)
        {
            DocumentReference docRef = _productsCollection.Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                var product = snapshot.ConvertTo<Product>();
                product.StockQuantity += quantityChange;
                await docRef.SetAsync(product, SetOptions.Overwrite);
            }
        }
    }
}
