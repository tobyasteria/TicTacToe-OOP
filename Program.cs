
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== TIC TAC TOE ===");
        Console.WriteLine("1. Human vs Human");
        Console.WriteLine("2. Human vs Computer");
        Console.WriteLine("3. Run Week 1 Tests");
        Console.WriteLine("4. Run Week 3 Undo Tests");
        Console.Write("Choose mode: ");

        string? choice = Console.ReadLine();

        if (choice == "3")
        {
            Week1Tests.Run();
            return;
        }

        if (choice == "4")
        {
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
