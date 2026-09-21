namespace PersonalFinancialManagement.Application.Abstractions;

public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> HandlerAsync(TQuery query, CancellationToken cancellationToken = default);
}