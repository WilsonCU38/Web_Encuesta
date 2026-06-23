using Microsoft.EntityFrameworkCore;

namespace Web_Encuesta.Models
{
    public class EncuestaDBContext : DbContext 
    {
        public EncuestaDBContext(DbContextOptions op) : base(op)
        {
            
        }

        public DbSet<Pregunta> Pregunta { get; set; }

        public DbSet<Respuesta> Respuestas { get; set; }

        public DbSet<Cliente> Clientes {  get; set; }
    }
}
