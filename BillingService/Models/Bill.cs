using Google.Cloud.Firestore;

namespace BillingService.Models
{
    [FirestoreData]
    public class Bill
    {
        [FirestoreDocumentId]
        public string? Id { get; set; }

        [FirestoreProperty]
        public string BillNumber { get; set; } = string.Empty;

        [FirestoreProperty]
        public BillType BillType { get; set; } = BillType.Saida;

        [FirestoreProperty]
        public string? ClientId { get; set; }

        [FirestoreProperty]
        public string? SellerId { get; set; }

        [FirestoreProperty]
        public string? ProviderId { get; set; }

        [FirestoreProperty]
        public string? PaymentMethod { get; set; }

        [FirestoreProperty]
        public string? PaymentStatus { get; set; }

        [FirestoreProperty]
        public BillStatus BillStatus { get; set; } = BillStatus.Aberto;

        [FirestoreProperty]
        public List<BillItem> Items { get; set; } = new();
    }

    public enum BillType
    {
        Entrada = 0,
        Saida = 1
    }

    public enum BillStatus
    {
        Aberto = 0,
        Pago = 1,
        Cancelado = 2
    }

    [FirestoreData]
    public class BillItem
    {
        [FirestoreProperty]
        public int ProductId { get; set; }

        [FirestoreProperty]
        public string? ProductName { get; set; }

        [FirestoreProperty]
        public double UnitPrice { get; set; }

        [FirestoreProperty]
        public int Quantity { get; set; }
    }
}
