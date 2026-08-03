using PersonalFinancialManagement.Core.Entities;

namespace PersonalFinancialManagement.Application.Interfaces.Repositories;

public interface ICategory
{
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    Task<IReadOnlyList<Category?>> GetAllCategories();
    Task<ICategory?> FindCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}