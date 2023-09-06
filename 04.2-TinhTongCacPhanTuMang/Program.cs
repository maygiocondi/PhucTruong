namespace TongPhanTu
{
    class TongPhanTu
    {
        static void Main(string[] args)
        {
            int [] arr = {2, 3, 5, 8};
            int total = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                total += arr[i];
            }

            Console.WriteLine($"Tong la : {total}");
        }
    }
}
