using Fluxor;
using FluxorSample.Client.Features.WeatherForecast;

namespace FluxorSample.Client.Features.Loading;

public record LoadingState
{
    public bool IsLoading { get; set; }
}

public class LoadingFeature : Feature<LoadingState>
{
    public override string GetName() => nameof(LoadingState);

    protected override LoadingState GetInitialState() => new();
}