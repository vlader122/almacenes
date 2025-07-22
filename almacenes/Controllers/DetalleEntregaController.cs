using Almacenes.helper;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetalleEntregaController : ControllerBase
    {
        public readonly DetalleEntregaService _detalleEntregaService;
        public DetalleEntregaController(DetalleEntregaService detalleEntregaService)
        {
            _detalleEntregaService = detalleEntregaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleEntrega>>> GetAll(int numeroPagina, int tamañoPagina)
        {
            if (numeroPagina < 1 || tamañoPagina < 1)
            {
                return BadRequest("Datos de paginacion incorrectos");
            }

            List<DetalleEntrega> detalles;
            int totalRegistros;
            (detalles, totalRegistros) = await _detalleEntregaService.GetAll(numeroPagina, tamañoPagina);
            ResponsePagination<DetalleEntrega> pagination = new ResponsePagination<DetalleEntrega>
            {
                TotalRegistros = totalRegistros,
                NumeroPagina = numeroPagina,
                TamanioPagina = tamañoPagina,
                Datos = detalles
            };
            return Ok(pagination);
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
