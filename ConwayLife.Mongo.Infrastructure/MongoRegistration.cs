using ConwayLife.Domain;
using ConwayLife.Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace ConwayLife.Mongo.Infrastructure;

public static class MongoRegistration
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        services.AddSingleton<IGameRepository, GameRepository>();
        services.AddSingleton<IMongoClient>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<MongoConnectionSettings>>().Value;
            return new MongoClient(settings.ConnectionString);
        });
        return services;
    }

    public static IServiceCollection ConfigureMongo(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<MongoConnectionSettings>(configuration.GetSection(nameof(MongoConnectionSettings)));
        
        BsonClassMap.RegisterClassMap<Game>(map =>
        {
            map.AutoMap();
            map.MapIdMember(x => x.Id);
            map.MapMember(c => c.Id).SetSerializer(new GuidSerializer(BsonType.String));            
        });
        
        return services;
    }
}