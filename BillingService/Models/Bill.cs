namespace BillingService.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string BillNumber { get; set; } = string.Empty;
        public BillType BillType { get; set; } = BillType.Saida;
        public int PartyId { get; set; }
        public BillStatus BillStatus { get; set; } = BillStatus.Aberto;
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
    public class BillItem
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
