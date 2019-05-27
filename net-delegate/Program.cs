using System;


namespace net_delegate
{
    class Program
    {
        //A. 델리게이트 타압 선언 (in/out)
        delegate void CalcDelegate(int a, int b);

        //B. 함수작성 (in/out 타입이 같아야함)
        static void Plus(int x, int y)
        {
            Console.WriteLine("plus : {0} + {1} = {2}", x, y,  x + y);
        }
        static void Minus(int x, int y)
        {
            Console.WriteLine("minus {0} - {1} = {2}", x, y, x - y);
        }


        static void Main(string[] args)
        {
            //C. 델리게이트에 함수 연결
            CalcDelegate calc = Plus;
            calc += Minus;  //여러개 연결 가능
            calc(1, 2);     
            //result
            /*
            plus: 1 + 2 = 3
            minus : 1 - 2 = -1
            */

            calc -= Plus;   //연결을 해제 할수도 있다
            calc(1, 2);
            //minus : 1 - 2 = -1
        

        }
    }
}
