using AirQualityMonitoringSystem.Application.DTOs.ClimaDTOs;
using System.Net.Http.Json;

namespace AirQualityMonitoringSystem.Application.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener clima externo
        public async Task<WeatherResponseDto?> GetWeatherAsync()
        {
            // Coordenadas San Salvador
            string url =
                "https://api.open-meteo.com/v1/forecast" +
                "?latitude=13.6929" +
                "&longitude=-89.2182" +
                "&current=temperature_2m,relative_humidity_2m";

            var response =
                await _httpClient.GetFromJsonAsync<WeatherResponseDto>(url);

            return response;
        }
    }
}