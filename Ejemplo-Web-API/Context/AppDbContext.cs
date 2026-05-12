using Ejemplo_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_Web_API.Context {
    // Contexto principal para trabajar con la base de datos.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tabla de personas.
        public DbSet<Persona> Personas { get; set; } = default!;
    }
}
