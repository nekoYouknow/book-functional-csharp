using System;

//A
using System.Threading.Tasks;

//Task 7가지 사용 방법

class Program
{
    static void Main(string[] args)
    {
        //Test1();
        //Test2();
        //Test3();
        //Test4();
        //Test5();
        //DoWork();   //Task Run
        Console.WriteLine(DoWork3().Result);     //Task.FromResult<T>()
    }

    //1.직접호출
    private static void Test1() 
    {
        Task t1 = Task.Factory.StartNew(() => {
            Console.WriteLine("Test1");
        });
        t1.Wait();

        //이건 분류가 어딘지 모름
        Task t2 = new Task(Hello);
        t2.Start();
    }

    //2.Action 사용
    private static void Test2()
    {
        Task t1 = Task.Factory.StartNew(new Action(Hello));
        Task t2 = Task.Factory.StartNew(new Action<object>(Echo), "t2");

        Task t3 = new Task(new Action<object>(Echo), "t3");
        t3.Start();

        t1.Wait();
        t2.Wait();
        t3.Wait();
    }

    //3.Delegate 사용
    private static void Test3()
    {
        Task task = new Task(delegate {
            Echo("delegated called");
        });
        task.Start();
        task.Wait();
    }

    //4.Lambda 사용
    private static void Test4() 
    {
        Task t1 = new Task(() => Echo("Lambda called"));
        t1.Start();
        t1.Wait();
    }

    //5.Lambda + Anonymouse method
    private static void Test5() 
    {
        Task t1 = new Task(() => {
            Echo("Lambda + Anonymouse method");
        });
        t1.Start();
        t1.Wait();
    }

    //6.Task.Run()
    //async-await는 void, Task, Task<T> 만 리턴할 수 있다
    //값을 리턴받는건 포기해
    public static async void DoWork()
    {
        var task = Task.Run(() => Plus(10, 20));
        int i = await task;
        Console.WriteLine("Task.run = " + i.ToString());
    }

    //7.Task.FromResult()
    //async-await는 void, Task, Task<T> 만 리턴할 수 있다
    public static async Task<int> DoWork3()
    {
        return await Task.FromResult<int>(Plus(1, 2));
    }

    //-------------------------------------------
    // 공용 함수
    //-------------------------------------------
    private static void Hello() 
    {
        Console.WriteLine("Hello");
    }
    private static void Echo(object msg) 
    {
        Console.WriteLine(msg.ToString());
    }

    private static int Plus(int a, int b) 
    {
        return a + b;
    }
}
