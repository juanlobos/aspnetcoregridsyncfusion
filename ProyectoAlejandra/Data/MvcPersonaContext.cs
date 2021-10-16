using System;
using Microsoft.EntityFrameworkCore;
using ProyectoAlejandra.Models;

namespace ProyectoAlejandra.Data
{
    public class MvcPersonaContext : DbContext
    {
        public MvcPersonaContext(DbContextOptions<MvcPersonaContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Persona { get; set; }
    }
}
