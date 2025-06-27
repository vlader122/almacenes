using HeyRed.Mime;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Service
{
    public class FileService
    {
        private readonly string _basePath = Path.Combine(Directory.GetCurrentDirectory(),"uploads");
        public async Task<string> SubirArchivoAsync(string recurso, int recurso_id, IFormFile file)
        {
            string resourceFolder = Path.Combine(_basePath, recurso);
            Directory.CreateDirectory(resourceFolder);

            string fileExtension = "." + MimeTypesMap.GetExtension(file.ContentType);
            string filePath = Path.Combine(resourceFolder, recurso_id.ToString() + fileExtension);
            using (var stream = new FileStream(filePath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filePath;
        }

        public async Task<(byte[] file, string contentType, string fileName)> DescargarArchivo(string recurso, string fileName)
        {
            string filePath = Path.Combine(_basePath, recurso, fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Archivo no encontrado");
            }

            var file = await File.ReadAllBytesAsync(filePath);
            var contentType = "image/png";
            return (file, contentType, fileName);
        }
    }
}
