using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Infrastructure.ReadModels;

namespace TestProject.Infrastructure.DbContexts
{
    public class ReadDbContext : DbContext
    {
        private readonly IConfiguration _configuration;


        public ReadDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<PCReadModel> PCReadModels => Set<PCReadModel>();
        public DbSet<ProductReadModel> ProductReadModels => Set<ProductReadModel>();
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TestProject"));

            optionsBuilder.UseSnakeCaseNamingConvention();

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ReadDbContext).Assembly,
                type => type.FullName?.Contains("Configurations.Read") ?? false);
        }
    }
}
