using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ItemRepository : IRepository<Item>
    {
        public readonly AlmacenesContext _context;
        public ItemRepository(AlmacenesContext context)
        {
            _context = context;
        }

        public async Task<Item> Create(Item entity)
        {
            _context.Items.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Item> Delete(int id)
        {
            Item item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<List<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetById(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> Update(Item entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
