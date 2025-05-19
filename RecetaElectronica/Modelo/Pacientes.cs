namespace RecetaElectronica.Modelo
{
    public class Pacientes
    {
        public int PacienteId { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int ObraSocialId { get; set; }
        public ObraSocial ObraSocial { get; set; }
        public int CoberturaId { get; set; }
        public Coberturas Cobertura { get; set; }

        public int Edad => DateTime.Today.Year - FechaNacimiento.Year -
            (DateTime.Today.DayOfYear < FechaNacimiento.DayOfYear ? 1 : 0);
    }
}
