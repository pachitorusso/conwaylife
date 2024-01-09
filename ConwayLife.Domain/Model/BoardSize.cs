namespace ConwayLife.Domain.Model;

public readonly record struct BoardSize(int Width, int Height);

public static class BoardSizeExtensions
{
    public static bool IsOutOfBound(this BoardSize boardSize, int x, int y)
    {
        return x < 0 || x >= boardSize.Width || y < 0 || y >= boardSize.Height;
    }
}