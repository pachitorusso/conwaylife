using ConwayLife.Domain.Model;
using FluentAssertions;

namespace Test.ConwayLife.UnitTests.Domain;

public class DeadCellTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    public void DeadCell_NextState_Should_Return_DeadCell_With_Neighbours_Distinct_Than_Three(int neighbours)
    {
        //Arrange
        var deadCell = new DeadCell(0, 0);
        
        //Act
        var nextState = deadCell.NextState(neighbours);
        
        //Assert
        nextState.Should().BeOfType<DeadCell>();
    }
    
    [Fact]
    public void DeadCell_NextState_Should_Return_AliveCell_With_Three_Neighbours()
    {
        //Arrange
        var deadCell = new DeadCell(0, 0);
        
        //Act
        var nextState = deadCell.NextState(3);
        
        //Assert
        nextState.Should().BeOfType<AliveCell>();
    }
}
