using Microsoft.AspNetCore.Mvc;
using PeopleService.Models;
using PeopleService.Services;

namespace PeopleService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleRepository _repository;

        public PeopleController(PeopleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var people = await _repository.GetAllAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var person = await _repository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            var created = await _repository.CreateAsync(person);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                return BadRequest("ID inconsistente.");
            }

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(id, person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
