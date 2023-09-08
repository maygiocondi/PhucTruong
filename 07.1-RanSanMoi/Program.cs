using System;
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

        static void Main(string[] arg)
        {
            Random rand = new Random();
            int snakePosX = 2;
            int snakePosY = 5;

            foodPosX = rand.Next(1, WIDTH - 1);
            foodPosY = rand.Next(1, HEIGH - 1);
            Render(WIDTH, HEIGH, snakePosX, snakePosY, foodPosX, foodPosY, rand);

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    snakePosY--;
                    CheckPosFood(snakePosX, snakePosY, foodPosX, foodPosY, rand);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    snakePosY++;
                    CheckPosFood(snakePosX, snakePosY, foodPosX, foodPosY, rand);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    snakePosX--;
                    if (snakePosX == foodPosX && snakePosY == foodPosY)
                    {
                        do
                        {
                            foodPosX = rand.Next(1, WIDTH - 1);
                            foodPosY = rand.Next(1, HEIGH - 1);
                            Render(WIDTH, HEIGH, snakePosX, snakePosY, foodPosX, foodPosY, rand);
                        } while (foodPosX != snakePosX && foodPosY != snakePosY);
                    }
                    Render(WIDTH, HEIGH, snakePosX, snakePosY, foodPosX, foodPosY, rand);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    snakePosX++;
                    if (snakePosX == foodPosX && snakePosY == foodPosY)
                    {
                        do
                        {
                            foodPosX = rand.Next(1, WIDTH - 1);
                            foodPosY = rand.Next(1, HEIGH - 1);
                            Render(WIDTH, HEIGH, snakePosX, snakePosY, foodPosX, foodPosY, rand);
                        } while (foodPosX != snakePosX && foodPosY != snakePosY);
                    }
                    Render(WIDTH, HEIGH, snakePosX, snakePosY, foodPosX, foodPosY, rand);
                }
                SetGameover(snakePosX, snakePosY, WIDTH - 1, HEIGH);
            } while (isGameover);

            Render(WIDTH, HEIGH, snakePosX, snakePosY, foodPosX, foodPosY, rand);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(1, 1);
            Console.Write("****Game Over****");
            Console.SetCursorPosition(0, 9);
        }

        static bool SetGameover(int x, int y, int width, int heigh)
        {
            if (y <= 0 || y >= heigh || x <= 0 || x >= width)
            {
                isGameover = false;
            }
            return isGameover;
        }

        static void Render(int width, int heigh, int snakePosX, int snakePosY, int foodPosX, int foodPosY, Random rand)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("#");
            }

            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, heigh);
                Console.WriteLine("#");
            }

            for (int i = 1; i < heigh + 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("#");
            }

            for (int i = 1; i < heigh + 1; i++)
            {
                Console.SetCursorPosition(width - 1, i);
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

        static void CheckPosFood(int snakePosX, int snakePosY, int foodPosX, int foodPosY, Random rand)
        {
            if (snakePosX == foodPosX && snakePosY == foodPosY)
            {
                do
                {
                    foodPosX = rand.Next(1, WIDTH - 1);
                    foodPosY = rand.Next(1, HEIGH - 1);
                    Render(WIDTH, HEIGH, snakePosX, snakePosY, foodPosX, foodPosY, rand);
                } while (foodPosX == snakePosX && foodPosY == snakePosY);
            }
            Render(WIDTH, HEIGH, snakePosX, snakePosY, foodPosX, foodPosY, rand);
        }
    }

}
