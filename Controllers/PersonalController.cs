using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Personal> ObtenerPersonal()
        {
            Personal personal = new Personal();
            personal.Nombre = "Juan";
            personal.Apellido = "Perez";
            personal.Telefono = "12345678";

            return Ok(personal);
        }
    }
}
