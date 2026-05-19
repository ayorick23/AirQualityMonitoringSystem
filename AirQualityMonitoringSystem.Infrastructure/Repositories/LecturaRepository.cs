using AirQualityMonitoringSystem.Application.Interfaces;
using AirQualityMonitoringSystem.Domain.Entities;
using AirQualityMonitoringSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirQualityMonitoringSystem.Infrastructure.Repositories
{
    public class LecturaRepository : ILecturaRepository
    {
        private readonly ApplicationDbContext _context;

        public LecturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Agregar lectura
        public async Task AddAsync(LecturaAire lectura)
        {
            await _context.LecturasAire.AddAsync(lectura);
        }

        // Filtrar lecturas
        public async Task<IEnumerable<LecturaAire>> GetFilteredAsync(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string? contaminante)
        {
            var query = _context.LecturasAire.AsQueryable();

            // Filtro fechas
            if (fechaInicio.HasValue)
            {
                query = query.Where(l => l.FechaHora >= fechaInicio.Value);
            }

            if (fechaFin.HasValue)
            {
                query = query.Where(l => l.FechaHora <= fechaFin.Value);
            }

            // Filtro contaminante
            if (!string.IsNullOrWhiteSpace(contaminante))
            {
                contaminante = contaminante.ToUpper();

                query = contaminante switch
                {
                    "PM2.5" => query.Where(l => l.PM2_5 > 0),
                    "PM10" => query.Where(l => l.PM10 > 0),
                    "CO2" => query.Where(l => l.CO2 > 0),
                    _ => query
                };
            }

            return await query.ToListAsync();
        }

        // Guardar cambios
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
