public class Point3D : Point2D
{
    float z;

    public Point3D()
    {
        z = 0.0f;
    }

    public Point3D(float x, float y) : base(x, y)
    {
        
    }

    public float GetZ()
    {
        return this.z;
    }

    public void SetZ(float z)
    {
        this.z = z;
    }

    public void SetXYZ(float x, float y, float z)
    {
        this.SetX(x);
        this.SetY(y);
        this.z = z;
    }

    public float[] GetXYZ()
    {
        return new float[3] {this.GetX(), this.GetY(), this.z};
    }

    public override string ToString()
    {
        return $"{this.GetX()}, {this.GetY()}, {z}";
    }
}