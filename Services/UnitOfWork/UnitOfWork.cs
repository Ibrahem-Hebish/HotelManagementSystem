namespace Services.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync()
       => await context.SaveChangesAsync();

    public async Task BeginTransaction()
        => await context.Database.BeginTransactionAsync();


    public async Task CommitTransaction()
       => await context.Database.CommitTransactionAsync();

    public async Task RollBack()
       => await context.Database.RollbackTransactionAsync();
}

