# Week 1 class diagram (simplified)
# UML Class Diagram — Week 2

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
        +Game(IPlayer p1, IPlayer p2)
        +Start() void
        -SwitchPlayer() void
    }

    class Board {
        -char[,] cells
        +GetCell(int row, int col) char
        +PlaceMove(Move move) bool
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

    IPlayer <|.. HumanPlayer
    IPlayer <|.. ComputerPlayer
    Game --> IPlayer
    Game --> Board
    Game --> GameRules
    Board ..> Move
    HumanPlayer ..> Move
    ComputerPlayer ..> Move
    GameRules ..> Board
```

## OOP Principles

- Encapsulation: Board stores cells privately.
- Polymorphism: Game uses IPlayer to work with both HumanPlayer and ComputerPlayer.
- Single Responsibility: Player classes generate moves, Board manages board state, GameRules checks win/draw, and Game manages turns.

## Next Week

Implement undo using a move-history stack and improve separation of console display from Board.
