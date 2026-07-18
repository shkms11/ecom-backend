namespace EcommerceAPI.Application.Common.Models;

public class Result
{
    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }

    public static Result Success() => new(true, Array.Empty<string>());

    public static Result Failure(IEnumerable<string> errors) => new(false, errors);
}

public class Result<T> : Result
{
    private Result(bool succeeded, T? value, IEnumerable<string> errors)
        : base(succeeded, errors)
    {
        Value = value;
    }

    public T? Value { get; }

    public static Result<T> Success(T value) => new(true, value, Array.Empty<string>());

    public static Result<T> Failure(IEnumerable<string> errors) => new(false, default, errors);
}
