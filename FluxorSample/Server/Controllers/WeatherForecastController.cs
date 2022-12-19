using FluxorSample.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FluxorSample.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<string> Cities = new()
        {
            "Paris", "London", "Oslo", "New York", "Kyiv", "Madrid", "Dublin"
        };

        private static readonly string[] Countries = new[]
        {
            "France", "UK", "Norway", "USA", "Ukraine", "Spain", "Ireland"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            await Task.Delay(3000);

            return Enumerable.Range(1, 5).Select(index =>
            {
                var city = Cities[Random.Shared.Next(Cities.Count)];

                return new WeatherForecast
                {
                    Id = index,
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                    City = city,
                    Country = Countries[Cities.IndexOf(city)]
                };
            })
            .ToArray();
        }
    }
}