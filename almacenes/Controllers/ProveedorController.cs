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

    public class ProveedorController : ControllerBase
    {
        public readonly ProveedorService _proveedorService;
        public ProveedorController(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetAll(int numeroPagina, int tamañoPagina)
        {
            if (numeroPagina < 1 || tamañoPagina < 1)
            {
                return BadRequest("Datos de paginacion incorrectos");
            }

            List<Proveedor> proveedors;
            int totalRegistros;
            (proveedors, totalRegistros) = await _proveedorService.GetAll(numeroPagina, tamañoPagina);
            ResponsePagination<Proveedor> pagination = new ResponsePagination<Proveedor>
            {
                TotalRegistros = totalRegistros,
                NumeroPagina = numeroPagina,
                TamanioPagina = tamañoPagina,
                Datos = proveedors
            };
            return Ok(pagination);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetByid(int id)
        {
            return Ok(await _proveedorService.GetById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _proveedorService.Delete(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Proveedor proveedor)
        {
            return Ok(await _proveedorService.Create(proveedor));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Proveedor proveedor)
        {
            return Ok(await _proveedorService.Update(proveedor));
        }
    }
}
