using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Features.ProductCategoryFolder;
using TestProject.Application.Interfaces.DataAccess;
using TestProject.Infrastructure.DbContexts;
using TestProject.Infrastructure.Interceptors;
using TestProject.Infrastructure.Providers;
using TestProject.Infrastructure.Queries.ProductCategories.GetPC;
using TestProject.Infrastructure.Queries.ProductCategories.GetProducts;
using TestProject.Infrastructure.Queries.Products.DraftProductResponse;
using TestProject.Infrastructure.Queries.Products.GetAllWithPC;
using TestProject.Infrastructure.Queries.Products.GetProductById;
using TestProject.Infrastructure.Repositories;

namespace TestProject.Infrastructure
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddDataStorages(configuration);
            services.AddRepositories();
            services.AddInterceptors();
            services.AddQueries();
            return services;
        }


        private static IServiceCollection AddDataStorages(this IServiceCollection services,
                                                              IConfiguration configuration)
        {
            services.AddScoped<ITransaction, Transaction>();
            services.AddScoped<WriteDbContext>();
            services.AddScoped<ReadDbContext>();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
           
            return services;
        }

        private static IServiceCollection AddInterceptors(this IServiceCollection services)
        {
            services.AddSingleton<DateInterceptor>();

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<GetByIdProductQuery>();
            services.AddScoped<GetPCProductsQuery>();
            services.AddScoped<GetAllWithPCQuery>();
            services.AddScoped<GetPCQuery>();

            services.AddScoped<DraftQuery>();
            
            return services;
        }
    }
}
