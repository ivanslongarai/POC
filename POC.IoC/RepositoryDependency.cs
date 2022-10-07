using Microsoft.Extensions.DependencyInjection;
using POC.Domain.Interfaces;
using POC.Infra.Repository;

namespace POC.IoC;

public static class RepositoryDependency
{
    public static void AddRepositoryDependency(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
    }
}
