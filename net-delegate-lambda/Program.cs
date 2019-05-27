using System;

//익명함수 구현방법 2가지중 (Lambda, 무명함수) Lambda + Action/Func를 이용한 방법임
//https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions


//Action : 미리정의된 리턴값 없는 델리게이트
//Func : 미리정의된 리턴값 가능한 델리게이트
//델리게이트이기 때문에 <in, out>정의후 람다식으로 본체 바로 연결 가능!!!!!

namespace net_delegate_lambda
{
    class Program
    {
        static Action<int, int> Plus = (int a, int b) => 
        {
            Console.WriteLine("plus {0} + {1} = {2}", a, b, a + b);     
        };

        static Func<string, string> Echo = (string msg) => 
        {
            return "This is your msg (" + msg + ")";
        };


        //굳이 Action, Func를 이렇게 쓸 필요가 있을까?
        static Func<string> Ping; 

        static string PrintPong() 
        {
            return "Pong";
        }


        static void Main(string[] args)
        {
            Plus(1, 2);                               //plus 1 + 2 = 3 
            Console.WriteLine(Echo("Ping~~~"));       //This is your msg (Ping~~~)

            //쓸데없는 방식 같음
            Ping = PrintPong;
            Console.WriteLine(Ping());              //Pong
        }
    }
}
