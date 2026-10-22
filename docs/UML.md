# Week 1 class diagram (simplified)

```text
+--------------------------+
| Move                     |
+--------------------------+
| Row: int                 |
| Col: int                 |
| Symbol: char             |
+--------------------------+
| Move(row,col,symbol)     |
+--------------------------+

+--------------------------+
| Board                    |
+--------------------------+
| - cells: char[3,3]       |
+--------------------------+
| + GetCell(row,col): char |
| + PlaceMove(move): bool  |
| + PrintBoard(): void     |
+--------------------------+

+--------------------------------+
| GameRules                      |
+--------------------------------+
| + IsWinner(board,symbol): bool |
| + IsDraw(board): bool          |
+--------------------------------+

Board.PlaceMove receives Move.
GameRules methods read Board.
Program creates Board and GameRules to demonstrate behavior.
```

Classes marked + are public methods, `-` is private data. The full-game design will add `IPlayer`, `HumanPlayer`, `ComputerPlayer`, `Game` and undo later.
