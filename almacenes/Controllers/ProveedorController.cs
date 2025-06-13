using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        public readonly ProveedorService _proveedorService;
        public ProveedorController(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetAll()
        {
            return Ok(await _proveedorService.GetAll());
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
