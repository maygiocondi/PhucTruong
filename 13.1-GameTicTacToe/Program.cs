using System;

public class Game
{
    static int playerX = 0;
    static int playerY = 0;

    static int computerX = 0;
    static int computerY = 0;

    static int playerPoint = 0;
    static int computerPoint = 0;

    static bool isGameover = true;

    static void Main(string[] args)
    {
        Board board = new Board();
        Random rand = new Random();

        Render(board);
        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (playerY > 0) playerY--;
                    Render(board);
                    break;
                case ConsoleKey.DownArrow:
                    if (playerY < 2) playerY++;
                    Render(board);
                    break;

                case ConsoleKey.LeftArrow:
                    if (playerX > 0) playerX--;
                    Render(board);
                    break;

                case ConsoleKey.RightArrow:
                    if (playerX < 2) playerX++;
                    Render(board);
                    break;

                case ConsoleKey.E:
                    Play(board);
                    ComputerPlay(rand, board);
                    Render(board);
                    break;
                default:
                    break;
            }
        } while (isGameover);


        string dbName = "point.txt";

        var str = $"{playerPoint} - {computerPoint} \n";
        var stream = File.AppendText(dbName);
        stream.Write(str);
        stream.WriteLine();
        stream.Close();
    }

    static void Render(Board board)
    {
        board.GenerateBoard();

        Console.BackgroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(" ");

        Console.SetCursorPosition(0, 9);
        Console.ResetColor();

    }

    static void Play(Board board)
    {
        board.boardCells[playerY, playerX].CellOccupation = 'X';
        EndGame(board);
    }

    static void ComputerPlay(Random rand, Board board)
    {
        rand = new Random();

        while (true)
        {
            computerX = rand.Next(0, board.boardCells.GetLength(0));
            computerY = rand.Next(0, board.boardCells.GetLength(1));

            if (board.boardCells[computerY, computerX].CellOccupation == ' ')
            {
                board.boardCells[computerY, computerX].CellOccupation = 'O';
                EndGame(board);
                return;
            }
        }
    }

    static public void EndGame(Board board)
    {
        for (int x = 1; x < board.boardCells.GetLength(0) - 1; x++)
        {
            for (int y = 0; y < board.boardCells.GetLength(1); y++)
            {
                if (board.boardCells[y, x].CellOccupation == 'X' && board.boardCells[y, x - 1].CellOccupation == 'X' && board.boardCells[y, x + 1].CellOccupation == 'X')
                {
                    playerPoint++;
                    isGameover = false;
                }
                if (board.boardCells[y, x].CellOccupation == 'O' && board.boardCells[y, x - 1].CellOccupation == 'O' && board.boardCells[y, x + 1].CellOccupation == 'O')
                {
                    computerPoint++;
                    isGameover = false;
                }
            }
        }
        for (int x = 1; x < board.boardCells.GetLength(1) - 1; x++)
        {
            for (int y = 0; y < board.boardCells.GetLength(0); y++)
            {
                if (board.boardCells[x, y].CellOccupation == 'X' && board.boardCells[x - 1, y].CellOccupation == 'X' && board.boardCells[x + 1, y].CellOccupation == 'X')
                {
                    playerPoint++;
                    isGameover = false;
                }
                if (board.boardCells[x, y].CellOccupation == 'O' && board.boardCells[x - 1, y].CellOccupation == 'O' && board.boardCells[x + 1, y].CellOccupation == 'O')
                {
                    computerPoint++;
                    isGameover = false;
                }
            }
        }
        for (int x = 1; x < board.boardCells.GetLength(0) - 1; x++)
        {
            for (int y = 1; y < board.boardCells.GetLength(1) - 1; y++)
            {
                if (board.boardCells[y, x].CellOccupation == 'X' && board.boardCells[y - 1, x - 1].CellOccupation == 'X' && board.boardCells[y + 1, x + 1].CellOccupation == 'X')
                {
                    playerPoint++;
                    isGameover = false;
                }
                if (board.boardCells[y, x].CellOccupation == 'O' && board.boardCells[y - 1, x - 1].CellOccupation == 'O' && board.boardCells[y + 1, x + 1].CellOccupation == 'O')
                {
                    computerPoint++;
                    isGameover = false;
                }
                if (board.boardCells[y, x].CellOccupation == 'X' && board.boardCells[y - 1, x + 1].CellOccupation == 'X' && board.boardCells[y + 1, x - 1].CellOccupation == 'X')
                {
                    playerPoint++;
                    isGameover = false;
                }
                if (board.boardCells[y, x].CellOccupation == 'O' && board.boardCells[y - 1, x + 1].CellOccupation == 'O' && board.boardCells[y + 1, x - 1].CellOccupation == 'O')
                {
                    computerPoint++;
                    isGameover = false;
                }
            }
        }
    }
}
