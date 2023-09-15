public class Program
{
    static void Main(string[] agrs)
    {
        Console.WriteLine("Before Resize: ");

        Circle circle = new Circle(50);
        circle.HowToColor();

        Console.WriteLine(circle);

        Rectangle rectangle = new Rectangle(50, 100);

        Console.WriteLine(rectangle);
        rectangle.HowToColor();

        Square square = new Square(50);

        Console.WriteLine(square);
        square.HowToColor();
    }
}
