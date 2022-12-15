using Fluxor;
using FluxorSample.Client.Models;

namespace FluxorSample.Client.Features.WeatherForecast;

public sealed record WeatherForecastState
{
    public List<WeatherForecastData>? Data { get; init; }
}

public sealed class WeatherForecastFeature : Feature<WeatherForecastState>
{
    public override string GetName() => nameof(WeatherForecastState);

    protected override WeatherForecastState GetInitialState() => new();
}
