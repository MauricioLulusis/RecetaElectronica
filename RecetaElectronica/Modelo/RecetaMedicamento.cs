namespace RecetaElectronica.Modelo
{
    public class RecetaMedicamento
    {
        public int RecetaMedicamentoId { get; set; }

        public int RecetaId { get; set; }
        public Recetas Receta { get; set; }

        public int MedicamentoId { get; set; }  
        public Medicamentos Medicamento { get; set; }  
    }

}
