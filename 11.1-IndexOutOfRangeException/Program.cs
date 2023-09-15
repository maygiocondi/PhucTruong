using System.Collections.Generic;

public class Debug
{
    static void Main(string[] args)
    {
        try
        {
            List<Char> characters = new List<char>();
            characters.InsertRange(0, new Char[] { 'a', 'b', 'c', 'd', 'e', 'f' });
            int value = characters[6];
        }
        catch (IndexOutOfRangeException ex)
        {
            System.Console.WriteLine(ex);
        }
    }
}
