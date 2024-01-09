using ConwayLife.Domain.Model;

namespace ConwayLife.Application;

public interface IGameUseCase
{
    Task<Guid> CreateGame(BoardSize boardSize, IEnumerable<AliveCell> aliveCells);
    Task<Game?> NextState(Guid id);
    Task<Game?> GetStateAway(Guid id, int steps);

    Task<bool?> IsFinalState(Guid id, IEnumerable<AliveCell> aliveCells, int steps);
}