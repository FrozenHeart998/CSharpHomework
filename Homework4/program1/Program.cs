using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock anAlarmClock = new AlarmClock();
            anAlarmClock.SetAlarm();
            anAlarmClock.OpenAlarm();
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
