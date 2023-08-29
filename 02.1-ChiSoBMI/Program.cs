using System;
using System.Text;

namespace SystemTime
{
    class Program
    {
        static void Main(string[] arg)
        {
            float w;
            float h;

            Console.WriteLine("Please enter a height");
            h = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your weight");
            w = float.Parse(Console.ReadLine());

            double bmi = w / Math.Pow(h,2);
            bmi = Math.Round(bmi, 1);

            Console.Write($"BMI: {bmi}");

            if (bmi < 18)   
                Console.WriteLine(" Underweight");
            else if (bmi < 25.0)
                Console.WriteLine(" Normal");
            else if (bmi < 30.0)
                Console.WriteLine(" Overweight");
            else
                Console.WriteLine(" Obese");
        }
    }

}

