using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Context;
using RecetaElectronica.Modelo;
using RecetaElectronica.Servicios;

namespace RecetaElectronica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRecetaService _recetaService;
        private readonly PdfSharpRecetaService _pdfSharpRecetaService;

        public RecetasController(AppDbContext context, IRecetaService recetaService, PdfSharpRecetaService pdfSharpRecetaService)
        {
            _context = context;
            _recetaService = recetaService;
            _pdfSharpRecetaService = pdfSharpRecetaService;
        }

        [HttpGet("validar")]
        public async Task<IActionResult> ValidarReceta(int pacienteId, int cantidad)
        {
            var paciente = await _context.Pacientes
                .Include(p => p.ObraSocial)
                .Include(p => p.Cobertura)
                .FirstOrDefaultAsync(p => p.PacienteId == pacienteId);

            if (paciente == null) return NotFound("Paciente no encontrado");

            var esValido = _recetaService.ValidarCantidadMedicamentos(paciente, cantidad);

            return Ok(new { Paciente = $"{paciente.Nombre} {paciente.Apellido}", EsValido = esValido });
        }

        [HttpPost("guardar")]
        public async Task<IActionResult> GuardarReceta(int pacienteId, int medicoId, [FromBody] int[] medicamentosIds)
        {
            var paciente = await _context.Pacientes
                .Include(p => p.ObraSocial)
                .Include(p => p.Cobertura)
                .FirstOrDefaultAsync(p => p.PacienteId == pacienteId);

            if (paciente == null) return NotFound("Paciente no encontrado");

            var medico = await _context.Medicos.FindAsync(medicoId);
            if (medico == null) return NotFound("Médico no encontrado");

            var cantidad = medicamentosIds.Length;
            if (!_recetaService.ValidarCantidadMedicamentos(paciente, cantidad))
                return BadRequest("La receta no cumple con las reglas de cantidad permitidas.");

            var receta = new Recetas
            {
                Paciente = $"{paciente.Nombre} {paciente.Apellido}",
                MedicoId = medico.MedicoId,
                CoberturaId = paciente.CoberturaId,
                RecetaMedicamentos = medicamentosIds.Select(id => new RecetaMedicamento { MedicamentoId = id }).ToList()
            };

            _context.Recetas.Add(receta);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Receta guardada correctamente", RecetaId = receta.RecetaId });
        }

        [HttpGet("ver/{recetaId}")]
        public async Task<IActionResult> VerReceta(int recetaId)
        {
            var receta = await _context.Recetas
                .Include(r => r.RecetaMedicamentos)
                    .ThenInclude(rm => rm.Medicamento)
                .Include(r => r.Cobertura)
                    .ThenInclude(c => c.ObraSocial)
                .Include(r => r.Medico)
                .FirstOrDefaultAsync(r => r.RecetaId == recetaId);

            if (receta == null) return NotFound("Receta no encontrada");

            var pdfBytes = _pdfSharpRecetaService.GenerateRecetaPdf(receta);

            return File(pdfBytes, "application/pdf", $"Receta_{recetaId}.pdf");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recetas = await _context.Recetas
                .Include(r => r.RecetaMedicamentos)
                    .ThenInclude(rm => rm.Medicamento)
                .Include(r => r.Cobertura)
                    .ThenInclude(c => c.ObraSocial)
                .Include(r => r.Medico)
                .ToListAsync();

            return Ok(recetas);
        }

        [HttpGet("ver-html/{recetaId}")]
        public async Task<IActionResult> VerRecetaHtml(int recetaId)
        {
            var receta = await _context.Recetas
                .Include(r => r.RecetaMedicamentos)
                    .ThenInclude(rm => rm.Medicamento)
                .Include(r => r.Cobertura)
                    .ThenInclude(c => c.ObraSocial)
                .Include(r => r.Medico)
                .FirstOrDefaultAsync(r => r.RecetaId == recetaId);

            if (receta == null) return NotFound("Receta no encontrada");

            var htmlContent = $@"
                <h1>Receta Médica</h1>
                <p>Paciente: {receta.Paciente}</p>
                <p>Médico: {receta.Medico.Nombre} {receta.Medico.Apellido} (Matricula: {receta.Medico.Matricula})</p>
                <p>Obra Social: {receta.Cobertura.ObraSocial.Nombre}</p>
                <p>Cobertura: {receta.Cobertura.Nombre}</p>
                <h3>Medicamentos:</h3>
                <ul>{string.Join("", receta.RecetaMedicamentos.Select(m => $"<li>{m.Medicamento.Nombre}</li>"))}</ul>";

            return Content(htmlContent, "text/html");
        }
    }
}
