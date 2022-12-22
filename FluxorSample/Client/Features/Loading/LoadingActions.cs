namespace FluxorSample.Client.Features.Loading;

public record SetLoadingOnAction(Guid processId);

public record SetLoadingOffAction(Guid processId);
