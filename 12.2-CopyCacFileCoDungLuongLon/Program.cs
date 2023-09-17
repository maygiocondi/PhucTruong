
// C:\Users\Truong Phuc\Desktop\New folder (3)
public class Program
{
    static void Main(string[] args)
    {
        // C:/Users/Truong Phuc/Desktop/New folder (3)/source/Test.txt
        string sourcePath = "C:/Users/Truong Phuc/Desktop/New folder (3)/source/Test.txt";
        string destinationPath = "C:/Users/Truong Phuc/Desktop/New folder (3)/target/Test.txt";

        FileInfo source = new FileInfo(sourcePath);
        FileInfo des = new FileInfo(destinationPath);
        try
        {
            CopyFileUsingStream(source, des);
            Console.WriteLine("Copy Completed");
        }
        catch (IOException e)
        {
            Console.WriteLine("Cannot Copy");
            Console.Error.WriteLine(e.Message);
        }
    }

    static void CopyFileUsingFileInfo(FileInfo source, FileInfo des)
    {
        Console.WriteLine("Start Copy using FileInfo");
        source.CopyTo(des.FullName, true);
    }

    static void CopyFileUsingStream(FileInfo source, FileInfo des)
    {
        Console.WriteLine("Start Copy using Stream");
        StreamReader reader = null;
        StreamWriter writer = null;
        try
        {
            reader = new StreamReader(source.FullName);
            writer = new StreamWriter(des.FullName);
            Char[] buffer = new Char[1024];
            int length;
            while ((length = reader.Read(buffer)) > 0)
            {
                writer.Write(buffer, 0, length);
            }
        }
        finally
        {
            reader.Close();
            reader.Dispose();
            writer.Close();
            writer.Dispose();
        }
    }
}