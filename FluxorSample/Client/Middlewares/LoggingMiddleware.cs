using Fluxor;
using FluxorSample.Client.Features.Loading;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FluxorSample.Client.Middlewares;

public class LoggingMiddleware : Middleware
{
    private IStore Store;

    public IJSRuntime Js { get; }

    public LoggingMiddleware(IJSRuntime js)
    {
        Js = js;
    }

    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        Store = store;
        Js.InvokeVoidAsync($"console.log", nameof(InitializeAsync));
        return Task.CompletedTask;
    }

    public override void AfterInitializeAllMiddlewares()
    {
        Js.InvokeVoidAsync($"console.log", nameof(AfterInitializeAllMiddlewares));
    }

    public override bool MayDispatchAction(object action)
    {
        Js.InvokeVoidAsync($"console.log", nameof(MayDispatchAction));
        return true;
    }

    public override void BeforeDispatch(object action)
    {
        Js.InvokeVoidAsync($"console.log", nameof(BeforeDispatch));
    }

    public override void AfterDispatch(object action)
    {
        Js.InvokeVoidAsync($"console.log", nameof(AfterDispatch));
    }

    private string ObjectInfo(object obj)
        => ": " + obj.GetType().Name + " " + JsonConvert.SerializeObject(obj);
}
