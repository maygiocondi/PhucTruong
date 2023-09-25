public class Manage
{
    const string dbName = "db.txt";

    static bool isRunning = true;
    static void Main(string[] args)
    {
        while (isRunning)
        {
            try
            {
                Console.WriteLine("A.Add product");
                Console.WriteLine("A.Add product");
                Console.WriteLine("A.Add product");
                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("Product code?");
                        var code = Console.ReadLine();
                        Console.WriteLine("Product name?");
                        var name = Console.ReadLine();
                        Console.WriteLine("Product agency?");
                        var agency = Console.ReadLine();
                        Console.WriteLine("Product price?");
                        var price = Console.ReadLine();
                        Console.WriteLine("Product decription");
                        var decs = Console.ReadLine();
                        Product pd = new Product(code, name, agency, price, decs);
                        var str = pd.ToString();
                        var str_bytes = System.Text.Encoding.ASCII.GetBytes(str);
                        var stream = File.AppendText(dbName);
                        foreach (byte b in str_bytes)
                        {
                            var data = Convert.ToString(b, 2).PadLeft(8, '0');

                            stream.Write(data + " ");
                        }
                        stream.WriteLine();
                        stream.Close();
                        break;
                    case ConsoleKey.B:
                        StreamReader rStream = File.OpenText(dbName);
                        string line;
                        while ((line = rStream.ReadLine()) != null)
                        {
                            string resule = "";
                            string[] binaryArray = line.Split(' ');

                            foreach (string bi in binaryArray)
                            {
                                if (bi == "" || bi == " ") continue;

                                int num = Convert.ToInt32(bi, 2);
                                char character = Convert.ToChar(num);
                                resule += character;
                            }
                            Console.WriteLine(resule);
                        }
                        rStream.Close();
                        break;
                    default:
                        isRunning = false;
                        return;
                }
            }
            catch
            {

            }
        }
    }
}