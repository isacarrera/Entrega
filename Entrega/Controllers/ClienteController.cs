using Busines;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Entrega.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteBusines _business;

        public ClienteController(ClienteBusines business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _business.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _business.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDTO clienteDto)
        {
            await _business.CreateAsync(clienteDto); 
            return CreatedAtAction(nameof(GetById), new { id = clienteDto.Id }, clienteDto); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (id != clienteDto.Id) return BadRequest();
            await _business.UpdateAsync(clienteDto);
            return NoContent();
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogic(int id)
        {
            await _business.DeleteLogicAsync(id);
            return NoContent();
        }

        [HttpDelete("permanent/{id}")]
        public async Task<IActionResult> DeletePermanent(int id)
        {
            await _business.DeletePermanentAsync(id);
            return NoContent();
        }
    }
}
