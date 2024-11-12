using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Features.ProductCategoryFolder;
using TestProject.Application.Features.ProductCategoryFolder.PublishProduct;

namespace TestProject.Application
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<PCHandler>();
            services.AddScoped<PublishProductHandler>();
            return services;
        }

    }

}
