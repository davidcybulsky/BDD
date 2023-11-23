using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("animal")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _service;

        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> Get([FromRoute] Guid id)
        {
            var animal = await _service.GetAnimal(id);
            return Ok(animal);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAll()
        {
            var animals = await _service.GetAnimals();
            return Ok(animals);
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] Animal animal)
        {
            await _service.CreateAnimal(animal);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] Animal animal)
        {
            await _service.UpdateAnimal(id, animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.DeleteAnimal(id);
            return NoContent();
        }

    }
}
