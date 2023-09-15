public class Circle
{
    double radius;
    string color;

    public Circle()
    {

    }

    public Circle(double radius, string color)
    {
        this.radius = radius;
        this.color = color;
    }

    public double GetRadius()
    {
        return this.radius;
    }

    public void SetRadius(double radius)
    {
        this.radius = radius;
    }

    public string GetColor()
    {
        return this.color;
    }

    public void SetColor(string color)
    {
        this.color = color;
    }

    public double GetArea()
    {
        return this.radius * 2 * 3.14;
    }

    public override string ToString()
    {
        return "A Circle with color of "
                + GetColor()
                + " and "
                + "radius " + GetRadius()
                + " and "
                + "area " + GetArea();
    }
}