using RecetaElectronica.Modelo;

namespace RecetaElectronica.Servicios
{
    public interface IRecetaService
    {
        bool ValidarCantidadMedicamentos(Pacientes paciente, int cantidad);
    }
}
