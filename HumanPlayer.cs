using System;

public class HumanPlayer : IPlayer
{
    public Move GetMove(Board board, char symbol)
    {
        if (board == null)
            throw new ArgumentNullException(nameof(board));

        if (symbol != 'X' && symbol != 'O')
            throw new ArgumentException("Symbol must be X or O.");

        while (true)
        {
            int row = ReadCoordinate("Row");
            int col = ReadCoordinate("Column");

            if (board.GetCell(row, col) != ' ')
            {
                Console.WriteLine("That cell is already occupied.");
                continue;
            }

            return new Move(row, col, symbol);
        }
    }

    private int ReadCoordinate(string name)
    {
        while (true)
        {
            Console.Write(name + " (1-3): ");
            string? input = Console.ReadLine();

            if (input == null)
                throw new InvalidOperationException("No input was provided.");

            if (int.TryParse(input, out int value) && value >= 1 && value <= 3)
                return value - 1;

            Console.WriteLine("Please enter a number from 1 to 3.");
        }
    }
}
