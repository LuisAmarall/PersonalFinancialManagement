using Microsoft.EntityFrameworkCore;
using PersonalFinancialManagement.Core.Models.Entities;

namespace PersonalFinancialManagement.Infrastructure.Persistence.Context;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}