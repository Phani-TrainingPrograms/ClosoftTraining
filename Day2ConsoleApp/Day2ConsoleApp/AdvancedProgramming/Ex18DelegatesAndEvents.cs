using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;

//Delegates are like function pointers of C++.
//If U want to pass a function as an argument, then the feature of delegates make sense. 
//They are helpful for creating callback functions where a function shall call another function after a certain period of time. 
//A Delegate instance can point to only those functiona that match to the signature of the delegate.
//Events work on the same concept. This is based on design pattern called LISTENER Pattern. The object creator shall register an action that will be performed on that object. When the action(event) is performed, the caller shall have an Event handler registered that will be invoked when the event occurs. 
//All events are instances of a delegate. 
//Functions that return void and functions that return non void. 
//.NET gives 2 delegates: Action(void Functions) and Func(Non void Functions).
//Func is used for delegating functions with return values. 
//They are generice in nature. 
namespace AdvancedProgramming
{
    class Clock
    {
        private DateTime _alarmTime;

        public Clock(DateTime _time)
        {
            _alarmTime = _time;
        }

        public void DisplayClock(Action action)//Action is a built in delegate that refers to a function. 
        {
            while(true)
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                Thread.Sleep(1000);//Stops UR App execution for one second. 
                Console.Clear();
                //If the alarmTime is met, then the clock shall call a function. 
                if(action != null)
                {
                    if(DateTime.Now.Minute == _alarmTime.Minute)
                    {
                        action();
                    }
                }
            }
        }

        public void StopClock(Action<string> func)
        {
            //Some condition which makes UR clock stop..
            Console.WriteLine("Clock has stopped ticking");
            func("Time to close the Window");
        }

    }

    class ArithematicCalculator
    {
        public void PerformOperation(Func<double, double, double> function)
        {
            //Last type is the return type and any type before the last is the input parameters of that func delegate. 
            Console.WriteLine("Enter the First value");
            var v1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second value");
            var v2 = double.Parse(Console.ReadLine());
            var result = function(v1, v2);
            Console.WriteLine("The result of this operation is " + result); 
        }
    }

    class Button
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int ColorCode { get; set; }

        public event Action OnClick;

        public void Display()
        {
            Console.WriteLine("Displays the button and User clicks it");
            if(OnClick != null) { OnClick(); }
        }

    }
    internal class Ex18DelegatesAndEvents
    {
        static void OnRecievingMessage(string msg)
        {
            Console.WriteLine(msg);//msg is the message sent by the clock thru StopClock. 
        }
        static void OnAlarm()
        {
            Console.WriteLine("Time to wake up!");
        }

        static double addfunc(double v1, double v2) 
        {
            return v1+ v2;
        }
        static void Main(string[] args)
        {
            Clock myClock = new Clock(DateTime.Now.AddMinutes(1));
            //Action action = new Action(OnAlarm);//Delegates are reference types, U shall create an instance of it and in its constructor  U shall set the function name to which UR object will point. 
            //myClock.DisplayClock(action);//Passing the function as argument.

            myClock.StopClock(OnRecievingMessage);


            //ArithematicCalculator calc = new ArithematicCalculator();
            //calc.PerformOperation(addfunc);

            //calc.PerformOperation((v1, v2) => v1 - v2);//Lambda Functions.....

            Button btn  = new Button();
            btn.Height = 30;
            btn.Top = 30;
            btn.Bottom = 60;
            btn.Width = 60;
            btn.OnClick += Btn_OnClick;
            btn.OnClick += () => Console.WriteLine("Another action associated with same event");
            btn.Display();
        }

        //Event handler/Function for UR delegate instance. 
        private static void Btn_OnClick()
        {
            Console.WriteLine("Button is clicked"); 
        }
    }
}
