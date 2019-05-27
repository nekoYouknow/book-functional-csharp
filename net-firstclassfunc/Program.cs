using System;

//람다식 + 델리게이트는 훌륭한 FirstClassFunc를 확인가능하다


namespace net_firstclassfunc
{
    class Program
    {
        //delegate = firstclassfunc
        static Func<string, string> dispMsgDel = name => "Hi " + name;

        //아규먼트로 받은 firstclassfunc를 실행해 보자
        static void firstClassFuncTester(Func<string, string> funct, string name) 
        {
            Console.WriteLine(funct(name));
        }


        static void Main(string[] args)
        {
            //firstclassfunc를 아규먼트로 넘겨보자
            firstClassFuncTester(dispMsgDel, "neko");
        }

    }

    
}
