using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("caretaker")]
    public class CaretakerController : ControllerBase
    {
        private readonly ICaretakerService _service;

        public CaretakerController(ICaretakerService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Caretaker>> Get([FromRoute] int id)
        {
            var caretaker = await _service.ReadById(id);
            return Ok(caretaker);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Caretaker>>> GetAll()
        {
            var caretakers = await _service.Read();
            return Ok(caretakers);
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] Caretaker caretaker)
        {
            await _service.Create(caretaker);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Caretaker caretaker)
        {
            await _service.Update(id, caretaker);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

    }
}
