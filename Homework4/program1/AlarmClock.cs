using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace program1
{
    public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);

    public class AlarmEventArgs : EventArgs
    {
        public int anHour;
        public int aMinute;
        public int aSecond;
    }

    public class AlarmClock
    {
        public event AlarmEventHandler anAlarmEvent;

        private int anHour;
        private int aMinute;
        private int aSecond;
        private bool alarmEnable;
        private AlarmEventArgs alarm;
        private Timer aTimer;

        public AlarmClock()
        {
            this.anHour = DateTime.Now.Hour;
            this.aMinute = DateTime.Now.Minute;
            this.aSecond = DateTime.Now.Second;

            aTimer = new Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(Updata);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            alarm = new AlarmEventArgs();
            anAlarmEvent += Alarm;
            alarmEnable = false;
        }

        private void Updata(object source, ElapsedEventArgs e)
        {
            this.aSecond += 1;
            if (this.aSecond >= 60)
            {
                this.aSecond -= 60;
                this.aMinute += 1;
                if (this.aMinute >= 60)
                {
                    this.aMinute -= 60;
                    this.anHour += 1;
                    if (anHour >= 24)
                    {
                        this.anHour -= 24;
                    }
                }
            }
            if (alarm.anHour == this.anHour &&
                alarm.aMinute == this.aMinute &&
                alarm.aSecond == this.aSecond &&
                alarmEnable == true)
            {
                anAlarmEvent(this, alarm);
            }
        }

        public void SetTime()
        {
            int anHour = 0;
            int aMinute = 0;
            int aSecond = 0;
            try
            {
                Console.Write("请输入你想设置的小时：");
                anHour = int.Parse(Console.ReadLine());
                if (anHour >= 24)
                {
                    throw new Exception("some message");
                }
                Console.Write("请输入你想设置的分钟：");
                aMinute = int.Parse(Console.ReadLine());
                if (aMinute >= 60)
                {
                    throw new Exception("some message");
                }
                Console.Write("请输入你想设置的秒：");
                aSecond = int.Parse(Console.ReadLine());
                if (aSecond >= 60)
                {
                    throw new Exception("some message");
                }
            }
            catch
            {
                Console.WriteLine("输入有误请重新输入。");
                SetTime();
            }
            this.anHour = anHour;
            this.aMinute = aMinute;
            this.aSecond = aSecond;
        }

        public void CloseAlarm()
        {
            alarmEnable = false;
        }

        public void OpenAlarm()
        {
            alarmEnable = true;
        }

        public void SetAlarm()
        {
            int anHour = 0;
            int aMinute = 0;
            int aSecond = 0;
            try
            {
                Console.Write("请输入你想设置闹钟的小时：");
                anHour = int.Parse(Console.ReadLine());
                if (anHour >= 24)
                {
                    throw new Exception("some message");
                }
                Console.Write("请输入你想设置闹钟的分钟：");
                aMinute = int.Parse(Console.ReadLine());
                if (aMinute >= 60)
                {
                    throw new Exception("some message");
                }
                Console.Write("请输入你想设置闹钟的秒：");
                aSecond = int.Parse(Console.ReadLine());
                if (aSecond >= 60)
                {
                    throw new Exception("some message");
                }
            }
            catch
            {
                Console.WriteLine("输入有误请重新输入。");
                SetAlarm();
            }
            this.alarm.anHour = anHour;
            this.alarm.aMinute = aMinute;
            this.alarm.aSecond = aSecond;
        }

        private void Alarm(object sender, AlarmEventArgs e)
        {
            Console.WriteLine("叮叮叮...闹钟响了。");
            ShowTime();
        }

        public void ShowTime()
        {
            Console.WriteLine("当前时间是：" + this.anHour + ":" + this.aMinute + ":" + this.aSecond);
        }
    }
}
