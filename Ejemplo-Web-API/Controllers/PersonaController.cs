using Ejemplo_Web_API.Context;
using Ejemplo_Web_API.DTOs;
using Ejemplo_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_Web_API.Controllers
{
    /// <summary>
    /// Controlador encargado de gestionar las operaciones CRUD de personas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonaController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene el listado completo de personas registradas.
        /// </summary>
        /// <returns>Lista de personas almacenadas en la base de datos.</returns>
        /// <response code="200">Retorna la lista de personas.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Persona>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return Ok(await _context.Personas.ToListAsync());
        }

        /// <summary>
        /// Obtiene una persona específica por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la persona.</param>
        /// <returns>Persona encontrada.</returns>
        /// <response code="200">Retorna la persona encontrada.</response>
        /// <response code="404">No se encontró una persona con el ID indicado.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Persona), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Persona>> GetPersona([FromRoute] int id)
        {
            var person = await _context.Personas.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        /// <summary>
        /// Crea una nueva persona en la base de datos.
        /// </summary>
        /// <param name="dto">Datos requeridos para crear una persona.</param>
        /// <returns>Persona creada.</returns>
        /// <response code="201">Persona creada correctamente.</response>
        /// <response code="400">Los datos enviados no son válidos.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Persona), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> PostPersona([FromBody] CrearPersonaDto dto)
        {
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

        /// <summary>
        /// Actualiza los datos de una persona existente.
        /// </summary>
        /// <param name="id">Identificador único de la persona que se desea actualizar.</param>
        /// <param name="dto">Datos actualizados de la persona.</param>
        /// <response code="204">Persona actualizada correctamente.</response>
        /// <response code="400">Los datos enviados no son válidos.</response>
        /// <response code="404">No se encontró una persona con el ID indicado.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPersona(
            [FromRoute] int id,
            [FromBody] ActualizarPersonaDto dto)
        {
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

        /// <summary>
        /// Elimina una persona de la base de datos.
        /// </summary>
        /// <param name="id">Identificador único de la persona que se desea eliminar.</param>
        /// <response code="204">Persona eliminada correctamente.</response>
        /// <response code="404">No se encontró una persona con el ID indicado.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePersona([FromRoute] int id)
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