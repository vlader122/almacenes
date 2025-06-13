using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        public readonly EntregaService _entregaService;
        public EntregaController(EntregaService entregaService)
        {
            _entregaService = entregaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrega>>> GetAll()
        {
            return Ok(await _entregaService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrega>> GetByid(int id)
        {
            return Ok(await _entregaService.GetById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _entregaService.Delete(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entrega entrega)
        {
            return Ok(await _entregaService.Create(entrega));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Entrega entrega)
        {
            return Ok(await _entregaService.Update(entrega));
        }
    }
}
