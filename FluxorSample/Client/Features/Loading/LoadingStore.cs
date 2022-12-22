using Fluxor;

namespace FluxorSample.Client.Features.Loading;

public sealed record LoadingState
{
    private static object _locker = new();
    private HashSet<Guid>? _loadingProcessIds = new();

    public bool IsLoading => _loadingProcessIds is not null && _loadingProcessIds.Any();

    public void SetLoadingProcess(Guid proccessId)
    {
        ProceedConcurrentlySafe(() => _loadingProcessIds?.Add(proccessId));
    }

    public void RemoveLoadingProcess(Guid proccessId)
    {
        ProceedConcurrentlySafe(() => _loadingProcessIds?.Remove(proccessId));
    }

    private static void ProceedConcurrentlySafe(Action action)
    {
        lock (_locker)
        {
            action();
        }
    }
}

public class LoadingFeature : Feature<LoadingState>
{
    public override string GetName() => nameof(LoadingState);

    protected override LoadingState GetInitialState() => new();
}