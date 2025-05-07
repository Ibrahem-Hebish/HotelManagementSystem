namespace Services.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    Task BeginTransaction();
    Task CommitTransaction();
    Task RollBack();
}
