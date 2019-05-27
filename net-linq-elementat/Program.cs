using System;
using System.Collections.Generic;
using System.Linq;

//요소연산 
/*
- First, FirstOrDefault
- Last, LastOrDefault
- Single, SingleOrDefault
- ElementAt, ElementAtOrDefault
- DefaultIfEmpty
 */

namespace net_linq_elementat
{
    class Program
    {

        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 9);
            list.WriteList();
        
            Console.WriteLine("first={0}", list.First().GetType());
            Console.WriteLine("first2={0}", list.First(x => x % 3 == 0));   //3으로 나눠 첫번째 : 3
            Console.WriteLine("firstOrDefault={0}", list.FirstOrDefault(x => x % 10 == 0)); //에러없이 int의 디폴트 0을 리턴
            
            Console.WriteLine("last={0}", list.Last());
            Console.WriteLine("last2={0}", list.Last(x => x % 3== 0));  //9
            //Console.WriteLine("last3={0}", list.Last(x => x % 10 == 0));  //오류발생
            Console.WriteLine("lastOrDefault={0}", list.LastOrDefault(x => x % 10 == 0));

            Console.WriteLine("single={0}", list.Single(x => x == 1));             //1
            Console.WriteLine("singleOrDefault={0}", list.SingleOrDefault(x => x == 20));   //0

            Console.WriteLine("elementAt={0}", list.ElementAt(2));  //3
            Console.WriteLine("elementAtOrDefault={0}", list.ElementAtOrDefault(10000));    //0
        
            Console.WriteLine("DefaultIfEmpty={0}", list.DefaultIfEmpty()); //입력이 없으면 디폴트 반환

            //여기서부턴 쓰지말자.. 
            list = Enumerable.Range(0, 0);
            list.WriteList();
            Console.WriteLine("DefaultIfEmpty2={0}", list.DefaultIfEmpty());
            foreach(var i in list.DefaultIfEmpty())
                Console.Write("x={0}", i);
            Console.WriteLine();
        }

        
    }

    public static class Ext
    {
        public static void WriteList<T>(this IEnumerable<T> list)
        {
            foreach(var x in list)
                Console.Write("{0}", x);
            Console.WriteLine();
        }
    }
}
