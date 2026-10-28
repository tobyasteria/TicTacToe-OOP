
public interface IPlayer
{
    char Symbol { get; }

    Move GetMove(Board board);
}
