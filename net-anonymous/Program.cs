using System;

//A: 무명타입 
//B: 무영함수

class Program
{
    delegate string MyHi(string name);

    static void Main(string[] args)
    {
        //A: 무명타입
        var arg = new { Idx = 1, Name = "Neko", Sex = "1" };


        //B: 무명함수
        //무명함수는 이름이 없기 때문에 변수에 할당하려면 delegate 변수가 필요하다
        //무명함수는 delegate키워드를 이용해서 작성=delegate변수에 함수본체를 연결하는 방식 (아래처럼)

        //요렇게 해야함
        MyHi myHi = delegate(string name) 
        {
            return "hi " + name;
        };

        Console.WriteLine(myHi("neko"));
        Console.WriteLine(myHi("jane"));
        
        //javascript처럼은 안됨 
        /*
        var hi = delegate (string name) 
        {
            return "Hi " + name;
        };
        */
    }
}
