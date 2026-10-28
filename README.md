
# Tic-Tac-Toe OOP — Week 2 (C#)

A C# console application extending Week 1 to build a fully playable Tic-Tac-Toe game using Object-Oriented Programming (OOP) principles.

Week 2 introduces the `IPlayer` interface, supporting both Human vs Human and Human vs Computer gameplay modes, while keeping the original Week 1 tests.

## Files

- `Move.cs`: Stores move coordinates (row, column) and player symbol.
- `Board.cs`: Manages the board state, move placement, validation, and console display.
- `GameRules.cs`: Checks winning conditions (rows, columns, diagonals) and draw detection.
- `IPlayer.cs`: Defines the common interface for player types.
- `HumanPlayer.cs`: Handles keyboard input and validates player coordinates.
- `ComputerPlayer.cs`: Selects a random legal move from available empty cells.
- `Game.cs`: Controls the game loop, turn switching, and win/draw checking.
- `Program.cs`: Provides the main menu and starts the selected game mode.
- `Week1Tests.cs`: Contains the seven original tests from Week 1.

## How to Run

Requirements:
- .NET 8 SDK
- Visual Studio Code or another C# development environment

Open a terminal in the project folder and run:

```bash
dotnet run
```

## Menu Options

1. **Human vs Human** — Two human players take turns using X and O.
2. **Human vs Computer** — A human player (X) plays against a computer (O).
3. **Run Week 1 Tests** — Runs the original seven tests to verify core functionality.

Players enter row and column numbers from 1 to 3.

## Week 2 Features

- Human vs Human gameplay.
- Human vs Computer gameplay with random legal moves.
- Player abstraction using the `IPlayer` interface.
- Polymorphism through `HumanPlayer` and `ComputerPlayer`.
- Input validation for invalid coordinates and occupied cells.
- Automatic turn switching.
- Win and draw detection.
- Regression testing using the Week 1 test cases.

## Test Evidence

- [Week 1 Test Results](docs/week1-test-result.png)
- [Week 2 UML Class Diagram](docs/UML.md)
- [AI Usage Log](docs/AI_Usage_Log.md)

Additional Week 2 gameplay screenshots are stored in the `docs/` folder.

## Next Weeks

**Week 3:** Implement undo using a move-history stack, improve testing, and refine the code structure.

**Week 4:** Complete the final report, code cleanup, test evidence, and oral defense preparation.
