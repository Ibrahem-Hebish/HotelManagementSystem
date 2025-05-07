namespace Services.Decorators.UnitOfWorkDecorators;

public class Logger(IUnitOfWork inner) : IUnitOfWork
{
    public async Task BeginTransaction()
    {
        Log.Information("Logging from service layer : Transaction begin");

        await inner.BeginTransaction();

        Log.Information("Logging from service layer : Transaction ended");
    }

    public async Task CommitTransaction()
    {
        Log.Information("Logging from service layer : Commit begin");

        await inner.CommitTransaction();
    }

    public async Task RollBack()
    {
        Log.Information("Logging from service layer : RollBack begin");

        await inner.RollBack();
    }

    public async Task<int> SaveChangesAsync()
    {
        Log.Information("Logging from service layer : Saving Changes");

        return await inner.SaveChangesAsync();
    }
}
