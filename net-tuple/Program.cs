using System;

//Tuple 사용법 3가지


namespace net_tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. 이름없이, Item1, Item2... 이렇게 접근가능.. Max값이.. 8? 18?
            var a = (1920, 1080);
            Console.WriteLine("{0} x {1}", a.Item1, a.Item2);       //1920 x 1080
            Console.WriteLine("a.Item1의 형식: {0}", a.Item1.GetType());    //System.Int32

            //2. 이름을 지정해서
            var b = (width: 100, height: 200);
            Console.WriteLine("{0} x {1}", b.Item1, b.Item2);   //여전이 이렇게 도 쓸수 있고
            Console.WriteLine("{0} x {1}", b.width, b.height);  

            //3. 형식과 이름을 지정해서 
            (string name, int age) person = ("neko", 18);
            Console.WriteLine("{0} - {1}", person.Item1, person.Item2); //여전히 이렇게 사용 가능
            Console.WriteLine("{0} - {1}", person.name, person.age);

        }
    }
}
