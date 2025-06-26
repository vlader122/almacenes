using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ItemService : IService<Item>
    {
        public readonly ItemRepository _itemRepository;
        public ItemService(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Task<Item> Create(Item entity)
        {
            return _itemRepository.Create(entity);
        }

        public Task<Item> Delete(int id)
        {
            return _itemRepository.Delete(id);
        }

        public async Task<(List<Item>, int totalRegistros)> GetAll(int numeroPagina, int tamañoPagina)
        {
            return await _itemRepository.GetAll(numeroPagina, tamañoPagina);
        }

        public async Task<Item> GetById(int id)
        {
            return await _itemRepository.GetById(id);
        }

        public async Task<Item> Update(Item entity)
        {
            return await _itemRepository.Update(entity);
        }
    }
}
