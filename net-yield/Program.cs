using System;
using System.Collections.Generic;

namespace net_yield
{
    class Program
    {
        static IEnumerable<int> GetNumber() 
        {
            yield return 10;    //첫번째 루프에서 리턴하는 값
            yield return 20;    //두번째 루프에서 리턴하는 겂
            yield return 30;    //세번째 루프에서 리턴하는 값
        }

        static void Main(string[] args)
        {
            foreach(int num in GetNumber())
            {
                Console.WriteLine(num);
            }
        }
    }
}
