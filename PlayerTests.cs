using System;

public static class PlayerTests
{
    private static void Check(string name, bool passed)
    {
        Console.WriteLine(name + ": " + (passed ? "PASS" : "FAIL"));
    }

    public static void Run()
    {
        Console.WriteLine("WEEK 2 TESTS");

        TestHorizontalWin();
        TestVerticalWin();
        TestComputerMove();
    }

    private static void TestHorizontalWin()
    {
        Board board = new Board();
        GameRules rules = new GameRules();

        board.PlaceMove(new Move(0, 0, 'X'));
        board.PlaceMove(new Move(0, 1, 'X'));
        board.PlaceMove(new Move(0, 2, 'X'));

        Check("Horizontal win", rules.IsWinner(board, 'X'));
    }

    private static void TestVerticalWin()
    {
        Board board = new Board();
        GameRules rules = new GameRules();

        board.PlaceMove(new Move(0, 1, 'O'));
        board.PlaceMove(new Move(1, 1, 'O'));
        board.PlaceMove(new Move(2, 1, 'O'));

        Check("Vertical win", rules.IsWinner(board, 'O'));
    }

    private static void TestComputerMove()
    {
        Board board = new Board();

        char[,] cells = {
            { 'X', 'O', 'X' },
            { 'X', 'O', 'O' },
            { 'O', 'X', ' ' }
        };

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (cells[row, col] != ' ')
                {
                    board.PlaceMove(
                        new Move(row, col, cells[row, col]));
                }
            }
        }

        ComputerPlayer computer = new ComputerPlayer('O');
        Move move = computer.GetMove(board);

        bool valid = move.Row >= 0 && move.Row < 3 &&
                     move.Col >= 0 && move.Col < 3;

        if (valid)
        {
            valid = board.GetCell(move.Row, move.Col) == ' ' &&
                    move.Symbol == computer.Symbol;
        }

        if (valid)
        {
            valid = board.PlaceMove(move);
        }

        Check("Computer chooses valid move", valid);
    }
}