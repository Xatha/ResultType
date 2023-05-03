namespace ResultType.Option;

public static class OptionExtensions
{
    #region ToOption

    public static Option<T> ToOption<T>(this T? value) where T : class
    {
        return value is null ? Option<T>.None() : Option<T>.Some(value);
    }

    public static Option<T> ToOption<T>(this T? value) where T : struct
    {
        return value is null ? Option<T>.None() : Option<T>.Some(value.Value);
    }

    #endregion

    /*#region Transform
    
    public static Option<TResult> Transform<T1, T2, TResult>(
        this Option<T1> firstInput,
        Option<T2> secondInput,
        Func<T1, T2, TResult> func)
    {
        // We could have chained map calls, but that would create closures, which are easily avoidable by doing some 
        // non-functional programming behind the scenes.
        if (firstInput.IsSome && secondInput.IsSome)
        {
            return new Option<TResult>(func(firstInput.Value!, secondInput.Value!));
        }

        return Option<TResult>.None();
    }

    public static Option<TResult> Transform<T1, T2, T3, TResult>(
        this Option<T1> firstInput,
        Option<T2> secondInput,
        Option<T3> thirdInput,
        Func<T1, T2, T3, TResult> func)
    {
        if (firstInput.IsSome && secondInput.IsSome && thirdInput.IsSome)
        {
            return new Option<TResult>(func(firstInput.Value!, secondInput.Value!, thirdInput.Value!));
        }

        return Option<TResult>.None();
    }

    public static Option<TResult> Transform<T1, T2, T3, T4, TResult>(
        this Option<T1> firstInput,
        Option<T2> secondInput,
        Option<T3> thirdInput,
        Option<T4> fourthInput,
        Func<T1, T2, T3, T4, TResult> func)
    {
        if (firstInput.IsSome && secondInput.IsSome && thirdInput.IsSome && fourthInput.IsSome)
        {
            return new Option<TResult>(func(firstInput.Value!, secondInput.Value!, thirdInput.Value!,
                fourthInput.Value!));
        }

        return Option<TResult>.None();
    }

    public static Option<TResult> Transform<T1, T2, T3, T4, T5, TResult>(
        this Option<T1> firstInput,
        Option<T2> secondInput,
        Option<T3> thirdInput,
        Option<T4> fourthInput,
        Option<T5> fifthInput,
        Func<T1, T2, T3, T4, T5, TResult> func)
    {
        if (firstInput.IsSome && secondInput.IsSome && thirdInput.IsSome && fourthInput.IsSome && fifthInput.IsSome)
        {
            return new Option<TResult>(func(firstInput.Value!, secondInput.Value!, thirdInput.Value!,
                fourthInput.Value!, fifthInput.Value!));
        }

        return Option<TResult>.None();
    }

    public static Option<TResult> Transform<T1, T2, T3, T4, T5, T6, TResult>(
        this Option<T1> firstInput,
        Option<T2> secondInput,
        Option<T3> thirdInput,
        Option<T4> fourthInput,
        Option<T5> fifthInput,
        Option<T6> sixthInput,
        Func<T1, T2, T3, T4, T5, T6, TResult> func)
    {
        if (firstInput.IsSome && secondInput.IsSome && thirdInput.IsSome && fourthInput.IsSome && fifthInput.IsSome &&
            sixthInput.IsSome)
        {
            return new Option<TResult>(func(firstInput.Value!, secondInput.Value!, thirdInput.Value!,
                fourthInput.Value!, fifthInput.Value!, sixthInput.Value!));
        }

        return Option<TResult>.None();
    }
    
    #endregion*/
}