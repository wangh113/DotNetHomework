using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockDemo
{
    public delegate void TickEventHandler();
    public delegate void AlarmEventHandler();

    class Clock
    {
        private int _hour;
        private int _minute;
        public event TickEventHandler Tick;
        public event AlarmEventHandler Alarm;

        public Clock(int hour, int minute)
        {
            _hour = hour;
            _minute = minute;
        }

        public void Run()
        {
            while (true)
            {
                DateTime currentTime = DateTime.Now;
                if (currentTime.Hour == _hour && currentTime.Minute == _minute)
                {
                    Alarm?.Invoke();
                    break;
                }
                else
                {
                    if (Tick != null)
                    {
                        Tick();
                    }
                    System.Threading.Thread.Sleep(1000); // 等待1秒
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建闹钟实例，设置时间为 11:20
            Clock clock = new Clock(11, 20);
            // 订阅嘀嗒事件和响铃事件
            clock.Tick += new TickEventHandler(OnTick);
            clock.Alarm += new AlarmEventHandler(OnAlarm);
            // 运行闹钟
            clock.Run();
        }

        // 嘀嗒事件处理函数
        static void OnTick()
        {
            Console.WriteLine("滴答,当前时间："+ DateTime.Now.ToString());
        }

        // 响铃事件处理函数
        static void OnAlarm()
        {
            Console.WriteLine("响铃,闹钟为：" + DateTime.Now.ToString());
        }
    }
}