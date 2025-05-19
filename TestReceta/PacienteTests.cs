using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecetaElectronica.Context;
using RecetaElectronica.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReceta
{
    public class PacienteTests
    {
        private DbContextOptions<AppDbContext> GetDatabaseOptions()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            return new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        [Fact]
        public void CrearPaciente_DeberiaFallar_SiDniEsVacio()
        {
            var paciente = new Pacientes { Dni = "", Nombre = "Juan", Apellido = "Perez", Telefono = "123456", Direccion = "Calle Falsa 123", FechaNacimiento = DateTime.Today.AddYears(-25), ObraSocialId = 1, CoberturaId = 1 };
            var result = ValidarPaciente(paciente);

            Assert.False(result);
        }

        [Fact]
        public void CrearPaciente_DeberiaFallar_SiEsMenorDeUnAno()
        {
            var paciente = new Pacientes { Dni = "12345678", Nombre = "Bebe", Apellido = "RecienNacido", Telefono = "123456", Direccion = "Calle Falsa 123", FechaNacimiento = DateTime.Today, ObraSocialId = 1, CoberturaId = 1 };
            var result = ValidarPaciente(paciente);

            Assert.False(result);
        }

        [Fact]
        public void CrearPaciente_DeberiaSerValido_SiDatosSonCorrectos()
        {
            var paciente = new Pacientes { Dni = "12345678", Nombre = "Pedro", Apellido = "Gomez", Telefono = "123456", Direccion = "Calle Falsa 123", FechaNacimiento = DateTime.Today.AddYears(-25), ObraSocialId = 1, CoberturaId = 1 };
            var result = ValidarPaciente(paciente);

            Assert.True(result);
        }

        [Fact]
        public void CrearPaciente_DeberiaFallar_SiCoberturaNoExiste()
        {
            var paciente = new Pacientes { Dni = "12345678", Nombre = "Laura", Apellido = "Lopez", Telefono = "123456", Direccion = "Calle Falsa 123", FechaNacimiento = DateTime.Today.AddYears(-25), ObraSocialId = 1, CoberturaId = 999 };
            var result = ValidarPaciente(paciente);

            Assert.False(result);
        }

        [Fact]
        public void CrearPaciente_DeberiaFallar_SiObraSocialNoExiste()
        {
            var paciente = new Pacientes { Dni = "12345678", Nombre = "Martin", Apellido = "Lopez", Telefono = "123456", Direccion = "Calle Falsa 123", FechaNacimiento = DateTime.Today.AddYears(-25), ObraSocialId = 999, CoberturaId = 1 };
            var result = ValidarPaciente(paciente);

            Assert.False(result);
        }

        // Método de validación simulado para los tests
        private bool ValidarPaciente(Pacientes paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.Dni)) return false;
            if ((DateTime.Today.Year - paciente.FechaNacimiento.Year) < 1) return false;

            using var context = new AppDbContext(GetDatabaseOptions());
            var obraSocialExiste = context.ObraSociales.Any(o => o.ObraSocialId == paciente.ObraSocialId);
            var coberturaExiste = context.Coberturas.Any(c => c.CoberturaId == paciente.CoberturaId);

            return obraSocialExiste && coberturaExiste;
        }
    }
}
