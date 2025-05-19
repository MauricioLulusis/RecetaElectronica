using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Context;

namespace RecetaElectronica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicos = await _context.Medicos.ToListAsync();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null) return NotFound();
            return Ok(medico);
        }
    }
}
