using Microsoft.EntityFrameworkCore;
using AirQualityMonitoringSystem.Domain.Entities;

namespace AirQualityMonitoringSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tabla SensorCalidadAire
        public DbSet<SensorCalidadAire> SensoresCalidadAire { get; set; }

        // Tabla LecturaAire
        public DbSet<LecturaAire> LecturasAire { get; set; }

        // Tabla AlertaAire
        public DbSet<AlertaAire> AlertasAire { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración relación Sensor - Lecturas
            modelBuilder.Entity<LecturaAire>()
                .HasOne(l => l.Sensor)
                .WithMany(s => s.Lecturas)
                .HasForeignKey(l => l.SensorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración relación Sensor - Alertas
            modelBuilder.Entity<AlertaAire>()
                .HasOne(a => a.Sensor)
                .WithMany(s => s.Alertas)
                .HasForeignKey(a => a.SensorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}