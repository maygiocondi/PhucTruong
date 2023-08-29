namespace Tempurature
{
    class Tempurature
    {
        static void Main(string[] args)
        {
            double fahrenheit;
            double celsius;
            int choice;

            do
            {
                Console.WriteLine("Menu.");
                Console.WriteLine("1. Fahrenheit to Celsius");
                Console.WriteLine("2. Celsius to Fahrenheit");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice: ");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Fahrenheit : \t");
                        fahrenheit = Convert.ToDouble(Console.ReadLine());
                        celsius = FahrenheitToCelsius(fahrenheit);
                        Console.WriteLine(fahrenheit + " Fahrenheit = " + celsius + " Celsius"); 
                        break;
                    case 2:
                        Console.Write("Enter Celsius : \t");
                        celsius = Convert.ToDouble(Console.ReadLine());
                        fahrenheit = CelsiusToFahrenheit(celsius);
                        Console.WriteLine(celsius + " Celsius = " + fahrenheit + " Fahrenheit"); 
                        break;
                    case 0:
                        return;
                }
            } while (choice != 0);
        }

        public static double CelsiusToFahrenheit(double celsius)
        {
            double fahrenheit = 1.8f * celsius + 32;
            return fahrenheit;
        }

        public static double FahrenheitToCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32)/1.8f;
            return celsius;
        }
    }
}
