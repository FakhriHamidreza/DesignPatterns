namespace DesignPatterns.Client
{
    using System;
    using System.Threading;
    using DesignPatterns.SingletonPattern;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Singleton Pattern Demo***\n");
            //Console.WriteLine(Singleton.MyInt);
            //Private Constructor.So,we cannot use 'new' keyword.
            Console.WriteLine("Trying to create instance s1.");
            var s1 = Singleton.Instance();
            Console.WriteLine("Trying to create instance s2.");
            var s2 = Singleton.Instance();

            if (s1 == s2)
            {
                Console.WriteLine("Only one instance exists.");
            }
            else
            {
                Console.WriteLine("Different instances exist.");
            }

            // test thread-safe

            System.Threading.Tasks.Parallel.Invoke(
                () => TestSingleton("First")
             );

            var process1 = new Thread(() =>
            {
                TestSingleton("Thread 1");
            });

            var process2 = new Thread(() =>
            {
                TestSingleton("Thread 2");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
            Console.ReadKey();
        }

        public static void TestSingleton(string threadName)
        {
            Singleton singleton = Singleton.Instance();
            Console.WriteLine($"Number of instances in {threadName} = {singleton.GetNumberOfInstances()}, Total Nunmer of Calls: {singleton.GetNumberOfCalls()}");
        }
    }
}