public class Point2D
{
    float x;
    float y;

    public Point2D()
    {
        x = 0.0f;
        y = 0.0f;
    }

    public Point2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float GetX()
    {
        return this.x;
    }

    public void SetX(float x)
    {
        this.x = x;
    }

    public float GetY()
    {
        return this.y;
    }

    public void SetY(float y)
    {
        this.y = y;
    }

    public float[] GetXY()
    {
        return new float[2] { this.x, this.y};
    }

    public void SetXY(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return $"{x}, {y}";
    }
}