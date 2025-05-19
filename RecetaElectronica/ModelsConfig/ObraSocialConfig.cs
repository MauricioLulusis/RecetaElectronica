using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Modelo;

namespace RecetaElectronica.ModelsConfig
{
    public class ObraSocialConfig : IEntityTypeConfiguration<ObraSocial>
    {
        public void Configure(EntityTypeBuilder<ObraSocial> builder)
        {
            builder.ToTable("ObrasSociales");
            builder.HasKey(o => o.ObraSocialId);

            builder.Property(o => o.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);
        }

        public static ObraSocial[] SeedData() => new ObraSocial[]
        {
            new ObraSocial { ObraSocialId = 1, Nombre = "Omint" },
            new ObraSocial { ObraSocialId = 2, Nombre = "Osde" },
            new ObraSocial { ObraSocialId = 3, Nombre = "Swiss Medical" }
        };
    }
}
