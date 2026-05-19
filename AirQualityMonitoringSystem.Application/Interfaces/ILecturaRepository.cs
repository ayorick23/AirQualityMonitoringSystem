using AirQualityMonitoringSystem.Domain.Entities;

namespace AirQualityMonitoringSystem.Application.Interfaces
{
    public interface ILecturaRepository
    {
        Task AddAsync(LecturaAire lectura);

        Task<IEnumerable<LecturaAire>> GetFilteredAsync(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string? contaminante
        );

        Task SaveChangesAsync();
    }
}