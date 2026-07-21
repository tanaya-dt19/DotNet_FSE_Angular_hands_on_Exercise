using System;
using System.Reflection.Metadata;

namespace SingletonPatternExample {
    class Program { 
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetInstance();
            logger1.Log("Application Started");

            Logger logger2 = Logger.GetInstance();
            logger2.Log("User Logged In");

            if (logger1 == logger2)
            {
                Console.WriteLine("\nBoth loggers are the same instance.");
            }
            else 
            {
                Console.WriteLine("\nDifferent Instance Created.");    
            }

            Console.ReadKey();
        }
    }
}