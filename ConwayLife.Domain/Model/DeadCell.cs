namespace ConwayLife.Domain.Model;

public readonly record struct DeadCell(int X, int Y) : ICell
{
    public ICell NextState(int aliveNeighbours) =>
        aliveNeighbours switch
        {
            3 => new AliveCell(X, Y),
            _ => this
        };

    /// <inheritdoc />
    public override string ToString() => "X";
    
}