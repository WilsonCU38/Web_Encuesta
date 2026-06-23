using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Encuesta.Models;

[Route("api/[controller]")]
[ApiController]
public class ApiPreguntasController : ControllerBase
{
    private readonly EncuestaDBContext _context;
    public ApiPreguntasController(EncuestaDBContext context)
    {
        _context = context;
    }

    // GET: api/Pregunta
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pregunta>>> GetPregunta()
    {
        return await _context.Preguntas.ToListAsync();
    }

    // GET: api/Pregunta/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pregunta>> GetPregunta(int id)
    {
        var pregunta = await _context.Preguntas.FindAsync(id);

        if (pregunta == null)
        {
            return NotFound();
        }

        return pregunta;
    }

    // PUT: api/Pregunta/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPregunta(int? id, Pregunta pregunta)
    {
        if (id != pregunta.Id)
        {
            return BadRequest();
        }

        _context.Entry(pregunta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PreguntaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Pregunta
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Pregunta>> PostPregunta(Pregunta pregunta)
    {
        _context.Preguntas.Add(pregunta);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPregunta", new { id = pregunta.Id }, pregunta);
    }

    // DELETE: api/Pregunta/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePregunta(int? id)
    {
        var pregunta = await _context.Preguntas.FindAsync(id);
        if (pregunta == null)
        {
            return NotFound();
        }

        _context.Preguntas.Remove(pregunta);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PreguntaExists(int? id)
    {
        return _context.Preguntas.Any(e => e.Id == id);
    }
}
