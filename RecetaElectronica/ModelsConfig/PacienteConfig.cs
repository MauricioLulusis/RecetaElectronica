using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Modelo;

namespace RecetaElectronica.ModelsConfig
{
    public class PacienteConfig : IEntityTypeConfiguration<Pacientes>
    {
        public void Configure(EntityTypeBuilder<Pacientes> builder)
        {
            builder.ToTable("Pacientes");
            builder.HasKey(p => p.PacienteId);

            builder.Property(p => p.Dni).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Apellido).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Telefono).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Direccion).IsRequired().HasMaxLength(255);
            builder.Property(p => p.FechaNacimiento).IsRequired();
        }

        public static Pacientes[] SeedData() => new Pacientes[]
        {
            new Pacientes
            {
                PacienteId = 1,
                Dni = "12345678",
                Nombre = "Juan",
                Apellido = "Perez",
                Telefono = "3764000000",
                Direccion = "Calle Falsa 123",
                FechaNacimiento = new DateTime(1970, 1, 1),
                ObraSocialId = 1,
                CoberturaId = 1
            },
            new Pacientes
            {
                PacienteId = 2,
                Dni = "23456789",
                Nombre = "María",
                Apellido = "Gomez",
                Telefono = "3764111111",
                Direccion = "Avenida Siempre Viva 742",
                FechaNacimiento = new DateTime(1985, 5, 12),
                ObraSocialId = 2,
                CoberturaId = 7
            },
            new Pacientes
            {
                PacienteId = 4,
                Dni = "45678901",
                Nombre = "Laura",
                Apellido = "Fernandez",
                Telefono = "3764333333",
                Direccion = "Boulevard Mitre 321",
                FechaNacimiento = new DateTime(2005, 3, 15),
                ObraSocialId = 3,
                CoberturaId = 4
            },
            new Pacientes
            {
                PacienteId = 5,
                Dni = "56789012",
                Nombre = "Diego",
                Apellido = "Martinez",
                Telefono = "3764444444",
                Direccion = "Los Pinos 789",
                FechaNacimiento = new DateTime(1950, 7, 8),
                ObraSocialId = 3,
                CoberturaId = 5
            },
            new Pacientes
            {
                PacienteId = 6,
                Dni = "67890123",
                Nombre = "Sofia",
                Apellido = "Diaz",
                Telefono = "3764555555",
                Direccion = "Ruta Nacional 12 Km 20",
                FechaNacimiento = new DateTime(1999, 12, 1),
                ObraSocialId = 1,
                CoberturaId = 2
            },
            new Pacientes
            {
                PacienteId = 7,
                Dni = "78901234",
                Nombre = "Lucas",
                Apellido = "Silva",
                Telefono = "3764666666",
                Direccion = "Barrio Centro Manzana 10",
                FechaNacimiento = new DateTime(2010, 9, 25),
                ObraSocialId = 3,
                CoberturaId = 6
            }
        };
    }
}
