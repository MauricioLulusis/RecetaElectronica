using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Context;

namespace RecetaElectronica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicamentos = await _context.Medicamentos.ToListAsync();
            return Ok(medicamentos);
        }
    }
}
