using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using IARATesteCotacao.Business.ProductsArea.UseCases.AddProduct;
using IARATesteCotacao.Business.ProductsArea.UseCases.GetProduct;
using IARATesteCotacao.Business.ProductsArea.UseCases.RemoveProduct;
using IARATesteCotacao.Business.ProductsArea.UseCases.UpdateProduct;
using IARATesteCotacao.Business.QuotationsArea.UseCases.AddQuotation;
using IARATesteCotacao.Business.QuotationsArea.UseCases.GetQuotation;
using IARATesteCotacao.Business.QuotationsArea.UseCases.RemoveQuotation;
using IARATesteCotacao.Business.QuotationsArea.UseCases.UpdateQuotation;
using IARATesteCotacao.Business.ProductsArea.UseCases.ListProduct;
using IARATesteCotacao.Business.QuotationsArea.UseCases.ListQuotation;
using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Business.Services.Locality;
using IARATesteCotacao.Business.ItensQuotationArea.UseCases.UpdateItensQuotation;
using IARATesteCotacao.Business.ItensQuotationArea.UseCases.AddItensQuotation;
using IARATesteCotacao.Business.ItensQuotationArea.UseCases.GetItensQuotation;
using IARATesteCotacao.Business.ItensQuotationArea.UseCases.RemoveItensQuotation;
using IARATesteCotacao.Business.ItensQuotationArea.UseCases.ListItensQuotation;

namespace IARATesteCotacao.Business
{
    public static class StartupConfigurations
    {
        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddProductHandler).Assembly);
            services.AddMediatR(typeof(GetProductHandler).Assembly);
            services.AddMediatR(typeof(RemoveProductHandler).Assembly);
            services.AddMediatR(typeof(UpdateProductHandler).Assembly);
            services.AddMediatR(typeof(ListProductHandler).Assembly);

            services.AddMediatR(typeof(AddQuotationHandler).Assembly);
            services.AddMediatR(typeof(GetQuotationHandler).Assembly);
            services.AddMediatR(typeof(RemoveQuotationHandler).Assembly);
            services.AddMediatR(typeof(UpdateQuotationHandler).Assembly);            
            services.AddMediatR(typeof(ListQuotationHandler).Assembly);

            services.AddMediatR(typeof(AddItensQuotationHandler).Assembly);
            services.AddMediatR(typeof(GetItensQuotationHandler).Assembly);
            services.AddMediatR(typeof(ListItensQuotationHandler).Assembly);
            services.AddMediatR(typeof(RemoveItensQuotationHandler).Assembly);            
            services.AddMediatR(typeof(UpdateItensQuotationHandler).Assembly);

            return services;
        }

        public static IServiceCollection ConfigureLocalityService(this IServiceCollection services)
        {
            services.AddScoped<ILocalityService, LocalityService>();
            return services;
        }
    }
}
