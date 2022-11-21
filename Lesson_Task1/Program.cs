using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lesson_Task1
{
    internal class Program
    {
        static void Print1()
        {
            while(true)
                Console.WriteLine("Primary");
        }
        static void Print2()
        {
            while(true)
            {
                Console.WriteLine(new string(' ',20)+"Secondary");
            }
        }
        
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Print2);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Print1();
            
        }
    }
}
