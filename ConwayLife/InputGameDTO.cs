using ConwayLife.Domain.Model;

namespace ConwayLife;

public record InputGameDTO(BoardSize BoardSize, IEnumerable<AliveCell> AliveCells);