using Ejemplo_Web_API.Context;
using Ejemplo_Web_API.DTOs;
using Ejemplo_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }

        // GET: api/Persona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var person = await _context.Personas.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // POST: api/Persona
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(CrearPersonaDto dto)
        {
            /*
            if (dto.FechaNacimiento.Date > DateTime.Today)
            {
                return BadRequest("La fecha de nacimiento no puede ser futura.");
            }
            */
            var person = new Persona
            {
                Nombres = dto.Nombres.Trim(),
                Apellidos = dto.Apellidos.Trim(),
                CorreoElectronico = dto.CorreoElectronico.Trim().ToLowerInvariant(),
                Telefono = string.IsNullOrWhiteSpace(dto.Telefono) ? null : dto.Telefono.Trim(),
                /*
                Documento = dto.Documento.Trim(),
                FechaNacimiento = dto.FechaNacimiento.Date,
                Ocupacion = string.IsNullOrWhiteSpace(dto.Ocupacion) ? null : dto.Ocupacion.Trim(),
                Direccion = string.IsNullOrWhiteSpace(dto.Direccion) ? null : dto.Direccion.Trim(),
                Ciudad = string.IsNullOrWhiteSpace(dto.Ciudad) ? null : dto.Ciudad.Trim(),
                Pais = string.IsNullOrWhiteSpace(dto.Pais) ? null : dto.Pais.Trim(),
                */
                Activo = dto.Activo
            };

            _context.Personas.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersona), new { id = person.Id }, person);
        }

        // PUT: api/Persona/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, ActualizarPersonaDto dto)
        {   
            /*
            if (dto.FechaNacimiento.Date > DateTime.Today)
            {
                return BadRequest("La fecha de nacimiento no puede ser futura.");
            }
            */

            var person = await _context.Personas.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            person.Nombres = dto.Nombres.Trim();
            person.Apellidos = dto.Apellidos.Trim();
            person.CorreoElectronico = dto.CorreoElectronico.Trim().ToLowerInvariant();
            person.Telefono = string.IsNullOrWhiteSpace(dto.Telefono) ? null : dto.Telefono.Trim();
            /*
            person.Documento = dto.Documento.Trim();
            person.FechaNacimiento = dto.FechaNacimiento.Date;
            person.Ocupacion = string.IsNullOrWhiteSpace(dto.Ocupacion) ? null : dto.Ocupacion.Trim();
            person.Direccion = string.IsNullOrWhiteSpace(dto.Direccion) ? null : dto.Direccion.Trim();
            person.Ciudad = string.IsNullOrWhiteSpace(dto.Ciudad) ? null : dto.Ciudad.Trim();
            person.Pais = string.IsNullOrWhiteSpace(dto.Pais) ? null : dto.Pais.Trim();
            */
            person.Activo = dto.Activo;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var person = await _context.Personas.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
