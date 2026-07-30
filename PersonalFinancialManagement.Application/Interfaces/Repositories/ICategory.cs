namespace PersonalFinancialManagement.Application.Interfaces.Repositories;

public interface ICategory
{
    public Task<ICategory> FindCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
}