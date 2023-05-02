namespace ResultType.Option;

public class Option<T> : IEquatable<Option<T>>
{
    private readonly T? _value;
    private readonly bool _isSome;

    private Option()
    {
        _value = default;
        _isSome = false;
    }

    private Option(T value)
    {
        _value = value;
        _isSome = true;
    }

    public static Option<T> Some(T value) => new(value);
    public static Option<T> None() => new();

    public Option<TResult> Map<TResult>(Func<T, TResult> func)
    {
        return _isSome ? new Option<TResult>(func(_value!)) : new Option<TResult>();
    }

    public Option<TResult> Map<TResult>(Func<T, Option<TResult>> func)
    {
        return _isSome ? func(_value!) : new Option<TResult>();
    }

    public T Collapse(T orElse)
    {
        return _isSome ? _value! : orElse;
    }

    //Lazily evaluated
    public T Collapse(Func<T> orElse)
    {
        return _isSome ? _value! : orElse();
    }

    public static bool operator ==(Option<T>? left, Option<T>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Option<T>? left, Option<T>? right)
    {
        return !Equals(left, right);
    }

    public bool Equals(Option<T>? other)
    {
        if (other is null) return false;
        return _value?.Equals(other._value) ?? false;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Option<T>)obj);
    }

    public override int GetHashCode() => _value?.GetHashCode() ?? 0;
}