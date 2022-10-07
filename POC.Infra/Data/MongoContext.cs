using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using POC.Domain.Entities;
using POC.Domain.Interfaces;

using Microsoft.Extensions.Configuration;

namespace POC.Infra.Data;

public class MongoContext : IMongoContext
{
    public IMongoDatabase DB { get; }

    public MongoContext(IConfiguration configuration)
    {
        try
        {
            var settings =
                MongoClientSettings
                    .FromUrl(new MongoUrl(configuration["ConnectionString"]));
            var client = new MongoClient(settings);
            DB = client.GetDatabase(configuration["dbName"]);
            MapClasses();
        }
        catch (Exception ex)
        {
            throw new MongoException("It was not possible to connect to MongoDB",
                ex);
        }
    }

    private void MapClasses()
    {
        var conventionPack =
            new ConventionPack { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("camelCase", conventionPack, t => true);

        if (!BsonClassMap.IsClassMapRegistered(typeof(Product)))
        {
            BsonClassMap
                .RegisterClassMap<Product>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(Category)))
        {
            BsonClassMap
                .RegisterClassMap<Category>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
        }
    }
}
