using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("animal")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _service;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> Get([FromRoute] Guid id)
        {
            var animal = await _service.GetAnimal(id);
            if (animal == null)
            {
                return BadRequest();
            }
            return Ok(animal);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAll()
        {
            var animals = await _service.GetAnimals();
            if (animals == null)
            {
                return BadRequest();
            }
            return Ok(animals);
        }

        [HttpGet("enclosure/{enclosure}")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalsByEnclosure(string enclosure)
        {
            if (enclosure != "")
            {
                if (Enum.TryParse<Enclosure>(enclosure, ignoreCase: true, out Enclosure result))
                {

                    var animalsByEnclosure = await _service.GetAnimalsByEnclosure(result);
                    return Ok(animalsByEnclosure);
                }
            }
            return BadRequest();
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] AnimalDto animalDto)
        {
            var animal = _mapper.Map<Animal>(animalDto);
            if (animal == null)
            {
                return BadRequest();
            }
            animal.Id = Guid.NewGuid();
            await _service.CreateAnimal(animal);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] AnimalDto animalDto)
        {
            var animal = _mapper.Map<Animal>(animalDto);
            if (animal == null)
            {
                return BadRequest();
            }
            // animal.Id = Guid.NewGuid();
            await _service.UpdateAnimal(id, animal);
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var animal = await _service.DeleteAnimal(id);
            if (animal == null)
            {
                return BadRequest();
            }
            return Ok(animal);
        }

    }
}
