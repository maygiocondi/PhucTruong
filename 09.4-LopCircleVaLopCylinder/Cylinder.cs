public class Cylinder : Circle
{
    double heigh;

    public Cylinder()
    {

    }

    public Cylinder(double heigh)
    {
        this.heigh = heigh;
    }

    public Cylinder(double heigh, double radius, string color) : base(radius, color)
    {
        this.heigh = heigh;
    }

    public double GetHeigh()
    {
        return this.heigh;
    }

    public void SetHeigh(double heigh)
    {
        this.heigh = heigh;
    }

    public double GetVolume()
    {
        return 3.14 * Math.Pow(this.GetRadius(), 2) * this.GetHeigh();
    }

    public override string ToString()
    {
        return "A Cylinder with color of "
                 + GetColor()
                 + " and "
                 + "heigh " + GetHeigh()
                 + " and "
                 + "radius " + GetRadius()
                 + " and "
                 + "area " + GetArea()
                 + " and "
                 + "volume " + GetVolume();
    }
}