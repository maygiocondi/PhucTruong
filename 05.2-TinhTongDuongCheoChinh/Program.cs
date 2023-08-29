using System.Text;
namespace Matran
{
    class TongDuongCheoChinh
    {
        static void Main(string[] agrs)
        {
            Console.OutputEncoding = Encoding.UTF8;

            System.Console.Write("Bạn hãy nhập kích cỡ của ma trận: ");
            int x = Convert.ToInt32(Console.ReadLine());

            int[,] arr = new int[x, x];

            System.Console.WriteLine("Nhập Ma trận : ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    System.Console.WriteLine($"a[{i}, {j}] = ");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            System.Console.WriteLine("Ma trận của bạn là : ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    System.Console.Write(arr[i, j] + "\t");
                }
                System.Console.WriteLine();
            }

            System.Console.Write("Tổng phần tử của đường chéo chính là : ");
            int temp = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == i)
                    {
                        temp += arr[i, j];
                    }
                }
            }
            System.Console.WriteLine(temp);
        }
    }
};
