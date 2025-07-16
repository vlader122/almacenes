using Almacenes.helper;
using DB.dtos;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        public readonly PersonalService _personalService;
        public PersonalController(PersonalService personalService)
        {
            _personalService = personalService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personal>>> GetAll(int numeroPagina, int tamañoPagina, bool pag = true, bool withDto = false)
        {
            if (pag)
            {
                if (numeroPagina < 1 || tamañoPagina < 1)
                {
                    return BadRequest("Datos de paginacion incorrectos");
                }
            }
            else
            {
                numeroPagina = 0;
                tamañoPagina = 0;
            }

            if (withDto)
            {
                List<PersonalDto> personals;
                int totalRegistros;
                (personals, totalRegistros) = await _personalService.GetAllWithDto(numeroPagina, tamañoPagina);
                ResponsePagination<PersonalDto> pagination = new ResponsePagination<PersonalDto>
                {
                    TotalRegistros = totalRegistros,
                    NumeroPagina = numeroPagina,
                    TamanioPagina = tamañoPagina,
                    Datos = personals
                };
                return Ok(pagination);
            }
            else
            {
                List<Personal> personals;
                int totalRegistros;
                (personals, totalRegistros) = await _personalService.GetAll(numeroPagina, tamañoPagina);
                ResponsePagination<Personal> pagination = new ResponsePagination<Personal>
                {
                    TotalRegistros = totalRegistros,
                    NumeroPagina = numeroPagina,
                    TamanioPagina = tamañoPagina,
                    Datos = personals
                };
                return Ok(pagination);
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Personal>> GetByid(int id)
        {
            return Ok(await _personalService.GetById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _personalService.Delete(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Personal personal)
        {
            return Ok(await _personalService.Create(personal));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Personal personal)
        {
            return Ok(await _personalService.Update(personal));
        }
    }
}
