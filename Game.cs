
using System;
using System.Collections.Generic;

public class Game
{
    private Board board;
    private GameRules rules;
    private IPlayer player1;
    private IPlayer player2;
    private IPlayer currentPlayer;

    // Store successful moves for Undo
    private Stack<IGameCommand> moveHistory = new Stack<IGameCommand>();

    public Game(IPlayer p1, IPlayer p2)
    {
        if (p1.Symbol != 'X' || p2.Symbol != 'O')
            throw new ArgumentException(
                "Player 1 must be X and Player 2 must be O.");

        board = new Board();
        rules = new GameRules();

        player1 = p1;
        player2 = p2;
        currentPlayer = player1;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");

        while (true)
        {
            board.PrintBoard();

            // Offer Undo only on a human player's turn
            if (currentPlayer is HumanPlayer && moveHistory.Count > 0)
            {
                Console.Write("Press U to undo, or Enter to continue: ");
                string? choice = Console.ReadLine();

                if (choice != null && choice.Trim().ToUpper() == "U")
                {
                    UndoLastTurn();
                    continue;
                }
            }

            Console.WriteLine("Player " + currentPlayer.Symbol + "'s turn");

            Move move = currentPlayer.GetMove(board);

            IGameCommand command = new PlaceMoveCommand(board, move);

            if (move.Symbol != currentPlayer.Symbol || !command.Execute())
            {
                Console.WriteLine("Invalid move! Try again.");
                continue;
            }

            // Save only successful moves
            moveHistory.Push(command);

            if (rules.IsWinner(board, currentPlayer.Symbol))
            {
                board.PrintBoard();
                Console.WriteLine("Player " + currentPlayer.Symbol + " wins!");
                break;
            }

            if (rules.IsDraw(board))
            {
                board.PrintBoard();
                Console.WriteLine("Game is a draw!");
                break;
            }

            SwitchPlayer();
        }
    }

    private void UndoLastTurn()
    {
        if (moveHistory.Count == 0)
        {
            Console.WriteLine("No moves to undo.");
            return;
        }

        // Human vs Human: undo one move
        int movesToUndo = 1;

        // Human vs Computer: undo both human and computer moves
        if (player2 is ComputerPlayer)
            movesToUndo = Math.Min(2, moveHistory.Count);

        for (int i = 0; i < movesToUndo; i++)
        {
            IGameCommand command = moveHistory.Pop();
            command.Undo();

            // Restore the player who made the undone move
            SwitchPlayer();
        }

        Console.WriteLine("Undo successful!");
    }

    private void SwitchPlayer()
    {
        if (currentPlayer == player1)
            currentPlayer = player2;
        else
            currentPlayer = player1;
    }
}
