using Almacenes.helper;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public readonly ItemService _itemService;
        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAll(int numeroPagina, int tamañoPagina)
        {
            if (numeroPagina < 1 || tamañoPagina < 1)
            {
                return BadRequest("Datos de paginacion incorrectos");
            }

            List<Item> items;
            int totalRegistros;
            (items, totalRegistros) = await _itemService.GetAll(numeroPagina, tamañoPagina);
            ResponsePagination<Item> pagination = new ResponsePagination<Item>
            {
                TotalRegistros = totalRegistros,
                NumeroPagina = numeroPagina,
                TamanioPagina = tamañoPagina,
                Datos = items
            };
            return Ok(pagination);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetByid(int id)
        {
            return Ok(await _itemService.GetById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _itemService.Delete(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            return Ok(await _itemService.Create(item));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Item item)
        {
            return Ok(await _itemService.Update(item));
        }
    }
}
