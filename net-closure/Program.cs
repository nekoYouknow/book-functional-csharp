using System;

//클로저 : 일급함수를 리턴 (지역변수 유지됨)
// 퍼스트클래스함수에서 선언된 지역변수는 
//해당 함수가 삭제되기 전까지 변수가 없어지거나 초기화 되지 않는다. 
//다음 예제를 보면 지역변수 localVal값이 계속 증가한다

namespace net_closure
{
    class Program
    {
        static void Main(string[] args)
        {
            //No closure test
            Console.WriteLine("No closure {0}", NoClosure());
            Console.WriteLine("No closure {0}", NoClosure());

            //Yes closure test
            var yesClosure = YesClosure();
            Console.WriteLine("Yes closure {0}", yesClosure());
            Console.WriteLine("Yes closure {0}", yesClosure());
            Console.WriteLine("Yes closure {0}", yesClosure());

        }


        static int NoClosure() 
        {
            int cnt = 0;
            cnt += 1;
            return cnt;
        }

        static Func<int> YesClosure() 
        {
            //A: 지역변수
            int cnt = 0;

            //B: 일급함수를 리턴함 (현재는 람다식)
            return () => ++cnt;
        }
    }
}
