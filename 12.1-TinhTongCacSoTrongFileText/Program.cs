public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please input file path");
        string path = "C:/Users/Truong Phuc/Desktop/New folder (3)/Test.txt";
        Console.WriteLine("File path: " + path);
        ReadTextFileExample example = new ReadTextFileExample();
        example.ReadTextFile(path);
        
    }
}
