namespace ObsWebSocket.Net;

internal sealed class InvocationBatchRequest
{
    private readonly CancellationTokenRegistration _cancellationTokenRegistration;

    private readonly TaskCompletionSource<IReadOnlyList<object?>> _completionSource =
        new(TaskCreationOptions.RunContinuationsAsynchronously);

    private InvocationBatchRequest(string requestId, CancellationToken cancellationToken)
    {
        _cancellationTokenRegistration =
            cancellationToken.Register(self => ((InvocationBatchRequest)self!).Cancel(), this);

        CancellationToken = cancellationToken;
        RequestId = requestId;
    }

    public string RequestId { get; }
    public CancellationToken CancellationToken { get; }

    private Task<IReadOnlyList<object?>> Result => _completionSource.Task;

    public void Dispose()
    {
        Cancel();
        _cancellationTokenRegistration.Dispose();
    }

    public static InvocationBatchRequest Invoke(string requestId,
        out Task<IReadOnlyList<object?>> result, CancellationToken cancellationToken)
    {
        var req = new InvocationBatchRequest(requestId, cancellationToken);
        result = req.Result;
        return req;
    }

    public void Complete(IReadOnlyList<object?> result)
    {
        _completionSource.TrySetResult(result);
    }

    private void Cancel()
    {
        _completionSource.TrySetCanceled();
    }
}