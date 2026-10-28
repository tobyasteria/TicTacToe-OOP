using System;
using System.Collections.Generic;

public class ComputerPlayer : IPlayer
{
    private Random random = new Random();

    public Move GetMove(Board board, char symbol)
    {
        List<Move> emptyCells = new List<Move>();

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board.GetCell(row, col) == ' ')
                {
                    emptyCells.Add(new Move(row, col, symbol));
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