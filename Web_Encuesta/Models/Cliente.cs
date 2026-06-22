using System.ComponentModel.DataAnnotations;

namespace Web_Encuesta.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Cedula { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Nombres { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Direccion { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Telefono { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Correo { get; set; } = string.Empty;

        [MaxLength(25)]
        [MinLength(8)]
        public string ContraseniaHash { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }
}
