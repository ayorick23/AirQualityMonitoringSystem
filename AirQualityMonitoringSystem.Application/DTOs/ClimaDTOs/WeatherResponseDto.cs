namespace AirQualityMonitoringSystem.Application.DTOs.ClimaDTOs
{
    public class WeatherResponseDto
    {
        public CurrentWeatherDto Current { get; set; }
            = new CurrentWeatherDto();
    }

    public class CurrentWeatherDto
    {
        public double temperature_2m { get; set; }

        public int relative_humidity_2m { get; set; }
    }
}