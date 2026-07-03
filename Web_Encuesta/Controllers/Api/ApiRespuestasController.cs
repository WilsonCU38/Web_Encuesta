using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Encuesta.Models;
using Web_Encuesta.Models.Dto;

[Route("api/[controller]")]
[ApiController]
public class ApiRespuestasController : ControllerBase
{
    private readonly EncuestaDBContext _context;
    public ApiRespuestasController(EncuestaDBContext context)
    {
        _context = context;
    }

    // GET: api/ApiRespuestas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RespuestaDto>>> GetRespuesta()
    {
        var respuestas = await _context.Respuestas
            .Include(r => r.Pregunta)
            .Select(r => new RespuestaDto
            {
                Id = r.Id,
                Detalle = r.Detalle,
                PreguntaId = r.PreguntaId,
                Pregunta = r.Pregunta!.Descripcion,
                FechaRegistro = r.FechaRegistro
            })
            .ToListAsync();

        return Ok(respuestas);
    }

    // GET: api/ApiRespuestas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RespuestaDto>> GetRespuesta(int id)
    {
        var respuesta = await _context.Respuestas
            .Include(r => r.Pregunta)
            .Where(r => r.Id == id)
            .Select(r => new RespuestaDto
            {
                Id = r.Id,
                Detalle = r.Detalle,
                PreguntaId = r.PreguntaId,
                Pregunta = r.Pregunta!.Descripcion,
                FechaRegistro = r.FechaRegistro
            })
            .FirstOrDefaultAsync();

        if (respuesta == null)
        {
            return NotFound();
        }

        return Ok(respuesta);
    }

    // PUT: api/ApiRespuestas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRespuesta(int id, Respuesta respuesta)
    {
        if (id != respuesta.Id)
        {
            return BadRequest();
        }

        var respuestaDb = await _context.Respuestas
            .FirstOrDefaultAsync(r => r.Id == id);

        if (respuestaDb == null)
        {
            return NotFound();
        }

        respuestaDb.Detalle = respuesta.Detalle;
        respuestaDb.PreguntaId = respuesta.PreguntaId;
        respuestaDb.FechaRegistro = DateTime.Now;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/ApiRespuestas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<RespuestaDto>> PostRespuesta(Respuesta respuesta)
    {
        respuesta.FechaRegistro = DateTime.Now;

        _context.Respuestas.Add(respuesta);

        await _context.SaveChangesAsync();

        var respuestaDto = await _context.Respuestas
            .Include(r => r.Pregunta)
            .Where(r => r.Id == respuesta.Id)
            .Select(r => new RespuestaDto
            {
                Id = r.Id,
                Detalle = r.Detalle,
                PreguntaId = r.PreguntaId,
                Pregunta = r.Pregunta!.Descripcion,
                FechaRegistro = r.FechaRegistro
            })
            .FirstAsync();

        return CreatedAtAction(
            nameof(GetRespuesta),
            new { id = respuestaDto.Id },
            respuestaDto);
    }

    // DELETE: api/ApiRespuestas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRespuesta(int id)
    {
        var respuesta = await _context.Respuestas.FindAsync(id);
        if (respuesta == null)
        {
            return NotFound();
        }

        _context.Respuestas.Remove(respuesta);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RespuestaExists(int id)
    {
        return _context.Respuestas.Any(e => e.Id == id);
    }
}
