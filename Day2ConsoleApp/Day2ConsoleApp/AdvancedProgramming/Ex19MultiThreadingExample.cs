using System;
using System.Threading;

//Multi Threading allows a program to perform multiple tasks at the same time. Example could a kitchen: instead of one chef doing everything sequentially, U have multiple chefs working on different dishes parallelly. Waiting time will be less for the application. 
//A Thread is .NET is an object of a class called System.Threading.Thread. A thread is associated with a delegate(Function) that defines the functionality of what the thread should do, when it starts.
//There are 2 kinds of threads in .NET: Foreground thread and back ground threads: Foreground threads are threads created by default. The Application shall wait till the thread completes its task is what is called a FOREGROUND Thread.
//Background Thread is one where the Main Application shall not wait till the thread completes its job. If the thread is taking more time than the main application, then the thread shall be killed and the application terminates without waiting for the thread to complete its operation. 
//While lock is "one at a time", U can have semaphore which is "N at a time". It can limit how many threads can access a resource concurrently. Think of a nightclub that has capacity of 50 people. If the 50 people are inside, the bouncer makes the 51st person wait until someone leaves. 
//To support semaphores, there is alight weight class called SemaphoreSlim that is modern, light version used in C# for async friendly synchronization. 

namespace AdvancedProgramming
{
    class BankAccount
    {
        private int _balance = 0;
        private readonly object _lockHandle = new object();
        public void Deposit(int amount)
        {
            lock(_lockHandle)
            {
                var name = Thread.CurrentThread.Name;
                _balance += amount;
                Console.WriteLine($"The current balance transacted by {name}: {_balance}");
            }
        }


        public void WithDraw(int amount)
        {
            lock(_lockHandle)
            {
                var name = Thread.CurrentThread.Name;
                if(amount > _balance)
                {
                    throw new Exception("Insufficient funds");
                }
                _balance -= amount;
                Console.WriteLine($"The current balance transacted by {name}: {_balance}");
            }
        }
    }
    internal class Ex19MultiThreadingExample
    {
        static object _handle = new object();
        static void Threadfunc()
        {
            lock(_handle)//MUTEX scenario where one thread will have exclusive access and shall not allow other threads to use it. 
            {
                for(int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Thread is executing with index {i}...");
                    Thread.Sleep(1500);//1 sec break for every loop..
                }
            }
        }
        static void Main(string[] args)
        {
            //firstExample();
            //lockingExample();
            //SimplierLockExample();
        }

        private static void SimplierLockExample()
        {
            Thread t1 = new Thread(Threadfunc);
            Thread t2 = new Thread(Threadfunc);
            t1.Start();
            t2.Start();
        }

        private static void lockingExample()
        {
            BankAccount acc = new BankAccount();
            Thread worker = new Thread(() =>
            {
                acc.Deposit(100);
                Thread.Sleep(2000);
                acc.Deposit(200);
                Thread.Sleep(2000);
                acc.Deposit(5000);
                Thread.Sleep(2000);
            });
            worker.Name = "Cashier 1";
            worker.Start();
            Thread worker2 = new Thread(() =>
            {
                acc.Deposit(300);
                Thread.Sleep(100);
                acc.Deposit(400);
                Thread.Sleep(200);
                acc.WithDraw(300);
                Thread.Sleep(2000);
            });
            worker2.Name = "Cashier 2";
            worker2.Start();
        }

        private static void firstExample()
        {
            Thread worker = new Thread(Threadfunc);//Every thread object takes the instance of the ThreadStart delegate object as its argument. It points to the function that defines the functionality of the thread.
            worker.IsBackground = true;//In this case, the Main app will not wait for the thread to complete the tasks. If the Main app wishes to close the app, then the thread will also be closed(terminated). 
            worker.Start();

            Console.WriteLine("Main program continues to do its job....");
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("[Main] performing its job with index {0}....", i);
                Thread.Sleep(1000);
            }
        }
    }
}
