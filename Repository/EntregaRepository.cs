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
    public class EntregaRepository : IRepository<Entrega>
    {
        public readonly AlmacenesContext _context;
        public EntregaRepository(AlmacenesContext context)
        {
            _context = context;
        }

        public async Task<Entrega> Create(Entrega entity)
        {
            _context.Entregas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Entrega> Delete(int id)
        {
            Entrega entrega = await _context.Entregas.FindAsync(id);
            if (entrega != null)
            {
                _context.Entregas.Remove(entrega);
                await _context.SaveChangesAsync();
                return entrega;
            }
            return null;
        }

        public async Task<List<Entrega>> GetAll()
        {
            return await _context.Entregas.Include(de=>de.DetalleEntrega).ToListAsync();
        }

        public async Task<Entrega> GetById(int id)
        {
            return await _context.Entregas.FindAsync(id);
        }

        public async Task<Entrega> Update(Entrega entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
