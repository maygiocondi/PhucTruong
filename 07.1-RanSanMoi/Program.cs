using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SystemTime
{
    class Program
    {
        static bool isGameover = true;
        const int WIDTH = 20;
        const int HEIGH = 8;

        static int foodPosX;
        static int foodPosY;
        static int snakePosX = 2;
        static int snakePosY = 5;

        static void Main(string[] arg)
        {
            Random rand = new Random();


            foodPosX = rand.Next(1, WIDTH - 1);
            foodPosY = rand.Next(1, HEIGH - 1);
            Render(rand);

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        snakePosY--;
                        CheckPosFood(rand);
                        break;
                    case ConsoleKey.DownArrow:
                        snakePosY++;
                        CheckPosFood(rand);
                        break;

                    case ConsoleKey.LeftArrow:
                        snakePosX--;
                        CheckPosFood(rand);
                        break;


                    case ConsoleKey.RightArrow:
                        snakePosX++;
                        CheckPosFood(rand);
                        break;
                    default:
                        break;
                }

                SetGameover();
            } while (isGameover);

            Render(rand);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(1, 1);
            Console.Write("****Game Over****");
            Console.SetCursorPosition(0, 9);
        }

        static bool SetGameover()
        {
            if (snakePosY <= 0 || snakePosY >= HEIGH || snakePosX <= 0 || snakePosX >= WIDTH - 1)
            {
                isGameover = false;
            }
            return isGameover;
        }

        static void Render(Random rand)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < WIDTH; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("#");
            }

            for (int i = 0; i < WIDTH; i++)
            {
                Console.SetCursorPosition(i, HEIGH);
                Console.WriteLine("#");
            }

            for (int i = 1; i < HEIGH + 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("#");
            }

            for (int i = 1; i < HEIGH + 1; i++)
            {
                Console.SetCursorPosition(WIDTH - 1, i);
                Console.Write('#');
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snakePosX, snakePosY);
            Console.Write(" ");

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(foodPosX, foodPosY);
            Console.Write(" ");

            Console.SetCursorPosition(0, 9);
            Console.ResetColor();
        }

        static void CheckPosFood(Random rand)
        {
            if (snakePosX == foodPosX && snakePosY == foodPosY)
            {
                do
                {
                    foodPosX = rand.Next(1, WIDTH - 1);
                    foodPosY = rand.Next(1, HEIGH - 1);
                    Render(rand);
                } while (foodPosX == snakePosX && foodPosY == snakePosY);
            }
            else
            {
                Render(rand);
            }
        }
    }

}
