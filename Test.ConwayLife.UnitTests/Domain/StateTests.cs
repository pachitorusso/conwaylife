using ConwayLife.Domain.Model;
using FluentAssertions;

namespace Test.ConwayLife.UnitTests.Domain;

public class StateTests
{
    
    [Theory]
    [MemberData(nameof(StateTransformationData))]
    public void State_NextState_Should_Transform(State actualState, State expectedState)
    {
        // Act
        var newState = actualState.NextState();
            
        // Assert
        newState.BoardSize.Should().Be(expectedState.BoardSize);
        newState.AliveCells.Should().Equal(expectedState.AliveCells);
    }
    
    
    [Fact]
    public void State_Get_CellType_Must_Return_Alive_Cell_If_It_Is_Alive()
    {
        // Arrange
        var state = new State(new BoardSize(10, 10), new HashSet<AliveCell>()
        {
            new (1,1)
        });
        
        // Act
        var cellTtype = state.GetCellType(1,1);
            
        cellTtype.Should().BeOfType<AliveCell>();
    }
    
    [Fact]
    public void State_GetCellType_Must_Return_DeadCell_If_It_Is_Not_Alive()
    {
        // Arrange
        var state = new State(new BoardSize(10, 10), new HashSet<AliveCell>()
        {
            new (1,1)
        });
        
        // Act
        var cellTtype = state.GetCellType(2,2);
            
        cellTtype.Should().BeOfType<DeadCell>();
    }  
    
    [Theory]
    [MemberData(nameof(CellNeigbousData))]
    public void GetAliveCellNeighbours_Must_Return_AliveAmount(BoardSize boardSize, HashSet<AliveCell> aliveCells, int x, int y, int expectedAliveNeighbours)
    {
        // Arrange
        var state = new State(boardSize, aliveCells);
        
        // Act
        var aliveNeighbours = state.GetAliveCellNeighbours(x, y);
            
        aliveNeighbours.Should().Be(expectedAliveNeighbours);
    }

    public static BoardSize BoardSize => new (5, 5);
    
    public static IEnumerable<object[]> StateTransformationData()
    {
        yield return new object[]
        {
            new State(BoardSize, new HashSet<AliveCell>(){new (1,2), new (2,2),new (3,2),}),
            new State(BoardSize, new HashSet<AliveCell>(){new (2,1), new (2,2),new (2,3),})
        };
        yield return new object[]
        {
            new State(BoardSize, new HashSet<AliveCell>(){new (1,1), new (2,2),new (3,3),}),
            new State(BoardSize, new HashSet<AliveCell>(){new (2,2)})
        };        
    }

    public static IEnumerable<object[]> CellNeigbousData()
    {
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (1,1)}, 0,0,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (1,1)}, 0,1,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (1,1)}, 0,2,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (1,1)}, 1,0,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (1,1)}, 1,1,0};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (1,1)}, 1,2,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (1,1)}, 2,0,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (1,1)}, 2,1,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (1,1)}, 2,2,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (0,0),new (0,1)}, 0,0,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (0,0),new (0,1)}, 0,1,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (0,0),new (0,1)}, 0,2,1};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (0,0),new (0,1)}, 1,0,2};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (0,0),new (0,1)}, 1,1,2};
        yield return new object[] { new BoardSize(3, 3), new HashSet<AliveCell>() {new (0,0),new (0,1)}, 1,2,1};
    }
}

