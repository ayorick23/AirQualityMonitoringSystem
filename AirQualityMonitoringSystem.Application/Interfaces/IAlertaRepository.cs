using AirQualityMonitoringSystem.Domain.Entities;

namespace AirQualityMonitoringSystem.Application.Interfaces
{
    public interface IAlertaRepository
    {
        Task AddAsync(AlertaAire alerta);

        Task<IEnumerable<AlertaAire>> GetAllAsync();

        Task SaveChangesAsync();
    }
}