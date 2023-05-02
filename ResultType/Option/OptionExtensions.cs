namespace ResultType.Option;

public static class OptionExtensions
{
    public static Option<T> ToOption<T>(this T? value)
    {
        return value is null ? Option<T>.None() : Option<T>.Some(value);
    }
}