using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PersonalService : IService<Personal>
    {
        public readonly PersonalRepository _personalRepository;
        public PersonalService(PersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public Task<Personal> Create(Personal entity)
        {
            return _personalRepository.Create(entity);
        }

        public Task<Personal> Delete(int id)
        {
            return _personalRepository.Delete(id);
        }

        public Task<(List<Personal>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            return _personalRepository.GetAll(numeroPagina, tamañoPagina);
        }

        public async Task<Personal> GetById(int id)
        {
            return await _personalRepository.GetById(id);
        }

        public async Task<Personal> Update(Personal entity)
        {
            return await _personalRepository.Update(entity);
        }
    }
}
