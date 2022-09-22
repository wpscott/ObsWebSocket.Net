namespace ObsWebSocket.Net;

internal sealed class InvocationRequest : IDisposable
{
    private readonly CancellationTokenRegistration _cancellationTokenRegistration;

    private readonly TaskCompletionSource<object?> _completionSource =
        new(TaskCreationOptions.RunContinuationsAsynchronously);

    private InvocationRequest(string requestId, CancellationToken cancellationToken)
    {
        _cancellationTokenRegistration =
            cancellationToken.Register(self => ((InvocationRequest)self!).Cancel(), this);

        CancellationToken = cancellationToken;
        RequestId = requestId;
    }

    public string RequestId { get; }
    public CancellationToken CancellationToken { get; }

    private Task<object?> Result => _completionSource.Task;

    public void Dispose()
    {
        Cancel();
        _cancellationTokenRegistration.Dispose();
    }

    public static InvocationRequest Invoke(string requestId,
        out Task<object?> result, CancellationToken cancellationToken)
    {
        var req = new InvocationRequest(requestId, cancellationToken);
        result = req.Result;
        return req;
    }

    public void Complete(object? result)
    {
        _completionSource.TrySetResult(result);
    }

    private void Cancel()
    {
        _completionSource.TrySetCanceled();
    }
}