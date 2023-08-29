namespace MangHaiChieu
{
    class GiaTriLonNhat
    {
        static void Main(string[] agrs)
        {
            int [,] arr = new int[2, 2];

            System.Console.WriteLine("Enter Array : ");
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    System.Console.WriteLine($"Enter a[{i}, {j}]");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            System.Console.WriteLine("YOUR ARRAY : ");
              for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    System.Console.Write(arr[i, j] + "\t");
                }
                System.Console.WriteLine();
            }

            System.Console.Write("MAX VALUE IN ARRAY : ");
            int maxValue = int.MinValue;
              for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    if(arr[i, j] >= maxValue)
                    {
                        maxValue = arr[i, j];
                    }
                }
            }
            System.Console.WriteLine(maxValue);
        } 
    }
}