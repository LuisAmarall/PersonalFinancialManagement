using Polly;
using PersonalFinancialManagement.Application.Abstractions;

namespace PersonalFinancialManagement.Application.Behaviors;

public class RetryCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult> 
    where TCommand : ICommand<TResult>
{
    private readonly ICommandHandler<TCommand, TResult> _inner;
    private readonly IAsyncPolicy _retryPolicy;

    public RetryCommandHandlerDecorator(ICommandHandler<TCommand, TResult> inner, IAsyncPolicy retryPolicy)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _retryPolicy = retryPolicy ?? throw new ArgumentNullException(nameof(retryPolicy));
    }

    public Task<TResult> HandlerAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        return _retryPolicy.ExecuteAsync(ct => _inner.HandlerAsync(command, ct), cancellationToken);
    }
}