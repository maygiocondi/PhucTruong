using System.Diagnostics;
class Program
{
    static void Main(string[] agrs)
    {
        int[] array = new int[100000];
        Random rand = new Random();
        for (int i = 0; i<array.Length; i++)
        {
            array[i] = rand.Next(0, 1000);
        }

        Stopwatch count = new Stopwatch();

        count.Start();
        SelectionSort(array);
        count.Stop();

        Console.WriteLine(count.GetElapsedTime());
    }

    static public int[] SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int minIndex = i;
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
        return array;
    }
}
