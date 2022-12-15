namespace FluxorSample.Client.Models;

public sealed record WeatherForecastData
{
    public int Id { get; init; }

    public DateTime Date { get; init; }

    public int TemperatureC { get; init; }

    public string? Summary { get; init; }

    public string? City { get; init; }

    public string? Country { get; init; }

}
