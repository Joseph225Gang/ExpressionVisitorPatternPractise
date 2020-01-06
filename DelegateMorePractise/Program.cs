using System;
using System.Collections.Generic;

namespace DelegateMorePractise
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "櫻桃";//使用者輸入的文字

            Dictionary<string, Action> d = new Dictionary<string, Action>() {
           {"蘋果",  ()=> Console.WriteLine("Apple") }  , //各條件要做的事....
           {"香蕉",  ()=> Console.WriteLine("Banana")},
           {"櫻桃",  ()=>Console.WriteLine("Cherry")  },
           };

            d[userInput].Invoke();//直接挑選要執行的Method來執行


            Console.WriteLine("Hello World!");
        }
    }
}
