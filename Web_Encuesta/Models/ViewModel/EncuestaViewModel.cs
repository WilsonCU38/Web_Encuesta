namespace Web_Encuesta.Models.ViewModel
{
    public class EncuestaViewModel
    {
        public List<PreguntasViewModel> ListaPreguntas { get; set; } = new();
    }

    public class PreguntasViewModel
    {
        public int PreguntasId { get; set; }

        public string Enunciado { get; set; }

        public string Descripcion { get; set; }

        public string Respuesta { get; set; }
    }
}
