namespace RecetaElectronica.Modelo
{
    public class Recetas
    {

        public int RecetaId { get; set; }

        public string Paciente { get; set; }

        // Relación con Medico
        public int MedicoId { get; set; }
        public Medicos Medico { get; set; }

        // Relación con Cobertura
        public int CoberturaId { get; set; }
        public Coberturas Cobertura { get; set; }

        // Relación con Medicamentos
        public ICollection<RecetaMedicamento> RecetaMedicamentos { get; set; }
    }
}

