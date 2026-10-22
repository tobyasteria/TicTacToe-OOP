public class Move
{
    public int Row { get; set; }
    public int Col { get; set; }
    public char Symbol { get; set; }

    public Move(int row, int col, char symbol)
    {
        Row = row;
        Col = col;
        Symbol = symbol;
    }
}
