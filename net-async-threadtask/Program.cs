using System;
using System.Threading;
using System.Threading.Tasks;

//Task클래스는 ThreadPool.QueueUserWorkerItem()과 같은 기능 제공
//Task.Factory.StartNew()를 이용해서 실행할 메서드에 대한 델리게이트 지정
//StartNew()는 쓰레드를 생성과 동시에 실행함
//StartNew()는 param으로 Action<object>만 가능, Func불가.. 즉 리턴값 받기 안됨

namespace net_async_threadtask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();   
            //Console.Read(); //요기서 멈춰주지 않으면 아래 출력물 못보고 종료됨      
            //결과
            //5
            //6
            //7

            //Test2();   //여기선 위에처럼 강제로 기다릴 필요 없음
            //결과
            //7
            //5
            //6

            Test3();
            //결과
            //5
            //6
            //7
        }

        //쓰레드 생성과 동시에 실행 (자동시작)
        private static void Test1()
        {
            Task.Factory.StartNew(new Action<object>(Working), 7);
            Task.Factory.StartNew(new Action<object>(Working), 6);
            Task.Factory.StartNew(Working, 5);
        }

        private static void Test2()
        {
            Task t1 = Task.Factory.StartNew(new Action<object>(Working), 7);
            t1.Wait();
            Task t2 = Task.Factory.StartNew(new Action<object>(Working), 6);
            Task t3 = Task.Factory.StartNew(Working, 5);

            t2.Wait();
            t3.Wait();
        }

        //생성, 실행 분리
        private static void Test3()
        {
            Task t1 = new Task(new Action<object>(Working), 7);
            Task t2 = new Task(() => {
                //Console.WriteLine("Long query");
                Working(6);
            });
            Task t3 = new Task(Working, 5);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Wait();
            t2.Wait();
            t3.Wait();
        }
    
        private static void Working(object sec)
        {
            Thread.Sleep(Convert.ToInt32(sec) * 1000);
            Console.WriteLine("Working {0} sec", sec);
        } 
    }
}
