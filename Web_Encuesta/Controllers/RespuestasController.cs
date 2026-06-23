
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Web_Encuesta.Migrations;
using Web_Encuesta.Models;
using Web_Encuesta.Models.ViewModel;

public class RespuestasController : Controller
{
    private readonly EncuestaDBContext _context;

    public RespuestasController(EncuestaDBContext context)
    {
        _context = context;
    }

    // GET: RESPUESTAS
    public async Task<IActionResult> Index()    
    {
        var preguntas = await _context.Pregunta.OrderBy(p => p.Orden)
            .Select(p => new PreguntasViewModel
            {
                PreguntaId = p.Id,
                Descripcion = p.Descripcion,
                Enunciado = p.Enunciado,
                Detalle = string.Empty
            }).ToListAsync();

        var encuesta = new EncuestaViewModel
        {
            ListaPreguntas = preguntas,
        };

        return View(encuesta);
    }

    // GET: RESPUESTAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RESPUESTAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EncuestaViewModel encuesta)
    {
        if (encuesta == null || encuesta.ListaPreguntas == null || !encuesta.ListaPreguntas.Any())
        {
            ModelState.AddModelError("", "No se recibieron respuestas");

            return View("Index", encuesta);
        }

        var respuestas = encuesta.ListaPreguntas
            .Where(p => !string.IsNullOrWhiteSpace(p.Detalle))
            .Select(p => new Respuesta
            {
                Detalle = p.Detalle,
                PreguntaId = p.PreguntaId,
                FechaRegistro = DateTime.Now,
            }).ToList();

        if (!respuestas.Any())
        {
            ModelState.AddModelError("", "Debe responder las preguntas");

            return View("Index", encuesta);
        }

        _context.Respuesta.AddRange(respuestas);

        await _context.SaveChangesAsync();

        return RedirectToAction("Gracias");
    }

    public IActionResult Gracias()
    {
        return View();
    }
}
