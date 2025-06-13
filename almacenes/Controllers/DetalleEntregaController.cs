using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleEntregaController : ControllerBase
    {
        public readonly DetalleEntregaService _detalleEntregaService;
        public DetalleEntregaController(DetalleEntregaService detalleEntregaService)
        {
            _detalleEntregaService = detalleEntregaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleEntrega>>> GetAll()
        {
            return Ok(await _detalleEntregaService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleEntrega>> GetByid(int id)
        {
            return Ok(await _detalleEntregaService.GetById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _detalleEntregaService.Delete(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(DetalleEntrega detalleEntrega)
        {
            return Ok(await _detalleEntregaService.Create(detalleEntrega));
        }
        [HttpPut]
        public async Task<IActionResult> Update(DetalleEntrega detalleEntrega)
        {
            return Ok(await _detalleEntregaService.Update(detalleEntrega));
        }
    }
}
