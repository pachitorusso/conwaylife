using ConwayLife.Domain;
using ConwayLife.Domain.Model;

namespace ConwayLife.Application;

internal class GameUseCase : IGameUseCase
{
    private IGameRepository _gameRepository;

    public GameUseCase(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Guid> CreateGame(BoardSize boardSize, IEnumerable<AliveCell> aliveCells)
    {
        var game = new Game(new State(boardSize, new HashSet<AliveCell>(aliveCells)));
        
        await _gameRepository.Create(game);
        return game.Id;
    }

    public async Task<Game?> NextState(Guid id)
    {
        var game = await _gameRepository.Get(id);
        if (game is null) return null;
        
        game.NextSate();
        
        await _gameRepository.Update(game);

        return game;
    }

    public async Task<Game?> GetStateAway(Guid id, int steps)
    {
        var game = await _gameRepository.Get(id);
        if (game is null) return null;
        
        GetStateForAGivenSteps(steps, game);

        return game;
    }

    public async Task<bool?> IsFinalState(Guid id, IEnumerable<AliveCell> aliveCells, int steps)
    {
        var game = await _gameRepository.Get(id);
        if (game is null) return null;
        
        GetStateForAGivenSteps(steps, game);

        var finalState = aliveCells
            .All(x => game.State.AliveCells.Contains(x));

        return finalState ? finalState : throw new Exception("The game cannot be finished");
    }
    
    private static void GetStateForAGivenSteps(int steps, Game game)
    {
        for (var i = 0; i < steps; i++)
        {
            game.NextSate();
        }
    }    
    
}
