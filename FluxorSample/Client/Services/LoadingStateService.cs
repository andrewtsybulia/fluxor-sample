using Fluxor;
using FluxorSample.Client.Features.Loading;

namespace FluxorSample.Client.Services;

public sealed class LoadingStateService : ILoadingStateService
{
    private readonly IDispatcher _dispatcher;

    public LoadingStateService(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async ValueTask PerformWithLoadAsync(Func<Task> operation)
    {
        var processId = Guid.NewGuid();

        try
        {
            _dispatcher.Dispatch(new SetLoadingOnAction(processId));
            await operation();
        }
        finally
        {
            _dispatcher.Dispatch(new SetLoadingOffAction(processId));
        }
    }
}





public interface ILoadingStateService { }
