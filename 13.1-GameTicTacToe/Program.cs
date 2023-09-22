public class Game
{
    static int pointX = 0;
    static int pointY = 0;

    static int playerPosX;
    static int playerPosY;
    static bool isGameover = true;

    static void Main(string[] args)
    {
        Board board = new Board();
        
        Render(board);
        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (pointY > 0) pointY--;
                    Render(board);
                    break;
                case ConsoleKey.DownArrow:
                    if (pointY < 2) pointY++;
                    Render(board);
                    break;

                case ConsoleKey.LeftArrow:
                    if (pointX > 0) pointX--;
                    Render(board);
                    break;

                case ConsoleKey.RightArrow:
                    if (pointX < 2) pointX++;
                    Render(board);
                    break;

                case ConsoleKey.E:
                    Play(board);
                    Render(board);
                    break;
                default:
                    break;
            }
        } while (isGameover);

    }

    static void Render(Board board)
    {
        board.GenerateBoard();

        Console.BackgroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(pointX, pointY);
        Console.Write(" ");

        Console.SetCursorPosition(0, 9);
        Console.ResetColor();

    }

    static void Play(Board board)
    {
        board.boardCells[pointY, pointX].CellOccupation = 'X';
    }

    // static void CheckPosFood()
    // {
    //     if (x == foodPosX && y == foodPosY)
    //     {
    //         do
    //         {
    //             foodPosX = rand.Next(1, WIDTH - 1);
    //             foodPosY = rand.Next(1, HEIGH - 1);
    //             Render(rand);
    //         } while (foodPosX == x && foodPosY == y);
    //     }
    //     else
    //     {
    //         Render();
    //     }
    // }
}