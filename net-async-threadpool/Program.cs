using System;
using System.Diagnostics;
using System.Threading;

namespace net_async_threadpool
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("start");
            Console.WriteLine("{0}", Wait());   //0
            Console.WriteLine("end: {0} seconds", sw.ElapsedMilliseconds / 1000); //0 seconds

            Console.ReadLine(); //기다려 줘야 쓰레드 출력을 볼 수 있다

        }


        public static int Wait() 
        {
            int i = 0, j = 0;

            //유휴상태의 쓰레드에 할당
            ThreadPool.QueueUserWorkItem(t => i = Wait5());
            ThreadPool.QueueUserWorkItem(t => j = Wait7());

            return i + j;    //종료를 기다리지 않음.. 따라서 0을 리턴. Barrier등 다른것 필요
        }


        public static int Wait5() 
        {
            Console.WriteLine("a");
            Thread.Sleep(5000);
            Console.WriteLine("a2");
            return 5;
        }

        public static int Wait7()
        {
            Console.WriteLine("b");
            Thread.Sleep(7000);
            Console.WriteLine("b2");
            return 7;
        }

    }
}
