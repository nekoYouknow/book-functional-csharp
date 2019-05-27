using System;
using System.Collections.Generic;
using System.Linq;


partial class Program
{
    static int[] intArray = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    static IEnumerable<int> intArray2 = Enumerable.Range(0, 100);

    static void Main()
    {
        //Test1();    //basic test
        //Test2();    //filter: where, take, skip, takewhile, skipwhile, distinct
        Test3();    //projection : Select, SelectManu
    }
}

//투영(projection) : 하나의 개체를 다른 형태로 변환
//Select : 주어진 람다식 이용
//SelectMany : 개별 입력 요소를 변환한 다음 결과를 모두 연결
partial class Program
{
    static void Test3() 
    {
        //기본
        var list = from o in intArray2
                    where o < 3
                    select o;
        list.WriteList();

        //변환
        list = from o in intArray2
                where o < 3
                select o * 2;
        list.WriteList();

        //변환2
        var list2 = from o in intArray2
                    where o < 3
                    select (a:o, b:o*2, c:o.GetType());
        
        foreach(var o in list2)
            Console.WriteLine("a={0}, b={1}, c={2}", o.a, o.b, o.c);
        
        //변환3 : 메트릭스곱(?)을 반환한다
        //{(cat1, 1), (cat1, 2), (cat2, 1), (cat2, 2), (cat3, 1), (cat3, 2)}

        string[] cats = {"cat1", "cat2", "cat3"};
        int[] sex = {1, 2};
        
        var list3 = cats.SelectMany(cat => sex, (x, y) => new {x, y});
        foreach(var o in list3)
            Console.WriteLine("{0}, {1}", o.x, o.y);
        Console.WriteLine();

        //위와 동일한 쿼리식 방법
        var list4 = from x in cats
                    from y in sex
                    select (x, y);
        foreach(var o in list4)
            Console.WriteLine("{0}, {1}", o.x, o.y);
        Console.WriteLine();



        
    }
}


//필터링 - Where, Take, Skip, TakeWhile, SkipWhile, Distinct
partial class Program
{
    static void Test2() 
    {
        IEnumerable<int> list = intArray2.Skip(5).Take(5);      //5~9
        list.WriteList();

        //TakeWhile, SkipWhere : 조건자가 true일때만...
        list = intArray2.SkipWhile(i=> i<5).TakeWhile(i => i<10);   //5~9
        list.WriteList();

        IEnumerable<char> queryDist = "ThisThat".Distinct();
        queryDist.WriteList();
    }
}

//플루언트구문, 쿼리식구문
partial class Program 
{
    static void Test1() 
    {
        //홀수만 추리기
        IEnumerable<int> oddData = System.Linq.Enumerable.Where(intArray, i => i.IsOdd());
        IEnumerable<int> oddData2 = intArray.Where(i => i.IsOdd());

        Console.WriteLine("Odd Data from 0-9 are: ");
        oddData.WriteList();

        Console.WriteLine("Odd Data2 from 0-9 are: ");
        oddData2.WriteList();

        int cnt = intArray.Where(i => i.IsOdd()).Count();
        Console.WriteLine("cnt={0}", cnt);

        //플루언트 구문 (fluent syntax)
        //Where, Select, SelectMany, OrderBy, ThenBy, OrderByDescending, ThenByDescending, GroupBy, Join, GroupJoin
        IEnumerable<int> queryInt = intArray.Where(i => i.IsOdd()).OrderByDescending(i => i);
        queryInt.WriteList();

        //쿼리식 구문
        queryInt = from i in intArray
                    where i.IsOdd()
                    orderby i descending
                    select i;
        queryInt.WriteList();
    }
}


public static class Ext 
{
    public static bool IsOdd(this int i) 
    {
        return (i % 2) == 1;
    }
    
    public static void WriteList<T>(this IEnumerable<T> list)
    {
        foreach(var x in list)
            Console.Write("{0} \t", x.ToString());
        Console.WriteLine();
    }

}
