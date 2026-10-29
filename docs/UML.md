# Tic-Tac-Toe OOP — UML Class Diagram (Week 3)

This document describes the implemented C# (.NET 8) architecture, including the Command Pattern used for Undo.

## 1. Class Diagram

```mermaid
classDiagram
    class IPlayer {
        <<interface>>
        +char Symbol
        +GetMove(Board board) Move
    }
    class HumanPlayer {
        +char Symbol
        +HumanPlayer(char symbol)
        +GetMove(Board board) Move
        -ReadCoordinate(string name) int
    }
    class ComputerPlayer {
        -Random random
        +char Symbol
        +ComputerPlayer(char symbol)
        +GetMove(Board board) Move
    }
    class Game {
        -Board board
        -GameRules rules
        -IPlayer player1
        -IPlayer player2
        -IPlayer currentPlayer
        -Stack~IGameCommand~ moveHistory
        +Game(IPlayer p1, IPlayer p2)
        +Start() void
        -UndoLastTurn() void
        -SwitchPlayer() void
    }
    class Board {
        -char[,] cells
        +Board()
        +GetCell(int row, int col) char
        +PlaceMove(Move move) bool
        +RemoveMove(int row, int col) bool
        +PrintBoard() void
    }
    class Move {
        +int Row
        +int Col
        +char Symbol
        +Move(int row, int col, char symbol)
    }
    class GameRules {
        +IsWinner(Board board, char symbol) bool
        +IsDraw(Board board) bool
    }
    class IGameCommand {
        <<interface>>
        +Execute() bool
        +Undo() void
    }
    class PlaceMoveCommand {
        -Board board
        -Move move
        -bool executed
        +PlaceMoveCommand(Board board, Move move)
        +Execute() bool
        +Undo() void
    }

    IPlayer <|.. HumanPlayer
    IPlayer <|.. ComputerPlayer
    IGameCommand <|.. PlaceMoveCommand
    Game --> IPlayer : manages players
    Game *-- Board : owns
    Game *-- GameRules : owns
    Game --> IGameCommand : history (Stack)
    Game ..> PlaceMoveCommand : creates
    PlaceMoveCommand --> Board : executes/removes move
    PlaceMoveCommand --> Move : stores
    Board ..> Move : places
    GameRules ..> Board : checks
    HumanPlayer ..> Board : checks occupied cells
    ComputerPlayer ..> Board : finds empty cells
```

## 2. Command Pattern Roles

| Role | Component | Responsibility |
|---|---|---|
| Command | `IGameCommand` | Defines `Execute()` and `Undo()` |
| Concrete Command | `PlaceMoveCommand` | Stores a move and executes/reverses it |
| Receiver | `Board` | Changes cells through `PlaceMove()` and `RemoveMove()` |
| Invoker | `Game` | Creates commands and invokes execution/undo |
| History | `Stack<IGameCommand>` | Tracks successful moves in LIFO order |

## 3. Move Execution Sequence

```mermaid
sequenceDiagram
    participant G as Game
    participant P as IPlayer
    participant C as PlaceMoveCommand
    participant B as Board
    participant H as Stack history
    participant R as GameRules
    G->>P: GetMove(board)
    P-->>G: move
    G->>C: new PlaceMoveCommand(board, move)
    alt move symbol matches current player
        G->>C: Execute()
        C->>B: PlaceMove(move)
        B-->>C: true/false
        C-->>G: success/failure
        alt success
            G->>H: Push(command)
            G->>R: IsWinner(board, symbol)
            opt no winner
                G->>R: IsDraw(board)
            end
            opt no winner and no draw
                G->>G: SwitchPlayer()
            end
        else invalid move
            G->>G: Display error; retry turn
        end
    else wrong symbol
        G->>G: Display error; retry turn
    end
```

## 4. Undo Sequence

```mermaid
sequenceDiagram
    participant G as Game
    participant H as Stack history
    participant C as IGameCommand
    participant B as Board
    G->>G: UndoLastTurn()
    alt no saved moves
        G->>G: Print "No moves to undo."
    else saved moves exist
        Note over G: Human vs Human: undo 1 move
        Note over G: Human vs Computer: undo up to 2 moves
        loop per command to undo
            G->>H: Pop()
            H-->>G: latest command
            G->>C: Undo()
            Note over C,B: PlaceMoveCommand calls Board.RemoveMove()
            C->>B: RemoveMove(row, col)
            B-->>C: true/false
            G->>G: SwitchPlayer()
        end
        G->>G: Print "Undo successful!"
    end
```

## 5. Implemented Behavior and Limitations

- A command is pushed onto the history stack only after its `Execute()` succeeds.
- Undo reverses the most recent successful command first (LIFO).
- Human vs Human undoes one move and restores the turn.
- Human vs Computer undoes up to two moves at a time, restoring the human player's turn in normal play.
- If history is empty, no move is changed and a message is displayed.
- Undo is offered at a separate prompt during an active game, not after a win/draw has ended the game.
- `Board` still handles console rendering; separation of presentation is future work.

## 6. Testing

- `Week1Tests.cs`: 7 core checks.
- `PlayerTests.cs`: 3 player-related checks.
- `UndoTests.cs`: 5 Undo checks; uses reflection to access private Game members for tests.

Test outcomes are reported separately based on actual execution, not inferred from this UML.
