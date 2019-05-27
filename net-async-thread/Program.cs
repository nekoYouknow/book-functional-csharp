using System;
using System.Diagnostics;
using System.Threading;

namespace net_async_thread
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("start");
            Console.WriteLine("{0}", Wait());   //12
            Console.WriteLine("end : {0} seconds", sw.ElapsedMilliseconds / 1000); //7 seconds
            
        }

        //여기가 포인트 (2개의 작업을 thread로 동시에 수해)
        public static int Wait()
        {
            int i = 0, j = 0;

            //쓰레드 생성
            Thread t1 = new Thread(() => i = Wait5());
            Thread t2 = new Thread(() => j = Wait7());

            //쓰레드 시작
            t1.Start();
            t2.Start();

            //쓰레드 종료 대기
            t1.Join();
            t2.Join();

            return i + j;
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
