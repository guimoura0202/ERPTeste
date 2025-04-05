using BillingService.Models;

namespace BillingService.Services
{
    public class BillingRepository
    {
        private static readonly List<Bill> _bills = new();

        public IEnumerable<Bill> GetAll() => _bills;

        public Bill? GetById(string id) => _bills.FirstOrDefault(b => b.Id == id);

        public Bill Create(Bill bill)
        {
            bill.Id = _bills.Count == 0 ? "1" : (int.Parse(_bills.Max(b => b.Id)) + 1).ToString();
            _bills.Add(bill);
            return bill;
        }

        public void Update(Bill bill)
        {
            var existing = GetById(bill.Id);
            if (existing != null)
            {
                var index = _bills.IndexOf(existing);
                _bills[index] = bill;
            }
        }

        public void Delete(string id)
        {
            var bill = GetById(id);
            if (bill != null)
            {
                _bills.Remove(bill);
            }
        }

        public IEnumerable<Bill> GetBillsBySeller(string sellerId) =>
            _bills.Where(b => b.BillType == BillType.Saida && b.SellerId == sellerId);

        public IEnumerable<Bill> GetBillsByClient(string clientId) =>
            _bills.Where(b => b.BillType == BillType.Saida && b.ClientId == clientId);

        public IEnumerable<Bill> GetBillsByProvider(string providerId) =>
            _bills.Where(b => b.BillType == BillType.Entrada && b.ProviderId == providerId);
    }
}