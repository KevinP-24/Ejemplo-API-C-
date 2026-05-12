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

        [Required]
        [StringLength(30)]
        public required string Documento { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(120)]
        public string? Ocupacion { get; set; }

        [StringLength(120)]
        public string? Direccion { get; set; }

        [StringLength(80)]
        public string? Ciudad { get; set; }

        [StringLength(80)]
        public string? Pais { get; set; }

        public bool Activo { get; set; } = true;
    }
}
