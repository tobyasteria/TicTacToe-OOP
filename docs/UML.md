# Tic-Tac-Toe UML — Command Pattern and Undo

This UML describes the classes and methods currently implemented in the project. The Command Pattern is used to execute a move and reverse it when the player chooses Undo.

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

    Game --> IPlayer : player1, player2, currentPlayer
    Game *-- Board : owns
    Game *-- GameRules : owns
    Game "1" --> "0..*" IGameCommand : moveHistory (Stack)
    Game ..> PlaceMoveCommand : creates for each move
    PlaceMoveCommand --> Board : PlaceMove / RemoveMove
    PlaceMoveCommand --> Move : stores move
    Board ..> Move : places move
    HumanPlayer ..> Board : reads cells
    HumanPlayer ..> Move : returns a move
    ComputerPlayer ..> Board : finds empty cells
    ComputerPlayer ..> Move : returns a move
    GameRules ..> Board : checks cells
```

## 2. Command Pattern Roles

| Role | Implemented class | Responsibility |
|---|---|---|
| Invoker | `Game` | Creates a `PlaceMoveCommand`, calls `Execute()`, and stores successful commands in `moveHistory`. |
| Command interface | `IGameCommand` | Defines `Execute()` and `Undo()`. |
| Concrete command | `PlaceMoveCommand` | Stores the target `Board` and `Move`. `Execute()` places the move; `Undo()` removes it if the command was executed. |
| Receiver | `Board` | Owns the cells and provides `PlaceMove()` and `RemoveMove()`. |
| Command history | `Stack<IGameCommand>` in `Game` | Stores successful moves. `Pop()` makes Undo follow LIFO order. |

## 3. Sequence Diagram — Execute a Move

```mermaid
sequenceDiagram
    participant Game
    participant Player as currentPlayer (IPlayer)
    participant Command as PlaceMoveCommand
    participant Board
    participant History as moveHistory
    participant Rules as GameRules

    Game->>Player: GetMove(board)
    Player-->>Game: Move
    Game->>Command: Create(board, move)
    alt move.Symbol matches currentPlayer.Symbol
        Game->>Command: Execute()
        Command->>Board: PlaceMove(move)
        Board-->>Command: true or false
        Command-->>Game: execution result
        alt command executed successfully
            Game->>History: Push(command)
            Game->>Rules: IsWinner(board, symbol)
            Rules-->>Game: winner or no winner
            opt no winner
                Game->>Rules: IsDraw(board)
                Rules-->>Game: draw or not draw
            end
            opt no winner and not draw
                Game->>Game: SwitchPlayer()
            end
        else invalid or occupied cell
            Game-->>Game: Show invalid move message
        end
    else symbol does not match current player
        Game-->>Game: Show invalid move message
    end
```

## 4. Sequence Diagram — Undo

```mermaid
sequenceDiagram
    participant Game
    participant History as moveHistory (Stack)
    participant Command as PlaceMoveCommand
    participant Board

    Game->>Game: UndoLastTurn()
    alt history is empty
        Game-->>Game: Print "No moves to undo."
    else history contains moves
        Note over Game: Human vs Human: undo 1 move
        Note over Game: Human vs Computer: undo up to 2 moves
        loop for each move to undo
            Game->>History: Pop()
            History-->>Game: most recent command
            Game->>Command: Undo()
            Command->>Board: RemoveMove(move.Row, move.Col)
            Board-->>Command: true or false
            opt move removed successfully
                Command->>Command: executed = false
            end
            Game->>Game: SwitchPlayer()
        end
        Game-->>Game: Print "Undo successful!"
    end
```

## 5. Undo Behavior in the Current Code

- Only successful move commands are pushed onto `moveHistory`.
- `UndoLastTurn()` pops the newest command first, so commands are undone in Last-In, First-Out (LIFO) order.
- In Human vs Human mode, Undo reverses one move.
- In Human vs Computer mode, Undo reverses up to two moves, depending on how many commands are in history.
- `PlaceMoveCommand.Undo()` calls `Board.RemoveMove()` only when its command has been executed.
- An empty history prints `No moves to undo.` and returns without changing the board.

## 6. Other OOP Relationships

- **Encapsulation:** `Board` keeps its `cells` array private and changes board state through its methods.
- **Polymorphism:** `Game` works with `IPlayer` references, which can refer to either `HumanPlayer` or `ComputerPlayer`.
- **Command Pattern:** `Game` can store and undo commands through `IGameCommand` without needing the history to depend on command implementation details.
- **Separation of responsibilities:** `Board` manages cells, `GameRules` checks wins and draws, player classes provide moves, and `Game` manages turns and Undo.