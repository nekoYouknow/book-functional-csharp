using System;

//A
using DeepCloneExtension;

namespace net_clone
{
    //B
    [Serializable]
    class Person 
    {
        public string name {get; set;}
        public int age {get; set;}
        public Car car {get; set;}

        //얕은복제 (값이 아닌 객체가 있으면 참조값이 복제됨)
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    [Serializable]
    class Car 
    {
        public string name {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            //C
            Person p1 = new Person() {name="Neko", age=10, car=new Car(){name="BMW"}};
            Person p2 = p1.DeepClone();
            
            Console.WriteLine("name={0}, age={1}, car.name={2}", p1.name, p1.age, p1.car.name);    //name=John, age=20, car.name=Sonata
            Console.WriteLine("name={0}, age={1}, car.name={2}", p2.name, p2.age, p2.car.name);    //name=John, age=20, car.name=Sonata
            
            p2.name = "John";
            p2.age = 20;
            p2.car.name = "GTX";
            Console.WriteLine("name={0}, age={1}, car.name={2}", p1.name, p1.age, p1.car.name);    //name=John, age=20, car.name=Sonata
            Console.WriteLine("name={0}, age={1}, car.name={2}", p2.name, p2.age, p2.car.name);    //name=John, age=20, car.name=Sonata

            /* result
            name=Neko, age=10, car.name=BMW
            name=Neko, age=10, car.name=BMW

            name=Neko, age=10, car.name=BMW
            name=John, age=20, car.name=GTX
            */

        }
    }
}
