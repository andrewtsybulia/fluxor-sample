using FluxorSample.Client.Models;

namespace FluxorSample.Client.Features.WeatherForecast;

public sealed record WeatherForecastInitializeAction();

public sealed record WeatherForecastSetAction(WeatherForecastData[] Forecasts);

public sealed record WeatherForecastUpdateCitiesAction(IEnumerable<string> Cities);
