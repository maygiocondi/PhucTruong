public class Program
{
    static void Main(string[] agrs)
    {
        Circle circle = new Circle();

        Console.WriteLine(circle);

        circle = new Circle(2, "blue");

        Console.WriteLine(circle);

        Cylinder cylinder = new Cylinder();

        Console.WriteLine(cylinder);

        cylinder = new Cylinder(2);

        Console.WriteLine(cylinder);

        cylinder = new Cylinder(2, 5, "green");

        Console.WriteLine(cylinder);
    }
}
