using Fluxor;
using FluxorSample.Client.Features.Loading;
using FluxorSample.Client.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;

namespace FluxorSample.Client.Features.WeatherForecast;

public delegate Task PerformWithLoadAsync(IDispatcher dispatcher, Func<Task> operation);

public abstract class EffectBase
{

}

public sealed class WeatherForecastEffects : EffectBase
{
    private readonly HttpClient? _httpClient;
    private readonly PerformWithLoadAsync performWithLoadAsync;

    public WeatherForecastEffects(HttpClient? httpClient, PerformWithLoadAsync performWithLoadAsync)
    {
        _httpClient = httpClient;
        this.performWithLoadAsync = performWithLoadAsync;
    }

    [EffectMethod]
    public async Task OnWeatherForecastInitialize(
        WeatherForecastInitializeAction action, IDispatcher dispatcher)
    {
        var operation = async () =>
        {
            var response = await _httpClient!.GetFromJsonAsync<WeatherForecastData[]>("WeatherForecast");

            dispatcher.Dispatch(new WeatherForecastSetAction(response!));

            if (response.Length == 1)
            {

            }
            else if (response.Length == 2)
            {

            }
        };
        await performWithLoadAsync(dispatcher, operation);
    }
}

