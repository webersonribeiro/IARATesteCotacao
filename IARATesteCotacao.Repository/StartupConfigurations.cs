using IARATesteCotacao.Data.Repositories;
using IARATesteCotacao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IARATesteCotacao.Data
{
    public static class StartupConfigurations
    {
        public static IServiceCollection AddRepositoriesDependencies(this IServiceCollection services)
        {            
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IQuotationRepository, QuotationRepository>();
            services.AddScoped<IItemQuotationRepository, ItemQuotationRepository>();
            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
