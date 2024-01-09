using ConwayLife.Domain.Model;

namespace ConwayLife;

public record ExpectedStateRequest(Guid Id, IEnumerable<AliveCell> AliveCells, int Steps);