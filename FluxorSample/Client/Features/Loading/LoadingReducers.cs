using Fluxor;

namespace FluxorSample.Client.Features.Loading;

public static class LoadingReducers
{
    [ReducerMethod]
    public static LoadingState OnLoadingSetOnAction(
        LoadingState state, SetLoadingOnAction action)
    {
        state.SetLoadingProcess(action.processId);
        return state;
    }

    [ReducerMethod]
    public static LoadingState OnLoadingSetOffAction(
        LoadingState state, SetLoadingOffAction action)
    {
        state.RemoveLoadingProcess(action.processId);
        return state;
    }
}
