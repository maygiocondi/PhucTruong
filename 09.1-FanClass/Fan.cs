public class Fan
{
    public const int SLOW = 1;
    public const int MEDIUM = 2;
    public const int FAST = 3;

    int speed = SLOW;
    bool isOn = false;
    double radius = 10;
    string color = "blue";

    public int GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(int value)
    {
        this.speed = value;
    }

     public bool GetIsOn()
    {
        return isOn;
    }

    public void SetIsOn(bool value)
    {
        this.isOn = value;
    }

     public double GetRadius()
    {
        return radius;
    }

    public void SetRadius(double value)
    {
        this.radius = value;
    }

     public string GetColor()
    {
        return color;
    }

    public void SetColor(string value)
    {
        this.color = value;
    }

    public Fan()
    {

    }

    public string ToString()
    {
        if (isOn)
        {
            return $"Fan is on - Speed: {speed} - Color: {color} - Radius: {radius}";
        }
        return $"Fan is off - Color: {color} - Radius: {radius}";
    }
}