using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Modelo;

namespace RecetaElectronica.ModelsConfig
{
    public class ReglaCantidadConfig : IEntityTypeConfiguration<ReglaCantidad>
    {
        public void Configure(EntityTypeBuilder<ReglaCantidad> builder)
        {
            builder.ToTable("ReglasCantidad");
            builder.HasKey(r => r.ReglaCantidadId);

            builder.Property(r => r.Frecuencia)
                   .HasMaxLength(50);
        }

        public static ReglaCantidad[] SeedData() => new ReglaCantidad[]
{
    // Omint2000
    new ReglaCantidad { ReglaCantidadId = 1, CoberturaId = 1, Maximo = 5, Minimo = 0, EdadMinima = 50, EdadMaxima = 0, Frecuencia = "Indefinido", TopeMonetario = 0, ObraSocialId = 1 },
    new ReglaCantidad { ReglaCantidadId = 2, CoberturaId = 1, Maximo = 3, Minimo = 0, EdadMinima = 0, EdadMaxima = 49, Frecuencia = "Indefinido", TopeMonetario = 0, ObraSocialId = 1 },

    // Omint2000K
    new ReglaCantidad { ReglaCantidadId = 3, CoberturaId = 2, Maximo = 3, Minimo = 0, EdadMinima = 0, EdadMaxima = 0, Frecuencia = "Indefinido", TopeMonetario = 0, ObraSocialId = 1 },

    // SMg30
    new ReglaCantidad { ReglaCantidadId = 4, CoberturaId = 4, Maximo = 2, Minimo = 0, EdadMinima = 18, EdadMaxima = 0, Frecuencia = "Indefinido", TopeMonetario = 0, ObraSocialId = 3 },

    // SMg50
    new ReglaCantidad { ReglaCantidadId = 5, CoberturaId = 5, Maximo = 5, Minimo = 0, EdadMinima = 50, EdadMaxima = 0, Frecuencia = "Indefinido", TopeMonetario = 0, ObraSocialId = 3 },
    new ReglaCantidad { ReglaCantidadId = 6, CoberturaId = 5, Maximo = 3, Minimo = 0, EdadMinima = 0, EdadMaxima = 49, Frecuencia = "Indefinido", TopeMonetario = 0, ObraSocialId = 3 },

    // SMgPlatinum
    new ReglaCantidad { ReglaCantidadId = 7, CoberturaId = 6, Maximo = 0, Minimo = 0, EdadMinima = 0, EdadMaxima = 0, Frecuencia = "Indefinido", TopeMonetario = 40000, ObraSocialId = 3 },

    // Osde210 - 8 anuales
    new ReglaCantidad { ReglaCantidadId = 8, CoberturaId = 7, Maximo = 8, Minimo = 0, EdadMinima = 0, EdadMaxima = 0, Frecuencia = "Anual", TopeMonetario = 0, ObraSocialId = 2 },

    // Osde310 - 2 mensuales
    new ReglaCantidad { ReglaCantidadId = 9, CoberturaId = 8, Maximo = 2, Minimo = 0, EdadMinima = 0, EdadMaxima = 0, Frecuencia = "Mensual", TopeMonetario = 0, ObraSocialId = 2 },

    // Osde450 - 30 anuales
    new ReglaCantidad { ReglaCantidadId = 10, CoberturaId = 9, Maximo = 30, Minimo = 0, EdadMinima = 0, EdadMaxima = 0, Frecuencia = "Anual", TopeMonetario = 0, ObraSocialId = 2 }
};

    }
}
