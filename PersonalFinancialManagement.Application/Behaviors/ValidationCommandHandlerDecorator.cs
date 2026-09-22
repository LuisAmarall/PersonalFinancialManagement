using FluentValidation;
using PersonalFinancialManagement.Application.Abstractions;

namespace PersonalFinancialManagement.Application.Behaviors;

public class ValidationCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    private readonly ICommandHandler<TCommand, TResult> _inner;
    private readonly IEnumerable<IValidator<TCommand>> _validators;

    public ValidationCommandHandlerDecorator(ICommandHandler<TCommand, TResult> inner, IEnumerable<IValidator<TCommand>>validators)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _validators = validators ?? throw new ArgumentNullException(nameof(validators));
    }

    public async Task<TResult> HandlerAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        var context = new ValidationContext<TCommand>(command);
        var failures = _validators.Select(v => v.Validate(context)).SelectMany(result => result.Errors).Where(f => f != null).ToList();

        if (failures.Count != 0) 
            throw new ValidationException(failures);
        
        return await _inner.HandlerAsync(command, cancellationToken);
    }
}