# Tic-Tac-Toe OOP — Week 1 (C#)

Small, beginner-friendly C# console project. Week 1 demonstrates the board model, move model, game rules and basic test scenarios; it is **not** a complete playable game yet.

## Files
- `Move.cs`: row, column, symbol of one move.
- `Board.cs`: board data; places moves; refuses occupied/out-of-range/invalid-symbol moves; prints board.
- `GameRules.cs`: detects winning rows, columns, diagonals and draws.
- `Program.cs`: scripted tests of the Week 1 classes.

## Run
Install .NET 8 SDK, open a terminal in this folder, then:

```bash
dotnet run
```

Expected output includes `PASS` for 7 checks. Capture a screenshot after running on your own computer. No actual .NET runtime execution has been performed in the creation environment.

## Next weeks
Week 2: `IPlayer`, `HumanPlayer`, `ComputerPlayer`, `Game` and playable console game.
Week 3: undo using a move-history stack, more tests, improvements.
Week 4: final report, evidence, demo and oral defense.

See `docs/Weekly_Report_01.md`, `docs/UML.md`, and `docs/AI_Usage_Log.md`.
