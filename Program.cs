
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== TIC TAC TOE ===");
        Console.WriteLine("1. Human vs Human");
        Console.WriteLine("2. Human vs Computer");
        Console.WriteLine("6. Run All Tests");
        Console.Write("Choose mode: ");

        string? choice = Console.ReadLine();

        if (choice == "6")
        {
            Week1Tests.Run();
            PlayerTests.Run();
            UndoTests.Run();
            return;
        }

        if (choice != "1" && choice != "2")
        {
            Console.WriteLine("Invalid choice!");
            return;
        }

        IPlayer player1 = new HumanPlayer('X');
        IPlayer player2;

        if (choice == "1")
            player2 = new HumanPlayer('O');
        else
            player2 = new ComputerPlayer('O');

        Game game = new Game(player1, player2);
        game.Start();
    }
}
