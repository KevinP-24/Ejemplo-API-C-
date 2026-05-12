using Ejemplo_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_Web_API.Context {
    /*
    Una sesion de trabajo con la base de datos, uilizado para realizar operaciones de CRUD con la base de datos 
    */
    public class AppDbContext : DbContext  {
        /*
         * Inicialiazar el contexto de la base de datos, 
         * con las opciones de config necesarias para conectarse y operar con la base de datos subyacente 
         * ademas permite la inyeccion de dependencias
         */
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            
        }
        /*
         * Es una clase en Entity Framework que representa una colecion de entidades 
         * en el contexto de la base de datos 
         */
        public DbSet<Person> Persons { get; set; } // esos geters y setres ya se usan para las acciones CRUD en la base da dedatos 

    }
}
