using System;

//확장메서드는 public static class + public static method여야 한다
//확장메서드의 앞에것이 아규먼트 this에 할당된다 
// - (this xxx, ...) : 5.Ping(), "neko".Hi("blabla"); [this에할당].extmethod(1starg, 2starg)
//소스는 없지만 기능확장을 하고 싶을때 유용함 (this에 class 변수 넘겨서 기능확장 가능

namespace net_extension_method
{
    public static class ExtClass
    {
        public static string Ping(this object obj) 
        {
            return "pong - " + obj.ToString();
        }

        public static string Hi(this object obj, string msg) 
        {
            return string.Format("Hi {0} - {1}", msg, obj.ToString());
        }
    }

    public static class LibExt
    {
        public static string MyUpper(this string str) 
        {
            return str.ToUpper();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ping...{0}", 69.Ping());
            Console.WriteLine("Ping...{0}", "blabla".Ping());

            var anyType = new { Idx = 1, Age = 18 };
            Console.WriteLine("anyType={0}", anyType.Ping());

            Console.WriteLine("Hi...{0}", "neko".Hi("love you"));

            Console.WriteLine("This is upper string".MyUpper());
            
        }
    }
}
