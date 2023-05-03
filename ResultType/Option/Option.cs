namespace ResultType.Option;

// Used for cleaner syntax when using creating a new Option with a value.
public static class Option
{
    public static Option<T> Some<T>(T value)
    {
        return new(value);
    }
}

public class Option<T> : IEquatable<Option<T>>
{
    private readonly bool _isSome;
    private readonly T? _value;

    private Option()
    {
        _value = default;
        _isSome = false;
    }

    internal Option(T value)
    {
        _value = value;
        _isSome = true;
    }

    public static Option<T> Some(T value)
    {
        return new(value);
    }

    public static Option<T> None()
    {
        return new();
    }

    #region Map

    public Option<TResult> Map<TResult>(Func<T, TResult> func)
    {
        return _isSome ? new Option<TResult>(func(_value!)) : new Option<TResult>();
    }

    public Option<TResult> Map<TResult>(Func<T, Option<TResult>> func)
    {
        return _isSome ? func(_value!) : new Option<TResult>();
    }

    #endregion

    #region Collapse

    public T Collapse(T orElse)
    {
        return _isSome ? _value! : orElse;
    }

    //Lazily evaluated
    public T Collapse(Func<T> orElse)
    {
        return _isSome ? _value! : orElse();
    }

    #endregion

    #region Cast

    public Option<TResult> Cast<TResult>()
    {
        return _value is TResult casted ? Option.Some(casted) : Option<TResult>.None();
    }

    #endregion
    
    #region Transform

    public Option<TResult> Transform<T1, TResult>(
        Option<T1> arg1,
        Func<T, T1, TResult> func)
    {
        if (_isSome && arg1._isSome)
        {
            return new Option<TResult>(func(_value!, arg1._value!));
        }

        return Option<TResult>.None();
    }

    public Option<TResult> Transform<T1, T2, TResult>(
        Option<T1> arg1,
        Option<T2> arg2,
        Func<T, T1, T2, TResult> func)
    {
        if (_isSome && arg1._isSome && arg2._isSome)
        {
            return new Option<TResult>(func(_value!, arg1._value!, arg2._value!));
        }

        return Option<TResult>.None();
    }

    public Option<TResult> Transform<T1, T2, T3, TResult>(
        Option<T1> arg1,
        Option<T2> arg2,
        Option<T3> arg3,
        Func<T, T1, T2, T3, TResult> func)
    {
        if (_isSome && arg1._isSome && arg2._isSome && arg3._isSome)
        {
            return new Option<TResult>(func(_value!, arg1._value!, arg2._value!, arg3._value!));
        }

        return Option<TResult>.None();
    }

    public Option<TResult> Transform<T1, T2, T3, T4, TResult>(
        Option<T1> arg1,
        Option<T2> arg2,
        Option<T3> arg3,
        Option<T4> arg4,
        Func<T, T1, T2, T3, T4, TResult> func)
    {
        if (_isSome && arg1._isSome && arg2._isSome && arg3._isSome && arg4._isSome)
        {
            return new Option<TResult>(func(_value!, arg1._value!, arg2._value!, arg3._value!,
                arg4._value!));
        }

        return Option<TResult>.None();
    }

    public Option<TResult> Transform<T1, T2, T3, T4, T5, TResult>(
        Option<T1> arg1,
        Option<T2> arg2,
        Option<T3> arg3,
        Option<T4> arg4,
        Option<T5> arg5,
        Func<T, T1, T2, T3, T4, T5, TResult> func)
    {
        if (_isSome && arg1._isSome && arg2._isSome && arg3._isSome && arg4._isSome &&
            arg5._isSome)
        {
            return new Option<TResult>(func(_value!, arg1._value!, arg2._value!, arg3._value!,
                arg4._value!, arg5._value!));
        }

        return Option<TResult>.None();
    }

    #endregion

    #region Operators

    public static bool operator ==(Option<T>? left, Option<T>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Option<T>? left, Option<T>? right)
    {
        return !Equals(left, right);
    }

    #endregion

    #region Equals & GetHashCode Overrides

    public bool Equals(Option<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        return _value?.Equals(other._value) ?? false;
    }
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj?.GetType() == GetType() && Equals((Option<T>)obj);
    }

    public override int GetHashCode()
    {
        return _value?.GetHashCode() ?? 0;
    }

    #endregion
}