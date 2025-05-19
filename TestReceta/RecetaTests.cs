using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecetaElectronica.Servicios;
using RecetaElectronica.Modelo;
using RecetaElectronica.Context;

public class RecetaTests
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

    private RecetaService GetServiceWithRegla(ReglaCantidad regla)
    {
        var context = new AppDbContext(GetDatabaseOptions());
        context.ReglaCantidades.Add(regla);
        context.SaveChanges();
        return new RecetaService(context);
    }

    [Fact]
    public void ValidarCantidadMedicamentos_DeberiaSerValido_SiNoHayRegla()
    {
        var paciente = new Pacientes { FechaNacimiento = DateTime.Today.AddYears(-30), ObraSocialId = 1, CoberturaId = 1 };
        var service = new RecetaService(new AppDbContext(GetDatabaseOptions()));

        var result = service.ValidarCantidadMedicamentos(paciente, 5);

        Assert.True(result);
    }

    [Fact]
    public void ValidarCantidadMedicamentos_DeberiaSerInvalido_SiCantidadMenorAlMinimo()
    {
        var paciente = new Pacientes { FechaNacimiento = DateTime.Today.AddYears(-30), ObraSocialId = 1, CoberturaId = 1 };
        var regla = new ReglaCantidad { ObraSocialId = 1, CoberturaId = 1, Minimo = 5, Maximo = 10, EdadMinima = 20, EdadMaxima = 40, Frecuencia = "Anual" };

        var service = GetServiceWithRegla(regla);

        var result = service.ValidarCantidadMedicamentos(paciente, 3);

        Assert.False(result);
    }

    [Fact]
    public void ValidarCantidadMedicamentos_DeberiaSerInvalido_SiCantidadMayorAlMaximo()
    {
        var paciente = new Pacientes { FechaNacimiento = DateTime.Today.AddYears(-30), ObraSocialId = 1, CoberturaId = 1 };
        var regla = new ReglaCantidad { ObraSocialId = 1, CoberturaId = 1, Minimo = 5, Maximo = 10, EdadMinima = 20, EdadMaxima = 40, Frecuencia = "Anual" };

        var service = GetServiceWithRegla(regla);

        var result = service.ValidarCantidadMedicamentos(paciente, 12);

        Assert.False(result);
    }

    [Fact]
    public void ValidarCantidadMedicamentos_DeberiaSerInvalido_SiEdadNoCumpleRegla()
    {
        var paciente = new Pacientes { FechaNacimiento = DateTime.Today.AddYears(-50), ObraSocialId = 1, CoberturaId = 1 };
        var regla = new ReglaCantidad { ObraSocialId = 1, CoberturaId = 1, Minimo = 5, Maximo = 10, EdadMinima = 20, EdadMaxima = 40, Frecuencia = "Anual" };

        var service = GetServiceWithRegla(regla);

        var result = service.ValidarCantidadMedicamentos(paciente, 6);

        Assert.True(result);
    }

    [Fact]
    public void ValidarCantidadMedicamentos_DeberiaSerValido_SiCumpleRegla()
    {
        var paciente = new Pacientes { FechaNacimiento = DateTime.Today.AddYears(-30), ObraSocialId = 1, CoberturaId = 1 };
        var regla = new ReglaCantidad { ObraSocialId = 1, CoberturaId = 1, Minimo = 5, Maximo = 10, EdadMinima = 20, EdadMaxima = 40, Frecuencia = "Anual" };

        var service = GetServiceWithRegla(regla);

        var result = service.ValidarCantidadMedicamentos(paciente, 7);

        Assert.True(result);
    }
}
