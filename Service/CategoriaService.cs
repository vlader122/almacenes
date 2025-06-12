using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoriaService : IService<Categoria>
    {
        public readonly CategoriaRepository _categoriaRepository;
        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public Task<Categoria> Create(Categoria entity)
        {
            return _categoriaRepository.Create(entity);
        }

        public Task<Categoria> Delete(int id)
        {
            return _categoriaRepository.Delete(id);
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _categoriaRepository.GetAll();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _categoriaRepository.GetById(id);
        }

        public async Task<Categoria> Update(Categoria entity)
        {
            return await _categoriaRepository.Update(entity);
        }
    }
}
