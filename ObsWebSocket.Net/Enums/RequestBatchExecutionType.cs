namespace ObsWebSocket.Net.Enums;

public enum RequestBatchExecutionType : sbyte
{
    /// <summary>
    ///     Not a request batch.
    /// </summary>
    None = -1,

    /// <summary>
    ///     <para>A request batch which processes all requests serially, as fast as possible.</para>
    ///     <remarks>
    ///         Note: To introduce artificial delay, use the <see cref="Requests.Sleep" /> request and the
    ///         <see cref="Requests.Sleep.SleepMillis" /> request
    ///         field.
    ///     </remarks>
    /// </summary>
    SerialRealtime,

    /// <summary>
    ///     <para>
    ///         A request batch type which processes all requests serially, in sync with the graphics thread. Designed to
    ///         provide high accuracy for animations.
    ///     </para>
    ///     <remarks>
    ///         Note: To introduce artificial delay, use the <see cref="Requests.Sleep" /> request and the
    ///         <see cref="Requests.Sleep.SleepFrames" /> request
    ///         field.
    ///     </remarks>
    /// </summary>
    SerialFrame,

    /// <summary>
    ///     <para>A request batch type which processes all requests using all available threads in the thread pool.</para>
    ///     <remarks>
    ///         Note: This is mainly experimental, and only really shows its colors during requests which require lots of
    ///         active processing, like <see cref="Requests.GetSourceScreenshot" />.
    ///     </remarks>
    /// </summary>
    Parallel
}