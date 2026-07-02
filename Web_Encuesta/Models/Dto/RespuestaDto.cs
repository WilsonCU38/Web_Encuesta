namespace Web_Encuesta.Models.Dto
{
    public class RespuestaDto
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public int PreguntaId { get; set; }
        public string Pregunta { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
