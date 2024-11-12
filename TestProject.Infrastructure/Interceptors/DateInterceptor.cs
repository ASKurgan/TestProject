using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Interfaces.Auditable;
using TestProject.Infrastructure.DbContexts;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject.Infrastructure.Interceptors
{
    public class DateInterceptor : SaveChangesInterceptor
    {
      public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                        InterceptionResult<int> result,
                                        CancellationToken cancellationToken = new CancellationToken())
        {
            var dbContext = eventData.Context;
            if (dbContext == null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }


            var entries = dbContext.ChangeTracker.Entries<IAuditable>()
              .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
              .ToList();


            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(x => x.CreatedAt).CurrentValue = DateTimeOffset.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(x => x.UpdatedAt).CurrentValue = DateTimeOffset.UtcNow;
                }
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }



        //public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        // DbContextEventData eventData,
        // InterceptionResult<int> result,
        // CancellationToken cancellationToken = default)
        //{
        //    await Date(eventData, cancellationToken);

        //    return result;
        //}

        //private async Task Date(DbContextEventData eventData, CancellationToken ct)
        //{
        //    var scope = _scopeFactory.CreateScope();
        //    var dbContext = scope.ServiceProvider.GetRequiredService<WriteDbContext>();

        //    if (eventData.Context is null)
        //        return;

        //    if (dbContext == null)
        //        return;

        //    var entries = dbContext.ChangeTracker.Entries<IAuditable>()
        //                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
        //                .ToList();

        //    foreach (var entry in entries)
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
        //        }
        //    }
        //    await dbContext.SaveChangesAsync();
        //}

    }
}
