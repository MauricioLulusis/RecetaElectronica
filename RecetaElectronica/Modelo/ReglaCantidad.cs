namespace RecetaElectronica.Modelo
{
    public class ReglaCantidad
    {
        public int ReglaCantidadId { get; set; }
        public int ObraSocialId { get; set; }
        public int? CoberturaId { get; set; }
        public int? Minimo { get; set; }
        public int? Maximo { get; set; }
        public int? EdadMinima { get; set; }
        public int? EdadMaxima { get; set; }
        public string Frecuencia { get; set; }
        public decimal? TopeMonetario { get; set; }
        public ObraSocial ObraSocial { get; set; }
        public Coberturas Cobertura { get; set; }
    }
}
