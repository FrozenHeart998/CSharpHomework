using System;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] anArray = InData();
            Console.WriteLine("你输入的数据最大值是：" + Max(anArray));
            Console.WriteLine("你输入的数据最小值是：" + Min(anArray));
            Console.WriteLine("你输入的数据最平均值是：" + Ave(anArray));
            Console.WriteLine("你输入的数据的和是：" + Sum(anArray));
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

        static int Max(int[] anArray)
        {
            int aMax = anArray[0];

            foreach (int aNum in anArray)
            {
                if (aNum > aMax)
                {
                    aMax = aNum;
                }
            }

            return aMax;

        }

        static int Min(int[] anArray)
        {
            int aMin = anArray[0];

            foreach (int aNum in anArray)
            {
                if (aNum < aMin)
                {
                    aMin = aNum;
                }
            }

            return aMin;

        }

        static double Ave(int[] anArray)
        {
            double aSum = Sum(anArray);

            double aAve = aSum / anArray.Length;

            return aAve;

        }

        static int Sum(int[] anArray)
        {
            int aSum = 0;

            foreach (int aNum in anArray)
            {
                aSum += aNum;
            }

            return aSum;

        }

    }
}
