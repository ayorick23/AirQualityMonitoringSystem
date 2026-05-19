using AirQualityMonitoringSystem.Domain.Entities;

namespace AirQualityMonitoringSystem.Application.Interfaces
{
    public interface ISensorRepository
    {
        Task<IEnumerable<SensorCalidadAire>> GetAllAsync();

        Task<SensorCalidadAire?> GetByIdAsync(int id);

        Task AddAsync(SensorCalidadAire sensor);

        Task SaveChangesAsync();
    }
}