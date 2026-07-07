using Microsoft.EntityFrameworkCore;
using PersonalFinancialManagement.Core.Entities;

namespace PersonalFinancialManagement.Infrastructure.Persistence.Context;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<ToPay> ToPay { get; set; }
    public DbSet<ToReceive> ToReceive { get; set; }
    public DbSet<Transaction> Transaction { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}