using Microsoft.AspNetCore.Mvc;
using BillingService.Models;
using BillingService.Services;

namespace BillingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly BillingRepository _repository;

        public BillingController(BillingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var bill = _repository.GetById(id);
            if (bill == null)
                return NotFound();
            return Ok(bill);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Bill bill)
        {
            var created = _repository.Create(bill);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Bill bill)
        {
            if (id != bill.Id)
                return BadRequest("ID inconsistente.");
            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();
            _repository.Update(bill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();
            _repository.Delete(id);
            return NoContent();
        }

        [HttpGet("sales/{sellerId}")]
        public IActionResult GetSalesBySeller(string sellerId)
        {
            var sales = _repository.GetBillsBySeller(sellerId);
            return Ok(sales);
        }

        [HttpGet("purchases/{clientId}")]
        public IActionResult GetPurchasesByClient(string clientId)
        {
            var purchases = _repository.GetBillsByClient(clientId);
            return Ok(purchases);
        }

        [HttpGet("deliveries/{providerId}")]
        public IActionResult GetDeliveriesByProvider(string providerId)
        {
            var deliveries = _repository.GetBillsByProvider(providerId);
            return Ok(deliveries);
        }
    }
}
