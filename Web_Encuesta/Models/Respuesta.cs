namespace Web_Encuesta.Models
{
    public class Respuesta
    {
        public int Id { get; set; }

        public string Respuestas { get; set; }

        public int IdPregunta { get; set; }

        public Pregunta Preguntas { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
