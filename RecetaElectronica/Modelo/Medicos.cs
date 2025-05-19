namespace RecetaElectronica.Modelo
{
    public class Medicos
    {
        public int MedicoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Matricula { get; set; }

        public ICollection<Recetas> RecetasEmitidas { get; set; }
    }
}
