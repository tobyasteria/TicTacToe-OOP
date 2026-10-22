using System;

class Program
{
    static void Check(string name, bool passed)
    {
        Console.WriteLine(name + ": " + (passed ? "PASS" : "FAIL"));
    }

    static void Main()
    {
        Console.WriteLine("TIC-TAC-TOE - WEEK 1 TESTS");
        Board board = new Board();
        GameRules rules = new GameRules();

        Check("Valid move", board.PlaceMove(new Move(0, 0, 'X')));
        Check("Reject occupied cell", !board.PlaceMove(new Move(0, 0, 'O')));
        Check("Reject outside board", !board.PlaceMove(new Move(3, 0, 'O')));
        Check("Reject wrong symbol", !board.PlaceMove(new Move(0, 1, 'Z')));

        board.PlaceMove(new Move(1, 1, 'X'));
        board.PlaceMove(new Move(2, 2, 'X'));
        Check("X wins diagonally", rules.IsWinner(board, 'X'));
        Check("Win is not a draw", !rules.IsDraw(board));
        board.PrintBoard();

        Board drawBoard = new Board();
        char[,] pattern = {
            { 'X', 'O', 'X' },
            { 'X', 'O', 'O' },
            { 'O', 'X', 'X' }
        };
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                drawBoard.PlaceMove(new Move(row, col, pattern[row, col]));
            }
        }
        Check("Draw detection", rules.IsDraw(drawBoard));
        Console.WriteLine("Week 2: add Player types and the full game loop.");
    }
}
