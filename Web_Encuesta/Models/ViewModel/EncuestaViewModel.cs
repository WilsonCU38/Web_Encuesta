namespace Web_Encuesta.Models.ViewModel
{
    public class EncuestaViewModel
    {
        public List<PreguntasViewModel> ListaPreguntas { get; set; } = new();
    }

    public class PreguntasViewModel
    {
        public int PreguntaId { get; set; }

        public string Enunciado { get; set; }

        public string Descripcion { get; set; }

        public string Detalle { get; set; }
    }
}
