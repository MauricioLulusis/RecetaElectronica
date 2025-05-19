using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Modelo;

namespace RecetaElectronica.ModelsConfig
{
    public class MedicosConfig : IEntityTypeConfiguration<Medicos>
    {
        public void Configure(EntityTypeBuilder<Medicos> builder)
        {
            builder.ToTable("Medicos");
            builder.HasKey(m => m.MedicoId);

            builder.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Apellido).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Matricula).IsRequired().HasMaxLength(20);
        }

        public static Medicos[] SeedData() => new Medicos[]
        {
            new Medicos { MedicoId = 1, Nombre = "Ricardo", Apellido = "Gonzalez", Matricula = "MP12345" },
            new Medicos { MedicoId = 2, Nombre = "Lucia", Apellido = "Martinez", Matricula = "MP54321" },
            new Medicos { MedicoId = 3, Nombre = "Juan", Apellido = "Lopez", Matricula = "MP98765" }
        };
    }
}
