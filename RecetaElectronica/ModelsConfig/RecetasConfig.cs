using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Modelo;

namespace RecetaElectronica.ModelsConfig
{
    public class RecetasConfig : IEntityTypeConfiguration<Recetas>
    {
        public void Configure(EntityTypeBuilder<Recetas> builder)
        {
            // Tabla y Clave Primaria
            builder.ToTable("Recetas");
            builder.HasKey(r => r.RecetaId);

            // Campos requeridos
            builder.Property(r => r.Paciente)
                   .IsRequired()
                   .HasMaxLength(150);

            // Relaciones
            builder.HasOne(r => r.Medico)
                   .WithMany(m => m.RecetasEmitidas)
                   .HasForeignKey(r => r.MedicoId);

            builder.HasOne(r => r.Cobertura)
                   .WithMany()
                   .HasForeignKey(r => r.CoberturaId);

            builder.HasMany(r => r.RecetaMedicamentos)
                   .WithOne(rm => rm.Receta)
                   .HasForeignKey(rm => rm.RecetaId);
        }
    }
}
