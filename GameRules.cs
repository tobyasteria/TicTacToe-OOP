public class GameRules
{
    public bool IsWinner(Board board, char symbol)
    {
        if (symbol != 'X' && symbol != 'O')
            return false;

        for (int i = 0; i < 3; i++)
        {
            // Three symbols in the same row
            if (board.GetCell(i, 0) == symbol &&
                board.GetCell(i, 1) == symbol &&
                board.GetCell(i, 2) == symbol)
                return true;

            // Three symbols in the same column
            if (board.GetCell(0, i) == symbol &&
                board.GetCell(1, i) == symbol &&
                board.GetCell(2, i) == symbol)
                return true;
        }

        if (board.GetCell(0, 0) == symbol &&
            board.GetCell(1, 1) == symbol &&
            board.GetCell(2, 2) == symbol)
            return true;

        if (board.GetCell(0, 2) == symbol &&
            board.GetCell(1, 1) == symbol &&
            board.GetCell(2, 0) == symbol)
            return true;

        return false;
    }

    public bool IsDraw(Board board)
    {
        if (IsWinner(board, 'X') || IsWinner(board, 'O'))
            return false;

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board.GetCell(row, col) == ' ')
                    return false;
            }
        }
        return true;
    }
}
