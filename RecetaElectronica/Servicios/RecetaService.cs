using RecetaElectronica.Context;
using RecetaElectronica.Modelo;

namespace RecetaElectronica.Servicios
{
    public class RecetaService : IRecetaService
    {
        private readonly AppDbContext _context;

        public RecetaService(AppDbContext context)
        {
            _context = context;
        }

        public bool ValidarCantidadMedicamentos(Pacientes paciente, int cantidad)
        {
            int edad = paciente.Edad;

            var regla = _context.ReglaCantidades
                .Where(r => r.ObraSocialId == paciente.ObraSocialId &&
                            (r.CoberturaId == paciente.CoberturaId || r.CoberturaId == null) &&
                            (r.EdadMinima == null || edad >= r.EdadMinima) &&
                            (r.EdadMaxima == null || edad <= r.EdadMaxima))
                .OrderByDescending(r => r.EdadMinima)
                .FirstOrDefault();

            if (regla == null)
                return true;

            if (regla.TopeMonetario.HasValue)
                return true;

            if (regla.Minimo.HasValue && cantidad < regla.Minimo.Value)
                return false;

            if (regla.Maximo.HasValue && cantidad > regla.Maximo.Value)
                return false;

            return true;
        }
    }
}
