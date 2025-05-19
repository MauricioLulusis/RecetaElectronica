namespace RecetaElectronica.Modelo
{
    public class ObraSocial
    {
        public int ObraSocialId { get; set; }
        public string Nombre { get; set; }
        public ICollection<Coberturas> Coberturas { get; set; }
    }
}
