using Microsoft.Extensions.DependencyInjection;
using POC.Infra.Data;

namespace POC.IoC;

public static class MongoDbDependency
{
    public static void AddMongoDependency(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<MongoContext>();    
    }
}
