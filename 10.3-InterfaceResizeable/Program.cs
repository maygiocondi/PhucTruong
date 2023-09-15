public class Program
{
    static void Main(string[] agrs)
    {
        Console.WriteLine("Before Resize: ");

        Circle circle = new Circle(50);

        Console.WriteLine("Circle Radius: " + circle.GetRadius());

        Rectangle rectangle = new Rectangle(50, 100);

        Console.WriteLine("Rectangle width: " + rectangle.GetWidth() + " Length: " + rectangle.GetLength());

        Square square = new Square(50);

        Console.WriteLine("Square Side: " + square.GetSide());

        circle.Resize(10);
        rectangle.Resize(10);
        square.Resize(10);

        Console.WriteLine("After Resize: ");
        Console.WriteLine("Circle Radius: " + circle.GetRadius());
        Console.WriteLine("Rectangle width: " + rectangle.GetWidth() + "Length: " + rectangle.GetLength());
        Console.WriteLine("Square Side: " + square.GetSide());
    }
}
