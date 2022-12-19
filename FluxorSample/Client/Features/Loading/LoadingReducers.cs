using Fluxor;
using FluxorSample.Client.Features.WeatherForecast;

namespace FluxorSample.Client.Features.Loading;

public static class LoadingReducers
{
    [ReducerMethod]
    public static LoadingState OnLoadingSetOnAction(
        LoadingState state, SetLoadingOnAction action)
    {
        return state with
        {
            IsLoading = true
        };
    }

    [ReducerMethod]
    public static LoadingState OnLoadingSetOffAction(
        LoadingState state, SetLoadingOffAction action)
    {
        return state with
        {
            IsLoading = false
        };
    }
}
