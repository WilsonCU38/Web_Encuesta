namespace Web_Encuesta.Models
{
    public class Respuesta
    {
        public int Id { get; set; }

        public string Detalle { get; set; }

        public int PreguntaId { get; set; }

        public Pregunta Pregunta { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
