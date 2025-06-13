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
    public class DetalleEntregaRepository : IRepository<DetalleEntrega>
    {
        public readonly AlmacenesContext _context;
        public DetalleEntregaRepository(AlmacenesContext context)
        {
            _context = context;
        }

        public async Task<DetalleEntrega> Create(DetalleEntrega entity)
        {
            _context.DetalleEntregas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<DetalleEntrega> Delete(int id)
        {
            DetalleEntrega detalleEntrega = await _context.DetalleEntregas.FindAsync(id);
            if (detalleEntrega != null)
            {
                _context.DetalleEntregas.Remove(detalleEntrega);
                await _context.SaveChangesAsync();
                return detalleEntrega;
            }
            return null;
        }

        public async Task<List<DetalleEntrega>> GetAll()
        {
            return await _context.DetalleEntregas.ToListAsync();
        }

        public async Task<DetalleEntrega> GetById(int id)
        {
            return await _context.DetalleEntregas.FindAsync(id);
        }

        public async Task<DetalleEntrega> Update(DetalleEntrega entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
