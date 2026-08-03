using Microsoft.EntityFrameworkCore;
using PersonalFinancialManagement.Core.Entities;
using PersonalFinancialManagement.Infrastructure.Persistence.Context;
using PersonalFinancialManagement.Application.Interfaces.Repositories;

namespace PersonalFinancialManagement.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddCategory(Category category)
    {
        _context.Category.Add(category);
    }

    public void UpdateCategory(Category category)
    {
        var existingCategory = _context.Category.AsNoTracking().FirstOrDefault(_ => _.Id == category.Id);

        _context.Entry(existingCategory).CurrentValues.SetValues(category);
        _context.Update(existingCategory);
    }

    public async Task<Category?> FindCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Category.AsNoTracking().FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Category?>> GetAllCategories()
    {
        return await _context.Category.AsNoTracking().ToListAsync();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}