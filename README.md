
# Tic-Tac-Toe OOP — Final Project (C#)

A console-based Tic-Tac-Toe game developed with C# (.NET 8), applying Object-Oriented Programming (OOP) principles and the Command Design Pattern.

## 1. Features

- Human vs Human gameplay.
- Human vs Computer gameplay with random legal moves.
- Input validation for coordinates and occupied cells.
- Win and draw detection.
- Automatic turn switching.
- Undo using the Command Pattern.
- Move history managed using `Stack<IGameCommand>` (LIFO).
- Automated testing with 18 test cases.

## 2. Project Structure

| File | Description |
|---|---|
| `Move.cs` | Stores move coordinates and player symbol. |
| `Board.cs` | Manages board state, placing and removing moves. |
| `GameRules.cs` | Checks winning and drawing conditions. |
| `IPlayer.cs` | Defines the player interface. |
| `HumanPlayer.cs` | Handles human input. |
| `ComputerPlayer.cs` | Generates random valid moves. |
| `IGameCommand.cs` | Defines `Execute()` and `Undo()`. |
| `PlaceMoveCommand.cs` | Executes and reverses moves. |
| `Game.cs` | Controls gameplay, turns and Undo history. |
| `Program.cs` | Main menu and test execution. |
| `Week1Tests.cs` | Seven core tests. |
| `PlayerTests.cs` | Three player-related tests. |
| `UndoTests.cs` | Eight Undo-related tests. |

## 3. How to Run

**Requirements:** .NET 8 SDK.

Open a terminal in the project directory:

```bash
dotnet build
dotnet run
```

### Main Menu

1. Human vs Human
2. Human vs Computer
3. Run Week 1 Tests
4. Run Week 3 Undo Tests
5. Run Week 2 Player Tests
6. Run All Tests

Players enter row and column numbers from 1 to 3.

## 4. Undo Functionality

During an active game, when the Undo prompt appears:

- Enter `U` to undo the previous move(s).
- Press Enter to continue playing.

**Human vs Human:** Reverses the most recent move and restores the previous player's turn.

**Human vs Computer:** Reverses up to two recent moves (human and computer), allowing the human player to play again.

Undo is available before the game ends.

### Command Pattern

| Role | Class |
|---|---|
| Command Interface | `IGameCommand` |
| Concrete Command | `PlaceMoveCommand` |
| Invoker | `Game` |
| Receiver | `Board` |
| Command History | `Stack<IGameCommand>` |

Only successfully executed moves are stored in history.

## 5. Testing

The project contains 18 automated tests.

| Test Suite | Tests | Result |
|---|---:|---|
| Week 1 Core Tests | 7 | 7/7 PASS |
| Week 2 Player Tests | 3 | 3/3 PASS |
| Undo Tests | 8 | 8/8 PASS |
| **Total** | **18** | **18/18 PASS** |

### Week 4 Additional Tests

Three new tests were added without removing the previous five Undo tests:

- `TestUndoRestoresTurn`: Verifies turn restoration after Undo.
- `TestUndoHumanVsComputer`: Verifies two-move Undo in Human vs Computer.
- `TestInvalidMoveNotSaved`: Verifies invalid moves are not stored in history.

To run all tests, execute `dotnet run` and select option `6`.

The 18/18 PASS result was verified through local execution after integrating Pull Request #1.

## 6. Test Evidence

- [Week 4 — All 18 Tests](docs/week4-regression-tests.png)
- [Week 4 — Eight Undo Tests](docs/week4-undotest.png)
- [Week 4 — All Tests Menu](docs/week4-all-tests.png)
- [Human vs Human Undo](docs/week3-human-vs-human-undo.png)
- [Human vs Computer Undo](docs/week3-human-vs-computer-undo.png)
- [Multiple Undo](docs/week3-multiple-undo.png)

## 7. UML and Documentation

- [UML Diagrams](docs/UML.md)
- [AI Usage Log](docs/AI_Usage_Log.md)

The UML documents the class relationships, Command Pattern roles, and Execute/Undo sequences.

## 8. Team Contributions

**Lương Anh Hào — 25110017 (`tobyasteria`)**

- Implemented Command Pattern and integrated Undo into `Game.cs`.
- Integrated the automated tests into `Program.cs`.
- Added the Run All Tests menu option.
- Reviewed and merged the Week 4 testing Pull Request.
- Verified 18/18 PASS and uploaded regression test evidence.
- Maintained README and project documentation.

**Nguyễn Quốc Hào — 25110018 (`haonguyen457`)**

- Implemented `Board.RemoveMove()`.
- Developed the original five Undo tests.
- Added three Week 4 Undo tests.
- Updated and checked the UML diagrams.
- Submitted the new tests through a feature branch and Pull Request.

**Week 4 Pull Request:** [PR #1 — Add Week 4 Undo Tests](https://github.com/tobyasteria/TicTacToe-OOP/pull/1)

## 9. Known Limitations

- Undo is available only while a game is active.
- Undo uses a separate prompt rather than being entered during coordinate input.
- Some Undo tests use Reflection to access private members of `Game`, creating a dependency on its internal structure.

## 10. Final Status

- Human vs Human: Implemented.
- Human vs Computer: Implemented.
- Command Pattern Undo: Implemented.
- Automated tests: 18/18 PASS.
- UML and test evidence: Available on GitHub.
- Final demonstration and oral defense: To be completed.
