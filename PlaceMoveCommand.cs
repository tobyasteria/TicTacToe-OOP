
public class PlaceMoveCommand : IGameCommand
{
    private Board board;
    private Move move;
    private bool executed = false;

    public PlaceMoveCommand(Board board, Move move)
    {
        this.board = board;
        this.move = move;
    }

    public bool Execute()
    {
        if (executed)
            return false;

        if (!board.PlaceMove(move))
            return false;

        executed = true;
        return true;
    }

    public void Undo()
    {
        if (!executed)
            return;

        if (board.RemoveMove(move.Row, move.Col))
            executed = false;
    }
}
