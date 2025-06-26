using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProveedorService : IService<Proveedor>
    {
        public readonly ProveedorRepository _proveedorRepository;
        public ProveedorService(ProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public Task<Proveedor> Create(Proveedor entity)
        {
            return _proveedorRepository.Create(entity);
        }

        public Task<Proveedor> Delete(int id)
        {
            return _proveedorRepository.Delete(id);
        }

        public async Task<(List<Proveedor>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            return await _proveedorRepository.GetAll(numeroPagina, tamañoPagina);
        }

        public async Task<Proveedor> GetById(int id)
        {
            return await _proveedorRepository.GetById(id);
        }

        public async Task<Proveedor> Update(Proveedor entity)
        {
            return await _proveedorRepository.Update(entity);
        }
    }
}
