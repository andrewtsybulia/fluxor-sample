using Fluxor;
using FluxorSample.Client.Models;
using System.Net.Http.Json;

namespace FluxorSample.Client.Features.WeatherForecast;

public sealed class WeatherForecastEffects
{
    private readonly HttpClient? _httpClient;

    public WeatherForecastEffects(HttpClient? httpClient)
    {
        _httpClient = httpClient;
    }

    [EffectMethod]
    public async Task OnWeatherForecastInitialize(
        WeatherForecastInitializeAction action, IDispatcher dispatcher)
    {
        var response = await _httpClient!.GetFromJsonAsync<WeatherForecastData[]>("WeatherForecast");

        dispatcher.Dispatch(new WeatherForecastSetAction(response!));

        if (response.Length == 1)
        {

        }
        else if(response.Length == 2)
        {

        }
    }
}

