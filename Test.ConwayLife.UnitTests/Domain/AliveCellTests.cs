using ConwayLife.Domain.Model;
using FluentAssertions;

namespace Test.ConwayLife.UnitTests.Domain;

public class AliveCellTests
{
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void AliveCell_NextState_Should_Return_AliveCell_With_2_3_Neighbourds(int neighbours)
    {
        // Arrange
        var aliveCell = new AliveCell(0, 0);
        
        // Act
        var nextState = aliveCell.NextState(neighbours);
        
        // Assert
        nextState.Should().BeOfType<AliveCell>();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void AliveCel_NextState_Should_Return_DeadCell_With_Less_Than_2_Neighbours(int neighbours)
    {
        // Arrange
        var aliveCell = new AliveCell(0, 0);
        
        // Act
        var nextState = aliveCell.NextState(neighbours);
        
        // Assert
        nextState.Should().BeOfType<DeadCell>();
    }
    
    [Theory]
    [InlineData(4)]
    [InlineData(5)]
    public void AliveCel_NextState_Should_Return_DeadCell_With_More_Than_3_Neighbours(int neighbours)
    {
        // Arrange
        var aliveCell = new AliveCell(0, 0);
        
        // Act
        var nextState = aliveCell.NextState(neighbours);
        
        // Assert
        nextState.Should().BeOfType<DeadCell>();
    }
}