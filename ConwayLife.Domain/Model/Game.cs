namespace ConwayLife.Domain.Model;

public class Game
{
    public Guid Id { get; private set; }
    
    public State State { get; private set; }

    public Game(State state)
    {
        Id = Guid.NewGuid();
        State = state;
    }

    public Game(Guid id, State state)
    {
        Id = id;
        State = state;
    }
    
    public Game NextSate()
    {
        var nextBoard = State.NextState();
        this.State = nextBoard;
        return this;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return State.ToString();
    }
}