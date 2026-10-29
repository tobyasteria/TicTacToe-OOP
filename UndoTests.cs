using System;
using System.Collections.Generic;
using System.Reflection;

public static class UndoTests
{
    private static int passed = 0;
    private static int failed = 0;

    public static void Run()
    {
        passed = 0;
        failed = 0;

        Console.WriteLine("WEEK 3 UNDO TESTS");

        RunTest("Undo clears the X cell", TestUndoMove);
        RunTest("Can place a move again after Undo", TestPlaceAfterUndo);
        RunTest("Multiple Undo operations follow LIFO order", TestUndoLifo);
        RunTest("Undo with empty history does not throw", TestEmptyHistory);
        RunTest("Undo keeps the other moves", TestUndoKeepsOtherMoves);

        Console.WriteLine("Passed: " + passed + ", Failed: " + failed);
    }

    private static void RunTest(string name, Func<bool> test)
    {
        try
        {
            bool result = test();
            if (result)
                passed++;
            else
                failed++;

            Console.WriteLine(name + ": " + (result ? "PASS" : "FAIL"));
        }
        catch (Exception ex)
        {
            failed++;
            Console.WriteLine(name + ": FAIL");
            Console.WriteLine("  " + ex.GetType().Name + ": " + ex.Message);
        }
    }

    private static Game CreateGame()
    {
        return new Game(new HumanPlayer('X'), new HumanPlayer('O'));
    }

    private static Board GetBoard(Game game)
    {
        FieldInfo? field = typeof(Game).GetField(
            "board", BindingFlags.Instance | BindingFlags.NonPublic);

        if (field == null || field.GetValue(game) is not Board board)
            throw new InvalidOperationException("Cannot access Game board.");

        return board;
    }

    private static Stack<IGameCommand> GetHistory(Game game)
    {
        FieldInfo? field = typeof(Game).GetField(
            "moveHistory", BindingFlags.Instance | BindingFlags.NonPublic);

        if (field == null || field.GetValue(game) is not Stack<IGameCommand> history)
            throw new InvalidOperationException("Cannot access Game move history.");

        return history;
    }

    private static void AddMove(Game game, int row, int col, char symbol)
    {
        Board board = GetBoard(game);
        IGameCommand command = new PlaceMoveCommand(
            board, new Move(row, col, symbol));

        if (!command.Execute())
            throw new InvalidOperationException("Could not place test move.");

        GetHistory(game).Push(command);
    }

    private static void Undo(Game game)
    {
        MethodInfo? method = typeof(Game).GetMethod(
            "UndoLastTurn", BindingFlags.Instance | BindingFlags.NonPublic);

        if (method == null)
            throw new InvalidOperationException("Cannot find Game.UndoLastTurn().");

        method.Invoke(game, null);
    }

    private static bool TestUndoMove()
    {
        Game game = CreateGame();
        Board board = GetBoard(game);

        AddMove(game, 0, 0, 'X');
        Undo(game);

        return board.GetCell(0, 0) == ' ' && GetHistory(game).Count == 0;
    }

    private static bool TestPlaceAfterUndo()
    {
        Game game = CreateGame();
        Board board = GetBoard(game);

        AddMove(game, 0, 0, 'X');
        Undo(game);

        IGameCommand command = new PlaceMoveCommand(
            board, new Move(0, 0, 'X'));

        return command.Execute() && board.GetCell(0, 0) == 'X';
    }

    private static bool TestUndoLifo()
    {
        Game game = CreateGame();
        Board board = GetBoard(game);

        AddMove(game, 0, 0, 'X');
        AddMove(game, 0, 1, 'O');
        AddMove(game, 1, 0, 'X');

        Undo(game);
        bool firstUndo = board.GetCell(1, 0) == ' ' &&
                         board.GetCell(0, 0) == 'X' &&
                         board.GetCell(0, 1) == 'O';

        Undo(game);
        bool secondUndo = board.GetCell(0, 1) == ' ' &&
                          board.GetCell(0, 0) == 'X';

        Undo(game);
        bool thirdUndo = board.GetCell(0, 0) == ' ';

        return firstUndo && secondUndo && thirdUndo &&
               GetHistory(game).Count == 0;
    }

    private static bool TestEmptyHistory()
    {
        Game game = CreateGame();
        Board board = GetBoard(game);

        Undo(game);

        return GetHistory(game).Count == 0 &&
               board.GetCell(0, 0) == ' ' &&
               board.GetCell(1, 1) == ' ' &&
               board.GetCell(2, 2) == ' ';
    }

    private static bool TestUndoKeepsOtherMoves()
    {
        Game game = CreateGame();
        Board board = GetBoard(game);

        AddMove(game, 0, 0, 'X');
        AddMove(game, 0, 1, 'O');
        AddMove(game, 2, 2, 'X');

        Undo(game);

        return board.GetCell(2, 2) == ' ' &&
               board.GetCell(0, 0) == 'X' &&
               board.GetCell(0, 1) == 'O' &&
               GetHistory(game).Count == 2;
    }
}
