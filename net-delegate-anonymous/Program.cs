using System;

//익명함수 구현방법 2가지중 (lambda, 무명메서드) 무명메서드 방식 (3.0부터는 거의 lambda를 사용함)
//delegate키워드를 사용한다
//delegate변수에 메서드본체를 연결하는 방식이다

//https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions
//https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-methods


namespace net_delegate_anonymous
{
    class Program
    {
        /* 대표적인 사용방식
        button1.Click += delegate(System.Object o, System.EventArgs e)
        { 
            System.Windows.Forms.MessageBox.Show("Click!"); 
        };
        */

        //Func + 무명메서드 방식
        static Func<string, string> Hello = delegate(string name) 
        {
            return "Hello " + name;
        };

        static void Main(string[] args)
        {
            Console.WriteLine(Hello("neko"));   //Func + Anonymous
        }
    }
}
