using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EntregaService : IService<Entrega>
    {
        public readonly EntregaRepository _entregaRepository;
        public EntregaService(EntregaRepository entregaRepository)
        {
            _entregaRepository = entregaRepository;
        }

        public Task<Entrega> Create(Entrega entity)
        {
            return _entregaRepository.Create(entity);
        }

        public Task<Entrega> Delete(int id)
        {
            return _entregaRepository.Delete(id);
        }

        public async Task<(List<Entrega>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            return await _entregaRepository.GetAll(numeroPagina, tamañoPagina);
        }

        public async Task<Entrega> GetById(int id)
        {
            return await _entregaRepository.GetById(id);
        }

        public async Task<Entrega> Update(Entrega entity)
        {
            return await _entregaRepository.Update(entity);
        }
    }
}
