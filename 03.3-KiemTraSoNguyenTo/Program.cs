namespace SoNguyenTo
{
    public class SoNguyenTo
    {
        static void Main(string[] args)
        {
            int a = 8;
            Console.WriteLine("Number: ");
            a = Convert.ToInt32(Console.ReadLine());
            bool isPrime = true;
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    isPrime = false;
                }
            }
            Console.Write(isPrime);
        }
    }
}
