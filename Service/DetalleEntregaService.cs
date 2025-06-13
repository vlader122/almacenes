using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DetalleEntregaService : IService<DetalleEntrega>
    {
        public readonly DetalleEntregaRepository _detalleEntregaRepository;
        public DetalleEntregaService(DetalleEntregaRepository detalleEntregaRepository)
        {
            _detalleEntregaRepository = detalleEntregaRepository;
        }

        public Task<DetalleEntrega> Create(DetalleEntrega entity)
        {
            return _detalleEntregaRepository.Create(entity);
        }

        public Task<DetalleEntrega> Delete(int id)
        {
            return _detalleEntregaRepository.Delete(id);
        }

        public async Task<List<DetalleEntrega>> GetAll()
        {
            return await _detalleEntregaRepository.GetAll();
        }

        public async Task<DetalleEntrega> GetById(int id)
        {
            return await _detalleEntregaRepository.GetById(id);
        }

        public async Task<DetalleEntrega> Update(DetalleEntrega entity)
        {
            return await _detalleEntregaRepository.Update(entity);
        }
    }
}
