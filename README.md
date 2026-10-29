
# Tic-Tac-Toe OOP — Week 3 (C#)

A console-based Tic-Tac-Toe game developed in C# (.NET 8) using Object-Oriented Programming principles and the Command Design Pattern.

## Features

- Human vs Human gameplay.
- Human vs Computer gameplay with random legal moves.
- Input validation for coordinates and occupied cells.
- Automatic turn switching.
- Win and draw detection.
- Undo functionality using Command Pattern.
- Move history managed using a Stack (LIFO).
- Automated tests for core logic, players, and Undo.

## Project Structure

- `Move.cs`: Stores move coordinates and player symbol.
- `Board.cs`: Manages the board and supports placing/removing moves.
- `GameRules.cs`: Checks winning and drawing conditions.
- `IPlayer.cs`: Interface for different player types.
- `HumanPlayer.cs`: Handles human player input.
- `ComputerPlayer.cs`: Selects random legal moves.
- `IGameCommand.cs`: Interface defining Execute() and Undo().
- `PlaceMoveCommand.cs`: Encapsulates move execution and reversal.
- `Game.cs`: Controls the game loop, turns, and move history.
- `Program.cs`: Console menu and test launcher.
- `Week1Tests.cs`: Seven original core tests.
- `PlayerTests.cs`: Three player-related tests.
- `UndoTests.cs`: Five Undo tests.

## How to Run

Requirements:
- .NET 8 SDK

Open a terminal in the project folder and run:

```bash
dotnet run
```

## Menu Options

1. Human vs Human
2. Human vs Computer
3. Run Week 1 Tests
4. Run Week 3 Undo Tests
5. Run Week 2 Player Tests

## How to Use Undo

During a game, when the Undo prompt appears:

- Enter `U` to undo.
- Press Enter to continue playing.

**Human vs Human:** Undo removes the most recent move and restores the previous player's turn.

**Human vs Computer:** Undo removes the latest human and computer moves, allowing the human player to play again.

Undo is available during an active game, before a win or draw ends the game.

## Design Patterns

### Command Pattern

The Command Pattern is implemented using:

- `IGameCommand`: Declares `Execute()` and `Undo()`.
- `PlaceMoveCommand`: Implements move execution and reversal.
- `Game`: Stores successful commands in `Stack<IGameCommand>`.

The most recently executed command is undone first (LIFO).

### Polymorphism

`HumanPlayer` and `ComputerPlayer` implement `IPlayer`, allowing `Game` to interact with both player types through the same interface.

## Testing

| Test Suite | Number of Tests |
|---|---|
| Week 1 Tests | 7 |
| Week 2 Player Tests | 3 |
| Week 3 Undo Tests | 5 |
| Total | 15 |

Test results must be confirmed by running the corresponding menu options.

## Evidence

Gameplay screenshots and testing evidence are stored in the `docs/` folder.

- [UML Class Diagram](docs/UML.md)
- [AI Usage Log](docs/AI_Usage_Log.md)
- [Undo Tests](docs/week3-undo-tests.png)
- [Human vs Human Undo](docs/week3-human-vs-human-undo.png)
- [Human vs Computer Undo](docs/week3-human-vs-computer-undo.png)
- [Multiple Undo](docs/week3-multiple-undo.png)
- [Player Tests](docs/week3-player-tests.png)

## Week 4 Plan

- Improve test coverage and edge-case handling.
- Refactor code where necessary.
- Complete final documentation and UML.
- Prepare the final demonstration and oral defense.
```
