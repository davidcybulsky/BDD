using Api.DTO;
using Api.Entities;
using Api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("caretaker")]
    public class CaretakerController : ControllerBase
    {
        private readonly ICaretakerService _service;
        private readonly IMapper _mapper;

        public CaretakerController(ICaretakerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Caretaker>> Get([FromRoute] Guid id)
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
        public async Task<ActionResult> Post([FromBody] CaretakerDto caretakerDto)
        {
            var carettaker = _mapper.Map<Caretaker>(caretakerDto);
            await _service.Create(carettaker);
            return Ok(carettaker);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] CaretakerDto caretakerDto)
        {
            var carettaker = _mapper.Map<Caretaker>(caretakerDto);
            await _service.Update(id, carettaker);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.Delete(id);
            return NoContent();
        }

    }
}
