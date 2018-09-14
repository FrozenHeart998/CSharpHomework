using System;
using System.Collections;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList aList = CreateAnArr();
            PrimeNum(aList);
            OutPrimeNum(aList);
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        static ArrayList CreateAnArr()
        {

            ArrayList aList = new ArrayList();

            for (int i = 0; i < 99; i++)
            {
                aList.Add(i + 2);
            }

            return aList;

        }

        static void PrimeNum(ArrayList aList)
        {

            for (int i = 0; i < aList.Count; i++)
            {
                int aNum = int.Parse(aList[i].ToString());
                if ((aNum % 2 == 0 || aNum % 3 == 0 || aNum % 5 == 0 || aNum % 7 == 0)
                    && aNum != 2 && aNum != 3 && aNum != 5 && aNum != 7)
                {
                    aList.Remove(aList[i]);
                    i--;
                }
            }

        }

        static void OutPrimeNum(ArrayList aList)
        {
            Console.WriteLine("2到100以内的素数有：");

            foreach (var aObj in aList)
            {
                Console.WriteLine(aObj);
            }

        }
    }
}
