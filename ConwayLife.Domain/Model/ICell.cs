namespace ConwayLife.Domain.Model;

public interface ICell
{
    int X { get; }
    int Y { get; }
    ICell NextState(int aliveNeighbours);
}