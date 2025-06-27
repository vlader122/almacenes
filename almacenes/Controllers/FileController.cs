using Microsoft.AspNetCore.Mvc;
using Service;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileService _fileService;

        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("subir/{id}")]
        public async Task<IActionResult> SubirArchivo([FromForm] string recurso, int id, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No existen archivos para Subir");
            }
            
            var path = await _fileService.SubirArchivoAsync(recurso,id, file);
            return Ok(new { message = "Subido Correctamente", path });
        }

        [HttpGet("descargar/{recurso}/{fileName}")]
        public async Task<IActionResult> Descargar(string recurso, string fileName)
        {
            try
            {
                var (file, contentType, name) = await _fileService.DescargarArchivo(recurso, fileName);
                return File(file, contentType, name);
            }
            catch (Exception ex)
            {
                return NotFound("Archivo no encontrado");
            }
        }
    }
}
