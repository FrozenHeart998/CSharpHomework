using System;
using System.Collections;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] anArray = InData();
            OutPrimeNum(anArray);
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        static int[] InData()
        {
            int aSize = 0;
            try
            {
                Console.WriteLine("请输入你的数据个数(输入0直接退出)：");
                aSize = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("你的输入有误，请重新输入。\n");
                InData();
            }

            if (aSize == 0)
            {
                System.Environment.Exit(0);
            }

            int[] anArray = new int[aSize];

            Console.WriteLine("请依次输入你的数据：");

            for (int i = 0; i < aSize; i++)
            {

                try
                {
                    anArray[i] = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("你的输入有误，请重新输入。\n");
                    i--;
                }
            }

            return anArray;

        }

        static void OutPrimeNum(int[] anArray)
        {
            Console.WriteLine("\n你输入的数据中是素数的有：");
            foreach (int aNum in anArray)
            {
                if (aNum % 2 != 0 && aNum % 3 != 0 && aNum % 5 != 0 && aNum % 7 != 0
                    || aNum == 2 || aNum == 3 || aNum == 5 || aNum == 7)
                {
                    Console.WriteLine("" + aNum);
                }
            }
        }
    }
}
