namespace PersonalFinancialManagement.Application.Abstractions;

public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    Task<TResult> HandlerAsync(TCommand command, CancellationToken cancellationToken = default);
}