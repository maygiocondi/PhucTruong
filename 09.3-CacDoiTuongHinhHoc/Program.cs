public class Program
{
    static void Main(string[] agrs)
    {
       Square square = new Square();

                Console.WriteLine(square);

                square = new Square(2.3);

                Console.WriteLine(square);

                square = new Square(5.8, “yellow”, true);

                Console.WriteLine(square);
    }
}
