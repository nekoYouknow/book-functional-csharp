using System;
using System.Collections.Generic;
using System.Linq;

//정렬: OrderBy, ThenBy, OrderByDescending, ThenByDescending

namespace net_linq_orderby
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>(){
                new User() {Idx=1, Name="UserB", Age=33},
                new User() {Idx=2, Name="UserA", Age=23},
                new User() {Idx=3, Name="UserA", Age=22},
                new User() {Idx=4, Name="UserC", Age=11}
            };
        
            //ordery by
            IEnumerable<User> list = users.OrderBy(u => u.Name);
            list.WriteList();


            //orderby + thenby
            list = users.OrderBy(u => u.Name).ThenBy(u => u.Age);
            list.WriteList();


            //orderbyDescending + thenbyDescending
            list = users.OrderByDescending(u => u.Name).ThenByDescending(u => u.Idx);
            list.WriteList();
        }
    }

    public class User 
    {
        public int Idx {get; set;}
        public string Name {get; set;} 
        public int Age {get; set;}
    }

    public static class Ext 
    {
        public static void WriteList(this IEnumerable<User> users) 
        {
            foreach(var u in users)
                Console.WriteLine("{0} / {1} / {2}", u.Idx, u.Name, u.Age);
            Console.WriteLine();
        }
    }


}
