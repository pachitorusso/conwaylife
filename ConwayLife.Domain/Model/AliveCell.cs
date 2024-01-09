namespace ConwayLife.Domain.Model;

public readonly record struct AliveCell(int X, int Y) : ICell
{
    public ICell NextState(int aliveNeighbours) =>
        aliveNeighbours switch
        {
            < 2 => new DeadCell(X, Y),
            > 3 => new DeadCell(X, Y),
            _ => this
        };

    /// <inheritdoc />
    public override string ToString() => "O";
}