using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data.Interceptors;

internal class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;

        if (context is null)
            return result;

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry is null || entry.State != EntityState.Deleted || !(entry is ISoftDeletable entity))
                continue;

            entry.State = EntityState.Modified;

            entity.Delete();
        }

        return result;
    }
}

