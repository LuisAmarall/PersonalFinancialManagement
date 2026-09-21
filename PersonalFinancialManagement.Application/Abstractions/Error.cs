namespace PersonalFinancialManagement.Application.Abstractions;

public enum ErrorCode
{
    NotFound,
    Conflict,
    Validation,
    Unauthorized,
    Failure
}

public sealed record Error
{
    public string Code { get; }
    public string Message { get; }
    public ErrorCode ErrorType { get; }

    private Error(string code, string message, ErrorCode errorType)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
    }

    public static Error Create(string code, string message, ErrorCode errorType = ErrorCode.Failure)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        ArgumentException.ThrowIfNullOrWhiteSpace(message);

        return new Error(code, message, errorType);
    }

    public static Error NotFound(string code, string message) => Create(code, message, ErrorCode.NotFound);
    public static Error Conflict(string code, string message) => Create(code, message, ErrorCode.Conflict);
    public static Error Validation(string code, string message) => Create(code, message, ErrorCode.Validation);
    public static Error Unauthorized(string code, string message) => Create(code, message, ErrorCode.Unauthorized);
    public static Error Failure(string code, string message) => Create(code, message, ErrorCode.Failure);
    
    public override string ToString() => $"{Code}: {Message}";
}