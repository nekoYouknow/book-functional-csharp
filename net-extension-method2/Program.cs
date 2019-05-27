using System;

namespace net_extension_method2
{
    class Program
    {
        static void Main(string[] args)
        {
            //확장하려는 클래스 생성
            Lib lib = new Lib();

            //확장클래스의 대상으로 Lib를 지정
            Console.WriteLine(lib.Echo("Lib class ... called echo ext"));

            //대상 지정없이 사용
            Console.WriteLine(0.Echo("O .. called echo ext"));
        }
    }

    //기존 클래스
    class Lib 
    {
        public static string Ping() 
        {
            return "Pong";
        }
    }

    //확장클메서드 (현상태에선 대상이 특정되어 있지 않다)
    //첫 인자가 this인걸로 확장메서드인걸 확인할 수 있다
    public static class LibExt 
    {
        public static string Echo(this object obj, string msg) 
        {
            return msg;
        }
    }
}
