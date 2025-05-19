namespace RecetaElectronica.Modelo
{
    public class Coberturas
    {
        public int CoberturaId { get; set; }
        public string Nombre { get; set; }
        public int ObraSocialId { get; set; }
        public ObraSocial ObraSocial { get; set; }
    }
}
