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
    public class ProveedorRepository : IRepository<Proveedor>
    {
        public readonly AlmacenesContext _context;
        public ProveedorRepository(AlmacenesContext context)
        {
            _context = context;
        }

        public async Task<Proveedor> Create(Proveedor entity)
        {
            _context.Proveedores.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Proveedor> Delete(int id)
        {
            Proveedor proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                await _context.SaveChangesAsync();
                return proveedor;
            }
            return null;
        }

        public async Task<List<Proveedor>> GetAll()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor> GetById(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task<Proveedor> Update(Proveedor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
