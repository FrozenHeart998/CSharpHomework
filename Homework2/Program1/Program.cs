using System;
using System.Collections;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeFactor();
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        static void PrimeFactor()
        {
            int userNum = 1;
            int primeFactor = 2;

            try
            {
                Console.WriteLine("请输入一个整数：");
                userNum = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("你的输入有误，请重新输入。\n");
                PrimeFactor();
            }

            Console.Write("该整数的素数因子为：");

            if (userNum == 1)
            {
                Console.WriteLine(userNum);
            }
            else
            {
                while (primeFactor <= userNum)
                {
                    if (userNum % primeFactor == 0)
                    {
                        Console.Write(primeFactor + " ");
                        userNum /= primeFactor;
                    }
                    else
                    {
                        primeFactor++;
                    }
                }
                Console.WriteLine();
            }
            
        }
    }
}
