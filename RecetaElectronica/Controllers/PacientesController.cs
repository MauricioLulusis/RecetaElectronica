using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Context;

namespace RecetaElectronica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _context.Pacientes.Include(p => p.ObraSocial).Include(p => p.Cobertura).ToListAsync();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _context.Pacientes.Include(p => p.ObraSocial).Include(p => p.Cobertura).FirstOrDefaultAsync(p => p.PacienteId == id);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }
    }
}
