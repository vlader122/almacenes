﻿using DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class AlmacenesContext : IdentityDbContext
    {
        public AlmacenesContext(DbContextOptions<AlmacenesContext> options)
            : base(options){ }

        public DbSet<Personal> Personales { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<DetalleEntrega> DetalleEntregas { get; set; }

    }
}
