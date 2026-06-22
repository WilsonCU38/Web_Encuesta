using System.ComponentModel.DataAnnotations;

namespace Web_Encuesta.Models.Dto
{
    public class AutenticacionDto
    {
        public class LoginDto
        {
            [Required(ErrorMessage = "La cédula es obligatoria")]
            [MaxLength(10)]
            public string Cedula { get; set; } = string.Empty;

            [Required(ErrorMessage = "La contraseña es obligatoria")]
            [MinLength(8)]
            public string Password { get; set; } = string.Empty;
        }

        public class RegistroDto
        {
            [Required][MaxLength(10)] public string Cedula { get; set; } = string.Empty;

            [Required][MaxLength(150)] public string Nombres { get; set; } = string.Empty;

            [MaxLength(150)] public string Direccion { get; set; } = string.Empty;

            [MaxLength(15)] public string Telefono { get; set; } = string.Empty;

            [Required][EmailAddress][MaxLength(150)] public string Correo { get; set; } = string.Empty;

            [Required][MinLength(6)] public string Password { get; set; } = string.Empty;
        }

        public class AutenticacionRespuesta
        {
            public string Token { get; set; } = string.Empty;
            public string Nombre { get; set; } = string.Empty;
            public string Cedula { get; set; } = string.Empty;
        }
    }
}
