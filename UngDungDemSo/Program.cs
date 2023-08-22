using System;
using System.Text;

class DemSo
{

    static void Main(string[] args)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("***************");
        System.Console.WriteLine("* READ NUMBER *");
        System.Console.WriteLine("***************");


        int num;
        int firstNum;
        int secondNum;
        int thirdNum;
        string strNum;
        System.Console.WriteLine("Enter Number : ");
        num = Convert.ToInt32(Console.ReadLine());


        if (num / 10 < 1)
        {
            strNum = DemSoCo1ChuSo(num);
            System.Console.WriteLine(strNum);
        }
        else if (num / 10 <= 9)
        {
            firstNum = num / 10;
            secondNum = num % 10;
            strNum = DemSoCo2ChuSo(num, firstNum, secondNum);
            System.Console.WriteLine(strNum);
        }
        else if (num / 10 <= 99)
        {
            firstNum = num / 100;
            secondNum = (num / 10) % 10;
            thirdNum = num % 10;
            strNum = DemSoCo3ChuSo(num, firstNum, secondNum, thirdNum);
            System.Console.WriteLine(strNum);
        }

    }

    static string DemSoCo1ChuSo(int num)
    {
        switch (num)
        {
            case 0:
                return "Zero";
            case 1:
                return "One";
            case 2:
                return "Two";
            case 3:
                return "Three";
            case 5:
                return "Five";
            case 6:
                return "Six";
            case 7:
                return "Seven";
            case 8:
                return "Eight";
            case 9:
                return "Nine";
        }
        return null;
    }

    static string DemSoCo2ChuSo(int num, int firstNum, int secondNum)
    {
        switch (firstNum)
        {
            case 1:
                switch (secondNum)
                {
                    case 0:
                        return "Ten";
                    case 1:
                        return "Eleven";
                    case 2:
                        return "Twelve";
                    case 3:
                        return "Thirdteen";
                    case 4:
                        return "Fourteen";
                    case 5:
                        return "Fifteen";
                    case 6:
                        return "Sixteen";
                    case 7:
                        return "Seventeen";
                    case 8:
                        return "Eighteen";
                    case 9:
                        return "Nineteen";
                }
                break;
            case 2:
                if (num == 20)
                {
                    return "twenty";
                }
                return "Twenty " + DemSoCo1ChuSo(secondNum);
            case 3:
                if (num == 30)
                {
                    return "Thirty";
                }
                return "Thirty " + DemSoCo1ChuSo(secondNum);
            case 4:
                if (num == 40)
                {
                    return "Forty";
                }
                return "Forty " + DemSoCo1ChuSo(secondNum);
            case 5:
                if (num == 50)
                {
                    return "Fifty";
                }
                return "Fifty " + DemSoCo1ChuSo(secondNum);
            case 6:
                if (num == 60)
                {
                    return "Sixty";
                }
                return "Sixty " + DemSoCo1ChuSo(secondNum);
            case 7:
                if (num == 70)
                {
                    return "Seventy";
                }
                return "Seventy " + DemSoCo1ChuSo(secondNum);
            case 8:
                if (num == 80)
                {
                    return "Eighty";
                }
                return "Eighty " + DemSoCo1ChuSo(secondNum);
            case 9:
                if (num == 90)
                {
                    return "Ninety";
                }
                return "Ninety " + DemSoCo1ChuSo(secondNum);
        }
        return null;
    }

    static string DemSoCo3ChuSo(int num, int firstNum, int secondNum, int thirdNum)
    {
        switch (firstNum)
        {
            case 1:
                if (num == 100)
                {
                    return "One Hundred";
                }
                return "One Hundred and " + DemSoCo2ChuSo(num, secondNum, thirdNum);
            case 2:
                if (num == 200)
                {
                    return "Two Hundred";
                }
                return "Two Hundred and  " + DemSoCo2ChuSo(num, secondNum, thirdNum);
            case 3:
                if (num == 300)
                {
                    return "Three Hundred";
                }
                return "Three Hundred and " + DemSoCo2ChuSo(num, secondNum, thirdNum);
            case 4:
                if (num == 400)
                {
                    return "Four Hundred";
                }
                return "Four Hundred and " + DemSoCo2ChuSo(num, secondNum, thirdNum);
            case 5:
                if (num == 500)
                {
                    return "Five Hundred";
                }
                return "Five Hundred and " + DemSoCo2ChuSo(num, secondNum, thirdNum);
            case 6:
                if (num == 600)
                {
                    return "Six Hundred";
                }
                return "Six Hundred and " + DemSoCo2ChuSo(num, secondNum, thirdNum);
            case 7:
                if (num == 700)
                {
                    return "Seven Hundred";
                }
                return "Seven Hundred and " + DemSoCo2ChuSo(num, secondNum, thirdNum);
            case 8:
                if (num == 800)
                {
                    return "Eight Hundred";
                }
                return "Eight Hundred and " + DemSoCo2ChuSo(num, secondNum, thirdNum);
            case 9:
                if (num == 900)
                {
                    return "Nine Hundred";
                }
                return "Nine Hundred and " + DemSoCo2ChuSo(num, secondNum, thirdNum);
        }
        return null;
    }
}



