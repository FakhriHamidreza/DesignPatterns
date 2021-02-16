using System;

namespace DesignPatterns.SingletonPattern
{
    #region Sample1
    public sealed class Singleton
    {
        private static Singleton instance;

        // Lock synchronization object
        private static readonly object syncLock = new object();

        private int numberOfInstances = 0;

        private int numberOfCalls = 0;

        //Private constructor is used to prevent
        //creation of instances with 'new' keyword outside this class
        private Singleton()
        {
            Print.ToConsol("Instantiating inside the private constructor.");
            numberOfInstances++;
            Print.ToConsol($"Number of instances in Constraction = {numberOfInstances}");
        }

        public int GetNumberOfInstances() =>
            this.numberOfInstances;

        public int GetNumberOfCalls() =>
            this.numberOfCalls;

        public static Singleton Instance()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }

            instance.numberOfCalls++;
            
            return instance;
        }
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample2
    public sealed class SingletonNew
    {
        private static readonly SingletonNew instance = new SingletonNew();
        private int numberOfInstances = 0;

        //Private constructor is used to prevent
        //creation of instances with 'new' keyword outside this class
        private SingletonNew()
        {
            Print.ToConsol("Instantiating inside the private constructor.");
            numberOfInstances++;
            Print.ToConsol("Number of instances ={0}", numberOfInstances);
        }

        public static SingletonNew Instance
        {
            get
            {
                Print.ToConsol("We already have an instance now.Use it.");
                return instance;
            }
        }
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample3
    public sealed class SingletonStatic
    {
        private static readonly SingletonStatic instance;
        private static int numberOfInstances = 0;

        //Private constructor is used to prevent
        //creation of instances with 'new' keyword outside this class
        static SingletonStatic()
        {
            Print.ToConsol("Instantiating inside the private constructor.");
            numberOfInstances++;
            Print.ToConsol("Number of instances ={0}", numberOfInstances);
        }

        public static SingletonStatic Instance
        {
            get
            {
                Print.ToConsol("We already have an instance now.Use it.");
                return instance;
            }
        }
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample4
    public sealed class SingletonFullyLazy
    {
        private SingletonFullyLazy() { }

        public static SingletonFullyLazy Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() { }

            internal static readonly SingletonFullyLazy instance = new SingletonFullyLazy();
        }
    }
    #endregion
    // ---------------------------------------------------------------

    #region Sample5
    public sealed class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy>
            lazy =
            new Lazy<SingletonLazy>
                (() => new SingletonLazy());

        public static SingletonLazy Instance { get { return lazy.Value; } }

        private SingletonLazy() { }
    }
    #endregion

    #region Sample6

    [Serializable]
    public class SerializedSingleton
    {
        private static long serialVersionUID = -7604766932017737115L;

        private SerializedSingleton() { }

        private static class SingletonHelper
        {
            internal static SerializedSingleton instance = new SerializedSingleton();
        }

        public static SerializedSingleton getInstance()
        {
            return SingletonHelper.instance;
        }
    }
    #endregion

    public static class Print
    {
        public static void ToConsol(string txt, params object[] para) =>
            System.Console.WriteLine(txt, para);
    }
}