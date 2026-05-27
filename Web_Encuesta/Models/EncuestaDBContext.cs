using Microsoft.EntityFrameworkCore;

namespace Web_Encuesta.Models
{
    public class EncuestaDBContext : DbContext 
    {
        public EncuestaDBContext(DbContextOptions op) : base(op)
        {
            
        }

        public DbSet<Pregunta> Preguntas { get; set; }

        public DbSet<Respuesta> Respuestas { get; set; }
    }
}
