using System;

//A
using System.Collections.Immutable;

namespace ExtInterface
{
    public interface IUtil 
    {
        string Ping();
    }

    public class Util : IUtil
    {
        public string Ping() 
        {
            return "Pong";
        }
    }

    public static class UtilExt
    {
        public static string Echo(this object obj, string msg) 
        {
            return msg;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Util util = new Util();

            Console.WriteLine(util.Ping());
            Console.WriteLine(util.Echo("This is interface extension method"));
        }
    }
}
