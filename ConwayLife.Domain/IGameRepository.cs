using ConwayLife.Domain.Model;

namespace ConwayLife.Domain;

public interface IGameRepository
{
    Task Create(Game game);
    Task<Game?> Get(Guid id);
    Task Update(Game game);
}