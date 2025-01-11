namespace NetflixClone.Application.Common.Models;

public class Result
{
    public bool IsSuccess { get; }
    public string[] Errors { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, string[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }

    public static Result Failure(params string[] errors)
    {
        return new Result(false, errors);
    }
}

public class Result<T> : Result
{
    public T? Data { get; }

    private Result(T? data, bool isSuccess, string[] errors)
        : base(isSuccess, errors)
    {
        Data = data;
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(data, true, Array.Empty<string>());
    }

    public new static Result<T> Failure(params string[] errors)
    {
        return new Result<T>(default, false, errors);
    }
} 