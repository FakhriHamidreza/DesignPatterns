namespace DesignPatterns.SingletonPattern
{
    #region Sample1
    public sealed class Singleton
    {
        private static Singleton instance;

        // Lock synchronization object
        private static readonly object syncLock = new object();

        public int numberOfInstances = 0;

        //Private constructor is used to prevent
        //creation of instances with 'new' keyword outside this class
        private Singleton()
        {
            Print.ToConsol("Instantiating inside the private constructor.");
            numberOfInstances++;
            Print.ToConsol($"Number of instances in Constraction = {numberOfInstances}");
        }

        public static Singleton Instance()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                        //instance.numberOfInstances++;
                    }
                }
            }

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

    public static class Print
    {
        public static void ToConsol(string txt, params object[] para) =>
            System.Console.WriteLine(txt, para);
    }
}