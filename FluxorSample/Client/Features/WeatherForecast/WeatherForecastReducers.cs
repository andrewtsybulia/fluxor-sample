using Fluxor;

namespace FluxorSample.Client.Features.WeatherForecast;

public static class WeatherForecastReducers
{
    [ReducerMethod]
    public static WeatherForecastState OnWeatherForecastSetAction(
        WeatherForecastState state, WeatherForecastSetAction action)
    {
        return state with
        {
            Data = action.Forecasts.ToList()
        };
    }
}
