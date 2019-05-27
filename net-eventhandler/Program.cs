using System;

namespace net_eventhandler
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEventHandler ev = new MyEventHandler();
            ev.OnChange += (sender, e) => Console.WriteLine("Event raise with args: {0}", e.Value);
            ev.Raise();

            MyEventHandler2 ev2 = new MyEventHandler2();
            ev2.OnChange += (sender, e) => Console.WriteLine("Event raise with idx: {0}", e.Idx);
            ev2.Raise();
        }
    }


    public class MyArgs : EventArgs
    {
        public int Value {get; set;}
        public MyArgs(int value) 
        {
            this.Value = value;
        }
    }

    public class MyEventHandler 
    {
        //Action delegate 대신 EventHandler<T> 를 사용가능
        public event EventHandler<MyArgs> OnChange = (sender, e) => {};
        public void Raise() 
        {
            OnChange(this, new MyArgs(18));
        }
    }

    public class MyArgs2: EventArgs
    {
        public int Idx {get; set;}
        public MyArgs2(int idx) 
        {
            this.Idx = idx;
        }
    }

    public class MyEventHandler2 
    {
        public event EventHandler<MyArgs2> OnChange = (sender, e) => {};
        public void Raise() 
        {
            OnChange(this, new MyArgs2(1));
        }
    }
    
}
