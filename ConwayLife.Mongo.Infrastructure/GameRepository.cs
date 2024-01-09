using ConwayLife.Domain;
using ConwayLife.Domain.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ConwayLife.Mongo.Infrastructure;

internal class GameRepository : IGameRepository
{
    private readonly IMongoCollection<Game> _gameCollection;

    public GameRepository(IMongoClient mongoClient, IOptions<MongoConnectionSettings> dbSettings)
    {
        var database = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
        _gameCollection = database.GetCollection<Game>(dbSettings.Value.GameCollectionName);
    }

    /// <inheritdoc />
    public async Task Create(Game game) =>
        await _gameCollection.InsertOneAsync(game);

    /// <inheritdoc />
    public async Task<Game?> Get(Guid id) =>
        await _gameCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    /// <inheritdoc />
    public async Task Update(Game game) =>
        await _gameCollection.ReplaceOneAsync(x => x.Id == game.Id, game);
}