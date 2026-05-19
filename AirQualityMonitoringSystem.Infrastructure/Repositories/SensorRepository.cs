using AirQualityMonitoringSystem.Application.Interfaces;
using AirQualityMonitoringSystem.Domain.Entities;
using AirQualityMonitoringSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirQualityMonitoringSystem.Infrastructure.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _context;

        // Inyección del DbContext
        public SensorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los sensores
        public async Task<IEnumerable<SensorCalidadAire>> GetAllAsync()
        {
            return await _context.SensoresCalidadAire.ToListAsync();
        }

        // Obtener sensor por ID
        public async Task<SensorCalidadAire?> GetByIdAsync(int id)
        {
            return await _context.SensoresCalidadAire
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Agregar sensor
        public async Task AddAsync(SensorCalidadAire sensor)
        {
            await _context.SensoresCalidadAire.AddAsync(sensor);
        }

        // Guardar cambios
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}