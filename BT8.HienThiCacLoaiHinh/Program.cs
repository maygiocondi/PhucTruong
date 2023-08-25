using System.Text;
namespace HienThiCacLoaiHinh
{
    class CacLoaiHinh
    {
        public static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.OutputEncoding = Encoding.UTF8;

                Console.WriteLine("Menu");
                Console.WriteLine("1. In hình chữ nhật");
                Console.WriteLine("2. In hình tam giác vuông");
                Console.WriteLine("3. In hình tam giác cân");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("Vui lòng nhập lựa chọn: ");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("In Hình Chữ nhật");
                        Rectangle();
                        break;
                    case 2:
                        Console.WriteLine("Tam giác vuông có cạnh góc vuông ở Bottom-Left");
                        SquareTriangleBottomLeft();
                        Console.WriteLine("Tam giác vuông có cạnh góc vuông ở Top-Left");
                        SquareTriangleTopLeft();
                        Console.WriteLine("Tam giác vuông có cạnh góc vuông ở Bottom-Right");
                        SquareTriangleBottomRight();
                        Console.WriteLine("Tam giác vuông có cạnh góc vuông ở Top-Right");
                        SquareTriangleTopRight();
                        break;
                    case 3:
                        Console.WriteLine("In Tam Giác Cân");
                        IsoscelesTriangle();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("No choice!");
                        break;
                }
            }
            while (choice != 0);
        }

        static void Rectangle()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

        static void SquareTriangleBottomLeft()
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j = 1; j <= i + 1; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

         static void SquareTriangleTopLeft()
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j = 5; j > i; j--)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

        static void SquareTriangleBottomRight()
        {
            for(int i = 0; i < 5; i++)
            {
                for(int k = 4; k > i; k--)
                {
                    Console.Write(' ');
                }
                for(int j = 0; j <= i; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

         static void SquareTriangleTopRight()
        {
            for(int i = 0; i < 5; i++)
            {
                for(int k = 1; k <= i; k++)
                {
                    Console.Write(' ');
                }
                for(int j = 5; j > i; j--)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

        static void IsoscelesTriangle()
        {
            int j;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 4; k >= i; k--)
                    Console.Write(" ");
                for (j = 0; j < 2 * i + 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }              
        }
    }
}
