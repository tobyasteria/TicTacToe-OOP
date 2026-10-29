using System;

public class Board
{
    private char[,] cells = new char[3, 3];
    public Board()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                cells[row, col] = ' ';
            }
        }
    }
    public char GetCell(int row, int col)
    {
        return cells[row, col];
    }
    public bool PlaceMove(Move move)
    {
        if (move.Row < 0 || move.Row >= 3 || move.Col < 0 || move.Col >= 3)
            return false;

        if (move.Symbol != 'X' && move.Symbol != 'O')
            return false;

        if (cells[move.Row, move.Col] != ' ')
            return false;

        cells[move.Row, move.Col] = move.Symbol;
        return true;
    }
    public bool RemoveMove(int row, int col)
    {
        if (row < 0 || row >= 3 || col < 0 || col >= 3)
            return false;

        if (cells[row, col] == ' ')
            return false;

        cells[row, col] = ' ';
        return true;
    }
    public void PrintBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            Console.WriteLine($" {cells[row, 0]} | {cells[row, 1]} | {cells[row, 2]} ");
            if (row < 2)
                Console.WriteLine("-----------");
        }
    }
}
