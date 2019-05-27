using System;
using System.Threading.Tasks;

/*
1.Task<TResult> - 값을 반환하는 비동기 메서드
2.Task - 작업을 수행하지만 아무 값도 반환 안함
3.void - 이벤트 처리기의 경우

 */

namespace net_async_tresult
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = Wait2().Result + Wait3().Result;
            //Console.WriteLine("{0}", i);      //5

            /*
            여기 이부분이 비동기가 아님. 
            여기는 순차적으로 실행됨
            */
            Wait4();  //던져놓고 다음 라인 수행
            Wait5();    

            int a = Wait3().Result;     //결과가 올때까지 대기
            Console.WriteLine("a={0}", a);

            int b = Wait2().Result;     //결과가 올때까지 대기
            Console.WriteLine("b={0}", b);


        }

        private static async Task<int> Wait2()
        {
            Console.WriteLine("2a");
            await Task.Delay(2000);
            Console.WriteLine("2b");
            
            return 2;
        }

        private static async Task<int> Wait3()
        {
            Console.WriteLine("3a");
            await Task.Delay(8000);
            Console.WriteLine("3b");
            return 3;
        }


        private static async Task Wait4()
        {
            Console.WriteLine("4a");
            await Task.Delay(4000);
            Console.WriteLine("4b");
        }

        private static async Task Wait5()
        {
            Console.WriteLine("5a");
            await Task.Delay(5000);
            Console.WriteLine("5b");
        }


    }
}
