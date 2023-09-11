class Program
{
    static void Main(string[] args)
    {
        Fan fan1 = new Fan();
        Fan fan2 = new Fan();
        
        fan1.SetRadius(10);
        fan1.SetColor("Yellow");
        fan1.SetIsOn(true);
        fan1.SetSpeed(3);

         
        fan2.SetRadius(5);
        fan2.SetColor("BLue");
        fan2.SetIsOn(false);
        fan2.SetSpeed(2);

        Console.WriteLine(fan1.ToString());
        Console.WriteLine(fan2.ToString());
    }
}
