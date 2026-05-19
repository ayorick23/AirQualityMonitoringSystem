using AirQualityMonitoringSystem.Application.Interfaces;
using AirQualityMonitoringSystem.Domain.Entities;
using AirQualityMonitoringSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirQualityMonitoringSystem.Infrastructure.Repositories
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly ApplicationDbContext _context;

        public AlertaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Agregar alerta
        public async Task AddAsync(AlertaAire alerta)
        {
            await _context.AlertasAire.AddAsync(alerta);
        }

        // Obtener alertas
        public async Task<IEnumerable<AlertaAire>> GetAllAsync()
        {
            return await _context.AlertasAire.ToListAsync();
        }

        // Guardar cambios
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}