using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Interfaces.DataAccess;
using TestProject.Infrastructure.DbContexts;

namespace TestProject.Infrastructure.Providers
{
    public class Transaction : ITransaction
    {
        private readonly WriteDbContext _dbContext;

        public Transaction(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
