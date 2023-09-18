using System.IO;

public class ReadToFileCSV
{
    static void Main(string[] args)
    {
        List<string> lstA = new List<string>();
        StreamReader reader = new StreamReader("test.csv");
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] value = line.Split('"');
            
            foreach (var val in value)
            {
                if (val != ",")
                {
                    Console.Write(val + "    ");
                }
            }
            Console.WriteLine();
        }
        reader.Close();
    }

}