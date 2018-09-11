using System;

namespace Program1
{
    class Program
    {
        static private string NumberOneStr;
        static private string NumberTwoStr;

        static void Main(string[] args)
        {
            InputNumber();
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        static private void InputNumber()
        {
            Console.WriteLine("请输入第一个数字：");
            NumberOneStr = Console.ReadLine();
            Console.WriteLine("请输入第二个数字：");
            NumberTwoStr = Console.ReadLine();

            try
            {
                float NumberOne = float.Parse(NumberOneStr);
                float NumberTwo = float.Parse(NumberTwoStr);
                Console.WriteLine("两个数字的乘积是：" + (NumberOne * NumberTwo));
            }
            catch
            {
                Console.WriteLine("输入有误，请重新输入。");
                InputNumber();
            }
        }
    }
}
