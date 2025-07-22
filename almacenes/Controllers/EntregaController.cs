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

    public class EntregaController : ControllerBase
    {
        public readonly EntregaService _entregaService;
        public EntregaController(EntregaService entregaService)
        {
            _entregaService = entregaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrega>>> GetAll(int numeroPagina, int tamañoPagina)
        {
            if (numeroPagina < 1 || tamañoPagina < 1)
            {
                return BadRequest("Datos de paginacion incorrectos");
            }

            List<Entrega> entregas;
            int totalRegistros;
            (entregas, totalRegistros) = await _entregaService.GetAll(numeroPagina, tamañoPagina);
            ResponsePagination<Entrega> pagination = new ResponsePagination<Entrega>
            {
                TotalRegistros = totalRegistros,
                NumeroPagina = numeroPagina,
                TamanioPagina = tamañoPagina,
                Datos = entregas
            };
            return Ok(pagination);
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
