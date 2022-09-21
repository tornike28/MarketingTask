using Application.Shared;
using Domain.Aggregates.DistributorAggregate.IRepository;
using Domain.Aggregates.ProductAggregate.IRepository;
using Domain.Aggregates.TransactionAggregate.IRepository;
using Infrastructure.Repositories;

namespace MarketingTask
{
    public static class DI
    {
        public static void DependecyResolver(IServiceCollection services)
        {
            services.AddScoped<IQueryExecutor, QueryExecutor>();
            services.AddScoped<ICommandExecutor, CommandExecutor>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<HttpClient>();
            services.AddScoped<IDistributorRepository, DistributorRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }
    }
}
