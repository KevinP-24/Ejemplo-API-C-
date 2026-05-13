using System.ComponentModel.DataAnnotations;

namespace Ejemplo_Web_API.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public required string Nombres { get; set; }

        [Required]
        [StringLength(60)]
        public required string Apellidos { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(120)]
        public required string CorreoElectronico { get; set; }

        [Phone]
        [StringLength(25)]
        public string? Telefono { get; set; }

        public bool Activo { get; set; } = true;
    }
}
