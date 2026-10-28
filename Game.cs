
using System;

public class Game
{
    private Board board;
    private GameRules rules;
    private IPlayer player1;
    private IPlayer player2;
    private IPlayer currentPlayer;

    public Game(IPlayer p1, IPlayer p2)
    {
        if (p1.Symbol != 'X' || p2.Symbol != 'O')
            throw new ArgumentException("Player 1 must be X and Player 2 must be O.");

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
            Console.WriteLine("Player " + currentPlayer.Symbol + "'s turn");

            Move move = currentPlayer.GetMove(board);

            if (move.Symbol != currentPlayer.Symbol || !board.PlaceMove(move))
            {
                Console.WriteLine("Invalid move! Try again.");
                continue;
            }

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

    private void SwitchPlayer()
    {
        if (currentPlayer == player1)
            currentPlayer = player2;
        else
            currentPlayer = player1;
    }
}
