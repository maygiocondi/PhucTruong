public class Rectangle
{
    double WIDTH;
    double HEIGHT;

    public Rectangle()
    {
    }

    public Rectangle(double width, double height)
    {
        this.WIDTH = width;
        this.HEIGHT = height;
    }

    public double GetArea()
    {
        return this.WIDTH * this.HEIGHT;
    }

    public double GetPerimeter()
    {
        return (this.WIDTH + this.HEIGHT) * 2;
    }

    public string Display()
    {
        return "Rectangle{" + "width=" + WIDTH + ", height=" + HEIGHT + "}";
    }
}