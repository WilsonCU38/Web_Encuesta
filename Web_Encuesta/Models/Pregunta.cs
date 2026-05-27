namespace Web_Encuesta.Models
{
    public class Pregunta
    {
        public int Id { get; set; }

        public string Enunciado { get; set; }

        public int Orden { get; init; }

        public int Peso { get; set; }

        public string Descripcion { get; set; }
    }
}
