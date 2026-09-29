using PersonalFinancialManagement.Application.Abstractions;
using PersonalFinancialManagement.Application.Interfaces.Repositories;

namespace PersonalFinancialManagement.Application.Behaviors;

public class TransactionCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
    private readonly ICommandHandler<TCommand, TResult> _inner;
    private readonly IUnitOfWork _unitOfWork;

    public TransactionCommandHandlerDecorator(ICommandHandler<TCommand, TResult> inner, IUnitOfWork unitOfWork)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<TResult> HandlerAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            var result = await _inner.HandlerAsync(command, cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            return result;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
}