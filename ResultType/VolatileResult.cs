namespace ResultType;

/// <summary>
/// Volatile result is a result that is not stable. It is not safe to use since there is no guarantee that a value or ResultError will be there.
/// </summary>
/// <typeparam name="TResult">Type of the result</typeparam>
public readonly struct VolatileResult<TResult>
{
    /// <summary>
    /// Value of the result, if it is a success.
    /// </summary>
    public TResult Value { get; }
    
    /// <summary>
    /// Error of the result, if it is a failure.
    /// </summary>
    public ResultError ResultError { get; }
    
    /// <summary>
    /// Whether the result is a success.
    /// </summary>
    public bool IsSuccess { get; }
    
    internal VolatileResult(TResult value)
    {
        Value = value;
        ResultError = default;
        IsSuccess = true;
    }
    
    internal VolatileResult(ResultError resultError)
    {
        Value = default;
        ResultError = resultError;
        IsSuccess = false;
    }


    public static implicit operator (TResult, ResultError) (VolatileResult<TResult> value)
    {
        return value.IsSuccess ? (value.Value, default) : (default, value.ResultError);
    }
}