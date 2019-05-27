using System;
using System.Collections.Generic;
using System.Linq;

namespace net_linq_join
{
    class Program
    {
        static void Main(string[] args)
        {
            var corps = new List<Corp>() {
                new Corp() {
                    Code = "C001",
                    CorpName = "Google"
                },
                new Corp() {
                    Code = "C002",
                    CorpName = "Apple"
                }
            };

            var users = new List<User>() {
                new User() {
                    UserId = "User1", 
                    UserName = "Tom",
                    CorpCode = "C001"
                },
                new User() {
                    UserId = "User2",
                    UserName = "Jane",
                    CorpCode = "C002"
                },
                new User() {
                    UserId = "User3", 
                    UserName = "Sulgi",
                    CorpCode = "C002"
                },
                new User() {
                    UserId = "User4",
                    UserName = "Bora",
                    CorpCode = "C003"
                }
            };

            var list = from corp in corps
                        join user in users on corp.Code equals user.CorpCode
                        select new {
                            CorpCode = corp.Code,
                            CorpName = corp.CorpName,
                            UserId = user.UserId,
                            UserName = user.UserName 
                        };
            Console.WriteLine("start");
            foreach(var o in list) 
                Console.WriteLine("{0}, {1}, {2}, {3}", o.CorpCode, o.CorpName, o.UserId, o.UserName);
            Console.WriteLine("end");

            //플루언트 구문은 이해가 안됨.... 
            //GroupJoin도 이해 안됨...

        }
    }


    public class Corp
    {
        public string Code {get; set;}
        public string CorpName {get; set;}
    }

    public class User
    {
        public string UserId {get; set;}
        public string UserName {get; set;}
        public string CorpCode {get; set;}
    }
}
