using Microsoft.EntityFrameworkCore;
using RecetaElectronica.Modelo;
using RecetaElectronica.ModelsConfig;

namespace RecetaElectronica.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Coberturas> Coberturas { get; set; }
        public DbSet<Medicamentos> Medicamentos { get; set; }
        public DbSet<ObraSocial> ObraSociales { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Recetas> Recetas { get; set; }
        public DbSet<RecetaMedicamento> RecetaMedicamentos { get; set; }
        public DbSet<ReglaCantidad> ReglaCantidades { get; set; }
        public DbSet<Medicos> Medicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Medicamentos
            modelBuilder.ApplyConfiguration(new MedicamentosConfig());
            modelBuilder.Entity<Medicamentos>().HasData(MedicamentosConfig.SeedData());

            // ObraSocial
            modelBuilder.ApplyConfiguration(new ObraSocialConfig());
            modelBuilder.Entity<ObraSocial>().HasData(ObraSocialConfig.SeedData());

            // Coberturas
            modelBuilder.ApplyConfiguration(new CoberturaConfig());
            modelBuilder.Entity<Coberturas>().HasData(CoberturaConfig.SeedData());

            // Pacientes
            modelBuilder.ApplyConfiguration(new PacienteConfig());
            modelBuilder.Entity<Pacientes>().HasData(PacienteConfig.SeedData());

            // Reglas de Cantidad
            modelBuilder.ApplyConfiguration(new ReglaCantidadConfig());
            modelBuilder.Entity<ReglaCantidad>().HasData(ReglaCantidadConfig.SeedData());

            modelBuilder.ApplyConfiguration(new MedicosConfig());
            modelBuilder.Entity<Medicos>().HasData(MedicosConfig.SeedData());

            modelBuilder.ApplyConfiguration(new RecetasConfig());

            modelBuilder.Entity<Pacientes>()
                .HasOne(p => p.ObraSocial)
                .WithMany()
                .HasForeignKey(p => p.ObraSocialId)
                .OnDelete(DeleteBehavior.Restrict);  // PROTEGEMOS LA OBRA SOCIAL

            modelBuilder.Entity<Pacientes>()
                .HasOne(p => p.Cobertura)
                .WithMany()
                .HasForeignKey(p => p.CoberturaId)
                .OnDelete(DeleteBehavior.Cascade);  // ELIMINA PACIENTES SI BORRAS UNA COBERTURA


            modelBuilder.Entity<RecetaMedicamento>()
                .HasOne(rm => rm.Receta)
                .WithMany(r => r.RecetaMedicamentos)
                .HasForeignKey(rm => rm.RecetaId);

            modelBuilder.Entity<RecetaMedicamento>()
                .HasOne(rm => rm.Medicamento)
                .WithMany()
                .HasForeignKey(rm => rm.MedicamentoId);



        }
    }
}
