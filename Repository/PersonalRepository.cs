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
    public class PersonalRepository : IRepository<Personal>
    {
        public readonly AlmacenesContext _context;
        public PersonalRepository(AlmacenesContext context)
        {
            _context = context;
        }

        public async Task<Personal> Create(Personal entity)
        {
            _context.Personales.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Personal> Delete(int id)
        {
            Personal personal = await _context.Personales.FindAsync(id);
            if (personal != null)
            {
                _context.Personales.Remove(personal);
                await _context.SaveChangesAsync();
                return personal;
            }
            return null;
        }

        public async Task<List<Personal>> GetAll()
        {
            return await _context.Personales.ToListAsync();
        }

        public async Task<Personal> GetById(int id)
        {
            return await _context.Personales.FindAsync(id);
        }

        public async Task<Personal> Update(Personal entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
