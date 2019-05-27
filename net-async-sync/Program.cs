using System;
using System.Diagnostics;
using System.Threading;

//동기식 프로그램임

namespace net_async_sync
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("start");
            Console.WriteLine("{0}", Wait());       //12
            Console.WriteLine("end : {0} seconds", sw.ElapsedMilliseconds / 1000); //12 seconds
        }

        public static int Wait() 
        {
            return Wait5() + Wait7();
        }
        public static int Wait5()
        {
            Thread.Sleep(5000);
            return 5;
        }

        public static int Wait7()
        {
            Thread.Sleep(7000);
            return 7;
        }
    }
}
