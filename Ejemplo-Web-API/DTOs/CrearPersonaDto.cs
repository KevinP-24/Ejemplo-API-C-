using System.ComponentModel.DataAnnotations;

namespace Ejemplo_Web_API.DTOs
{
    public class CrearPersonaDto
    {
        [Required]
        [StringLength(60)]
        public required string Nombres { get; set; }

        [Required]
        [StringLength(60)]
        public required string Apellidos { get; set; }

        /*
         * Nos ayuda a validar Que son campos requeridos y el EmailAdress para que sea formato de correo valido
         */
        [Required(ErrorMessage = "El campo del coorreo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo no es valido")]
        [StringLength(120)]
        public required string CorreoElectronico { get; set; }

        [Phone]
        [StringLength(25)]
        public string? Telefono { get; set; }

        public bool Activo { get; set; } = true;
    }
}
