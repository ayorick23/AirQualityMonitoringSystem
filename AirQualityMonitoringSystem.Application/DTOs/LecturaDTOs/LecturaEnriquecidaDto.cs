namespace AirQualityMonitoringSystem.Application.DTOs.LecturaDTOs
{
    public class LecturaEnriquecidaDto
    {
        public int SensorId { get; set; }

        public decimal PM2_5 { get; set; }

        public decimal PM10 { get; set; }

        public decimal CO2 { get; set; }

        public DateTime FechaHora { get; set; }

        public double Temperatura { get; set; }

        public int Humedad { get; set; }
    }
}