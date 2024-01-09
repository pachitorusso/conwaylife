using System.Text;

namespace ConwayLife.Domain.Model;

public record State (BoardSize BoardSize, HashSet<AliveCell> AliveCells)
{
    public State NextState()
    {
        var nextAliveCells = new HashSet<AliveCell>();
        

        for (int x = 0 ; x < BoardSize.Width; x++)
        {
            for (int y = 0; y < BoardSize.Height; y++)
            {
                var aliveNeighbours = GetAliveCellNeighbours(x, y);
                var currentCell = GetCellType(x, y);
                
                var nextCell = currentCell.NextState(aliveNeighbours);
                
                if(nextCell is AliveCell) nextAliveCells.Add((AliveCell)nextCell);                
            }
        } ;

        return new State(this.BoardSize, nextAliveCells);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var y = 0; y < BoardSize.Height; y++)
        {
            for (var x = 0; x < BoardSize.Width; x++)
            {                
                var cell = GetCellType(x, y);
                sb.Append(cell);
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }

    internal int GetAliveCellNeighbours(int x, int y)
    {
        var aliveNeighbours = 0;
        for (var hor = x - 1; hor <= x + 1; hor++)
        {
            for (var ver = y - 1; ver <= y + 1; ver++)
            {
                if (BoardSize.IsOutOfBound(hor, ver)) continue;
                
                // Same cell
                if (hor == x && ver == y) continue;
                
                if (AliveCells.Contains(new AliveCell(hor,ver)))
                    aliveNeighbours++;
            }
        }

        return aliveNeighbours;
        
    }
    
    internal ICell GetCellType(int x, int y)
    {
        var aliveCell = new AliveCell(x, y);
        return AliveCells.Contains(aliveCell) ? aliveCell : new DeadCell(x, y);
    }
}