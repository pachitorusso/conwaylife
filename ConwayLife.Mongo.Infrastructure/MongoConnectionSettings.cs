namespace ConwayLife.Mongo.Infrastructure;

internal class MongoConnectionSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string GameCollectionName { get; set; } = null!;
}