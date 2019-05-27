using System;

namespace net_eventclass
{
    class Program
    {

        static void Main(string[] args)
        {
            EventClass ev = new EventClass();
            ev.OnChange += () => Console.WriteLine("1st");
            ev.OnChange += () => Console.WriteLine("2st");
            ev.Raise();

            EventClass2 ev2 = new EventClass2();
            ev2.OnClick += () => Console.WriteLine("first");
            ev2.OnClick += () => Console.WriteLine("second");
            ev2.Raise();
        }
    }


    public class EventClass
    {
        //public event Action OnChange = () => Console.WriteLine("0st");
        public event Action OnChange;
        public void Raise() 
        {
            OnChange();
        }
    }

    public class EventClass2
    {
        public event Action OnClick;

        public void Raise() 
        {
            OnClick();
        }
    }
}
