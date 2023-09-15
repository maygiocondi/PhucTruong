public class Shape : IColorable
{
    string color = "green";

    bool filled = true;
    public Shape()
    {

    }

    public Shape(String color, bool filled)
    {
        this.color = color;

        this.filled = filled;
    }

    public String GetColor()
    {
        return color;
    }

    public void SetColor(String color)
    {
        this.color = color;
    }

    public bool IsFilled()
    {
        return filled;
    }

    public void SetFilled(bool filled)
    {
        this.filled = filled;
    }

    public override String ToString()
    {
        return "A Shape with color of "
                    + GetColor()
                    + " and "
                    + (IsFilled() ? "filled" : "not filled");
    }

    public void HowToColor()
    {
        if (filled)
        {
            Console.WriteLine($"this Shape is filled with {GetColor()}");
        }
        else
        {
            Console.WriteLine("This Shape is not filled with color!");
        }
    }
}
