using System.Drawing;

public class Board
{
    public const int WIDTH = 3;
    public const int HEIGH = 3;

    public BoardCell[,] boardCells = new BoardCell[WIDTH, HEIGH];

    public Board()
    {
        for (int x = 0; x < boardCells.GetLength(0); x++)
        {
            for (int y = 0; y < boardCells.GetLength(1); y++)
            {
                boardCells[x, y] = new BoardCell();
            }
        }
    }

    public void GenerateBoard()
    {
        Console.Clear();
        for (int x = 0; x < boardCells.GetLength(0); x++)
        {
            for (int y = 0; y < boardCells.GetLength(1); y++)
            {
                Console.Write(boardCells[x, y].CellOccupation);
            }
            Console.WriteLine();
        }
    }
}

public class BoardCell
{
    public int X;
    public int Y;
    private char cellOccupation;

    public BoardCell()
    {
        cellOccupation = ' ';
    }

    public BoardCell(int x, int y, char c)
    {
        this.X = x;
        this.Y = y;
        this.CellOccupation = c;
    }

    public char CellOccupation { get => cellOccupation; set => cellOccupation = value; }
}