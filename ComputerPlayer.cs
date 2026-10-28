
using System;
using System.Collections.Generic;

public class ComputerPlayer : IPlayer
{
    private Random random = new Random();

    public char Symbol { get; }

    public ComputerPlayer(char symbol)
    {
        if (symbol != 'X' && symbol != 'O')
        {
            throw new ArgumentException("Symbol must be X or O.");
        }

        Symbol = symbol;
    }

    public Move GetMove(Board board)
    {
        if (board == null)
        {
            throw new ArgumentNullException(nameof(board));
        }

        List<Move> emptyCells = new List<Move>();

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board.GetCell(row, col) == ' ')
                {
                    emptyCells.Add(new Move(row, col, Symbol));
                }
            }
        }

        if (emptyCells.Count == 0)
        {
            throw new InvalidOperationException("No empty cell!");
        }

        int index = random.Next(emptyCells.Count);

        return emptyCells[index];
    }
}
