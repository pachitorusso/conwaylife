using ConwayLife.Domain.Model;
using FluentAssertions;

namespace Test.ConwayLife.UnitTests.Domain;

public class BoardSizeTests
{
    const int Width = 10;
    const int Height = 10;
    private readonly BoardSize _boardSize;

    public BoardSizeTests()
    {
        // Arrange
        _boardSize = new BoardSize(Width, Height);
    }
    
    [Theory]
    [MemberData(nameof(InvalidWidthData))]
    public void IsOutOfBound_WhenXIs_Outside_Width_ShouldReturnTrue(int width)
    {
        // Act
        var result = _boardSize.IsOutOfBound(width, 0);

        // Assert
        result.Should().BeTrue();
    }
    
    [Theory]
    [MemberData(nameof(InvalidHeightData))]
    public void IsOutOfBound_WhenY_Is_Outside_Height_ShouldReturnTrue(int height)
    {
        // Act
        var result = _boardSize.IsOutOfBound(0, height);

        // Assert
        result.Should().BeTrue();
    }    
    
    public static IEnumerable<object[]> InvalidWidthData()
    {
        yield return new object[] { -1 };
        yield return new object[] { Width };
        yield return new object[] { Width + 1 };
    }
    
    public static IEnumerable<object[]> InvalidHeightData()
    {
        yield return new object[] { -1 };
        yield return new object[] { Height };
        yield return new object[] { Height + 1 };
    }
}