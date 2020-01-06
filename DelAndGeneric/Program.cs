using System;

namespace DelAndGeneric
{
    class Program
    {
        public delegate void TypeAction<T>(T param);
        static void Main(string[] args)
        {
            ExecuteAction<string>(StringAction, "Hello");
            ExecuteAction<DateTime>(DateTimeAction, DateTime.Now);
            ExecuteAction<int>(IntAction, 1000);
            ExecuteAction<long>(LongAction, 3000);
            Console.WriteLine("Hello World!");
        }

        public static void StringAction(string param)
        {
            Console.WriteLine(param + " is string type");
        }

        public static void LongAction(long param)
        {
            Console.WriteLine(param + " is long type");
        }

        public static void IntAction(int param)
        {
            Console.WriteLine(param + " is interger type");
        }

        public static void DateTimeAction(DateTime param)
        {
            Console.WriteLine(param + " is datetime type");
        }

        public static void ExecuteAction<T>(TypeAction<T> action, T param)
        {
            action.Invoke(param);
        }
    }
}
