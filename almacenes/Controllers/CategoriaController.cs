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
    public class CategoriaController : ControllerBase
    {
        public readonly CategoriaService _categoriaService;
        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAll(int numeroPagina, int tamañoPagina)
        {
            if (numeroPagina < 1 || tamañoPagina < 1)
            {
                return BadRequest("Datos de paginacion incorrectos");
            }

            List<Categoria> categorias;
            int totalRegistros;
            (categorias, totalRegistros) = await _categoriaService.GetAll(numeroPagina, tamañoPagina);
            ResponsePagination<Categoria> pagination = new ResponsePagination<Categoria>
            {
                TotalRegistros = totalRegistros,
                NumeroPagina = numeroPagina,
                TamanioPagina = tamañoPagina,
                Datos = categorias
            };
            return Ok(pagination);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetByid(int id)
        {
            return Ok(await _categoriaService.GetById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _categoriaService.Delete(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            return Ok(await _categoriaService.Create(categoria));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Categoria categoria)
        {
            return Ok(await _categoriaService.Update(categoria));
        }
    }
}
