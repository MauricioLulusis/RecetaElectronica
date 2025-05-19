using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecetaElectronica.Modelo;

namespace RecetaElectronica.ModelsConfig
{
    public class MedicamentosConfig : IEntityTypeConfiguration<Medicamentos>
    {
        public void Configure(EntityTypeBuilder<Medicamentos> builder)
        {
            builder.ToTable("Medicamentos");
            builder.HasKey(m => m.MedicamentoId);

            builder.Property(m => m.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);
        }

        public static Medicamentos[] SeedData() => new Medicamentos[]
        {
            new Medicamentos { MedicamentoId = 1, Nombre = "Paracetamol 500mg" },
            new Medicamentos { MedicamentoId = 2, Nombre = "Ibuprofeno 400mg" },
            new Medicamentos { MedicamentoId = 3, Nombre = "Amoxicilina 500mg" },
            new Medicamentos { MedicamentoId = 4, Nombre = "Azitromicina 500mg" },
            new Medicamentos { MedicamentoId = 5, Nombre = "Omeprazol 20mg" },
            new Medicamentos { MedicamentoId = 6, Nombre = "Losartán 50mg" },
            new Medicamentos { MedicamentoId = 7, Nombre = "Atorvastatina 20mg" },
            new Medicamentos { MedicamentoId = 8, Nombre = "Metformina 850mg" },
            new Medicamentos { MedicamentoId = 9, Nombre = "Levotiroxina 50mcg" },
            new Medicamentos { MedicamentoId = 10, Nombre = "Salbutamol Inhalador" },
            new Medicamentos { MedicamentoId = 11, Nombre = "Amiodarona 200mg" },
            new Medicamentos { MedicamentoId = 12, Nombre = "Clonazepam 0.5mg" },
            new Medicamentos { MedicamentoId = 13, Nombre = "Sertralina 50mg" },
            new Medicamentos{ MedicamentoId = 14, Nombre = "Cetirizina 10mg" },
            new Medicamentos { MedicamentoId = 15, Nombre = "Loratadina 10mg" },
            new Medicamentos{ MedicamentoId = 16, Nombre = "Diclofenac 75mg" },
            new Medicamentos { MedicamentoId = 17, Nombre = "Ranitidina 150mg" },
            new Medicamentos { MedicamentoId = 18, Nombre = "Fluconazol 150mg" },
            new Medicamentos{ MedicamentoId = 19, Nombre = "Enalapril 10mg" },
            new Medicamentos { MedicamentoId = 20, Nombre = "Carvedilol 25mg" },
        };
    }
}
