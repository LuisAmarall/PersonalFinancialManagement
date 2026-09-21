
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PersonalFinancialManagement.Application.Abstractions
{
    public sealed class Result : IResult
    {
        public bool IsSuccess { get; }
        public IReadOnlyList<Error> Errors { get; }

        private Result(bool isSuccess, IReadOnlyList<Error> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }
        
        public static Result Success() => new Result(true, Array.Empty<Error>());

        public static Result Failure(IReadOnlyList<Error> erros)
        {
            ArgumentNullException.ThrowIfNull(erros);
            
            if (erros.Count == 0)
                throw new ArgumentException($"A failure must contain at least one error.", nameof(erros));

            return new Result(false, erros.ToList());
        }
    }
}