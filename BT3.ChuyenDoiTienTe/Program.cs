using System;
using System.Text;

namespace SystemTime
{
    class Program
    {
        static void Main(string[] arg)
        {
            Console.OutputEncoding = Encoding.UTF8;

            float vnd;
            float usd;

            System.Console.WriteLine();
            System.Console.WriteLine("****************************************");
            System.Console.WriteLine("* Ứng dụng chuyển đổi tiền tệ Đơn giản *");
            System.Console.WriteLine("****************************************");
            System.Console.WriteLine("Vui lòng nhập vào số tiền cần chuyển đổi (đơn vị vnd): ");
            vnd = float.Parse(Console.ReadLine());

            usd = vnd/23000f;

            System.Console.WriteLine(vnd + " vnd - Tương đương với " + usd + " usd");
        }
    }

}
