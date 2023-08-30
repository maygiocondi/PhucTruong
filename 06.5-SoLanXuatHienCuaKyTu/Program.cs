using System.Text;
namespace SoLanXuatHienCuaKyTu
{
    class SoLanXuatHienCuaKyTu
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Bạn hãy nhập vào một chuỗi : ");
            string s = Console.ReadLine();
            Console.WriteLine("Bạn hãy nhập ký tự cần đếm : ");
			char c = char.Parse(Console.ReadLine());
			int answer = 0;
			for (int i = 0; i < s.Length; i++) {
				if (s[i] == c) {
					answer++;
				}
			}
			Console.WriteLine($"Chuỗi {s} có {answer} ký tự {c}" );
        }
    }
}