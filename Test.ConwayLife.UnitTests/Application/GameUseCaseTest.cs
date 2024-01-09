using ConwayLife.Application;
using ConwayLife.Domain;
using ConwayLife.Domain.Model;
using FluentAssertions;
using Moq;

namespace Test.ConwayLife.UnitTests.Application;

public class GameUseCaseTest
{
    [Fact]
    public async Task CreateGame_Calls_Repository_Create_Once()
    {
        // Arrange
        var gameRepository = new Mock<IGameRepository>();
        var gameUseCase = new GameUseCase(gameRepository.Object);
        
        // Act
        _ = await gameUseCase.CreateGame(new BoardSize(10, 10), new HashSet<AliveCell>());
        
        // Assert
        gameRepository.Verify(x => x.Create(It.IsAny<Game>()), Times.Once);
    }
    
    [Fact]
    public async Task NextState_Calls_Repository_Get_Once()
    {
        // Arrange
        var gameRepository = new Mock<IGameRepository>();
        var gameUseCase = new GameUseCase(gameRepository.Object);
        var id = Guid.NewGuid();
        
        
        // Act
        var game = await gameUseCase.NextState(id);
        
        // Assert
        gameRepository.Verify(x => x.Get(id), Times.Once);
    }
    
    [Fact]
    public async Task NextState_Return_Null_Not_Existing_Game()
    {
        // Arrange
        var gameRepository = new Mock<IGameRepository>();
        var gameUseCase = new GameUseCase(gameRepository.Object);
        var id = Guid.NewGuid();
        
        // Act
        var game = await gameUseCase.NextState(id);
        
        game.Should().BeNull();
    }
    
    [Fact]
    public async Task NextState_Calls_Repository_Update_Once()
    {
        // Arrange
        var gameRepository = new Mock<IGameRepository>();
        
        var id = Guid.NewGuid();
        
        var game = new Game(new State(new BoardSize(10, 10), new HashSet<AliveCell>()));

        gameRepository.Setup(x => x.Get(id))
            .ReturnsAsync(() => game);
        
        var gameUseCase = new GameUseCase(gameRepository.Object);
        
        
        // Act
        _ = await gameUseCase.NextState(id);
        
        //Assert
        gameRepository.Verify(x => x.Update(game), Times.Once);
    }
}