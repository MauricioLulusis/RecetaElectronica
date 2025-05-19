using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Modelo;

namespace RecetaElectronica.ModelsConfig
{
    public class CoberturaConfig : IEntityTypeConfiguration<Coberturas>
    {
        public void Configure(EntityTypeBuilder<Coberturas> builder)
        {
            builder.ToTable("Coberturas");
            builder.HasKey(c => c.CoberturaId);
            builder.Property(c => c.Nombre)
            .IsRequired()
            .HasMaxLength(100);
        }

        public static Coberturas[] SeedData() => new Coberturas[]
        {
            new Coberturas { CoberturaId = 1, Nombre = "Omint2000", ObraSocialId = 1 },
            new Coberturas { CoberturaId = 2, Nombre = "Omint2000K", ObraSocialId = 1 },
            new Coberturas { CoberturaId = 3, Nombre = "Omint2500K", ObraSocialId = 1 },
            new Coberturas { CoberturaId = 4, Nombre = "Smg30", ObraSocialId = 3 },
            new Coberturas { CoberturaId = 5, Nombre = "Smg50", ObraSocialId = 3 },
            new Coberturas { CoberturaId = 6, Nombre = "SmgPlatinum", ObraSocialId = 3 },
            new Coberturas { CoberturaId = 7, Nombre = "Osde210", ObraSocialId = 2 },
            new Coberturas { CoberturaId = 8, Nombre = "Osde310", ObraSocialId = 2 },
            new Coberturas { CoberturaId = 9, Nombre = "Osde450", ObraSocialId = 2 }
        };
    }
}
